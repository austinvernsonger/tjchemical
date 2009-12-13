using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SunMkr.Kernel;
using SunMkr.Com.Literal;
using System.IO;
using SunMkr.Sys;

namespace SunMkr.Proc
{
    /// <summary>
    /// ASLoader
    /// </summary>
    public static class ASLoader
    {
        static XmlDocument xmlAS;
        static XmlNode xmlRoot;
        static Dictionary<string, ASRegister> pool;
        static string path;

        static ASLoader()
        {
            xmlAS = null;
            xmlRoot = null;
            pool = new Dictionary<string, ASRegister>();
            path = AppDomain.CurrentDomain.BaseDirectory + MD5Hash.GetMD5Hash("ASRegister.xml");
        }

        /// <summary>
        /// Initialize the AS
        /// </summary>
        /// <returns></returns>
        public static bool Initialize()
        {
            FileInfo fi = new FileInfo(path);
            Terminate();
            if (!fi.Exists)
            {
                try
                {
                    StreamReader sr = new StreamReader(SunMkrHandler.GetManifestResourceStream("SunMkr.ASRegister.xml"));
                    StreamWriter sw = new StreamWriter(path);
                    sw.Write(sr.ReadToEnd());
                    sw.Close();
                }
                catch
                {
                    return false;
                }
            }
            try
            {
                xmlAS = new XmlDocument();
                xmlAS.Load(path);
                foreach (XmlNode node in xmlAS.ChildNodes)
                {
                    if (node.Name != "ASRegister") continue;
                    xmlRoot = node;
                    foreach (XmlNode As in node.ChildNodes)
                    {
                        // Register the AS
                        ASRegister asReg = new ASRegister();
                        asReg.FromXmlNode(As);
                        if (!ControlCenter.RegeditAS(asReg)) return false;
                        pool.Add(asReg.Name, asReg);
                    }
                    break;
                }
            }
            catch (Exception exp)
            {
                ErrorSystem.CatchError(exp);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Unregister all AS.
        /// </summary>
        public static void Terminate()
        {
            foreach (string ASName in pool.Keys)
            {
                ControlCenter.UnRegAS(ASName);
            }
            pool.Clear( );
        }

        /// <summary>
        /// Install AS
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Assembly"></param>
        /// <param name="NameSpace"></param>
        /// <param name="Class"></param>
        /// <param name="Instance"></param>
        /// <param name="Statue"></param>
        /// <returns></returns>
        public static bool InstallAS(
            string Name,
            string Assembly,
            string NameSpace,
            string Class,
            string Instance,
            ASStatue Statue)
        {
            ASRegister Reg = new ASRegister();
            Reg.Name = Name;
            Reg.Assembly = Assembly;
            Reg.NameSpace = NameSpace;
            Reg.Class = Class;
            Reg.Instance = Instance;
            Reg.Statue = Statue;

            if ( !ControlCenter.RegeditAS(Reg))
                return false;

            pool.Add(Reg.Name, Reg);
            xmlRoot.AppendChild(Reg.ToXmlNode());
            xmlAS.Save(path);
            return true;
        }

        /// <summary>
        /// Uninstall an AS.
        /// </summary>
        /// <param name="ASName"></param>
        /// <returns></returns>
        public static bool UnInstallAS(string ASName)
        {
            if (!ControlCenter.UnRegAS(ASName)) return false;
            xmlRoot.RemoveChild(pool[ASName].ToXmlNode());
            pool.Remove(ASName);
            xmlAS.Save(path);
            return true;
        }

        /// <summary>
        /// Shutdown an AS.
        /// </summary>
        /// <param name="ASName"></param>
        /// <returns></returns>
        public static bool ShutdownAS(string ASName)
        {
            if (pool[ASName].Statue != ASStatue.Running) return true;
            if (!ControlCenter.UnRegAS(ASName)) return false;
            pool[ASName].Statue = ASStatue.Stopped;
            return true;
        }

        /// <summary>
        /// Restart an AS.
        /// </summary>
        /// <param name="ASName"></param>
        /// <returns></returns>
        public static bool RestartAS(string ASName)
        {
            if (pool[ASName].Statue == ASStatue.Running) return true;
            if (!ControlCenter.RegeditAS(pool[ASName])) return false;
            pool[ASName].Statue = ASStatue.Running;
            return true;
        }
    }
}
