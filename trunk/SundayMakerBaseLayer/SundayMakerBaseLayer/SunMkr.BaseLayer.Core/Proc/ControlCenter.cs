using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Reflection;
using SunMkr.Sys;

namespace SunMkr.Proc
{
    /// <summary>
    /// Control Center template class
    /// </summary>
    public static class ControlCenter
    {
        static Dictionary<string, object> g_AS_Pool;
        static object lockObj;

        /// <summary>
        /// Static Construction
        /// </summary>
        static ControlCenter()
        {
            if ( g_AS_Pool != null ) return;
            g_AS_Pool = new Dictionary<string, object>( );
            lockObj = new object( );
        }

        /// <summary>
        /// Initialize the control center.
        /// </summary>
        public static void Initialize()
        {
            if ( g_AS_Pool != null && g_AS_Pool.Count != 0 ) return;
            g_AS_Pool = new Dictionary<string, object>( );
            lockObj = new object( );
        }

        /// <summary>
        /// Register Abstarct System
        /// </summary>
        /// <param name="RegAS"></param>
        /// <returns></returns>
        public static bool RegeditAS(ASRegister RegAS)
        {
            if (g_AS_Pool.ContainsKey(RegAS.Name)) return true;
            // Load the Assembly.
            try
            {
                Assembly _aAS = null;
                foreach (Assembly _AS in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (_AS.ManifestModule.Name.ToLower() == RegAS.Assembly.ToLower())
                    {
                        _aAS = _AS;
                        break;
                    }
                }
                // Didn't find the assembly.
                if (_aAS == null) return false;
                // Check Assembly Statue.
                string _type = string.Format("{0}.{1}", RegAS.NameSpace, RegAS.Class);
                Type _tAS = _aAS.GetType(_type, true);
                BindingFlags bindingFlags =
                    BindingFlags.DeclaredOnly |
                    BindingFlags.Static |
                    BindingFlags.Public |
                    BindingFlags.InvokeMethod;
                object objAS = _tAS.InvokeMember(RegAS.Instance, bindingFlags, null, null, null);
                // Start the Abstarct System.
                bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.InvokeMethod;
                MethodInfo mi = _tAS.GetMethod("Start");
                if (!Convert.ToBoolean(mi.Invoke(objAS, null))) return false;
                //_tAS.InvokeMember("Start", bindingFlags, null, objAS, null);
                lock (lockObj)
                {
                    g_AS_Pool.Add(RegAS.Name, objAS);
                }
            }
            catch (Exception exp)
            {
                ErrorSystem.CatchError(exp);
                // Any exception cause the register failed.
                return false;
            }

            return true;
        }

        /// <summary>
        /// Register Abstarct System
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Assembly"></param>
        /// <param name="NameSpace"></param>
        /// <param name="Class"></param>
        /// <param name="Instance"></param>
        /// <param name="Statue"></param>
        /// <returns></returns>
        public static bool RegeditAS(
            string Name, string Assembly, string NameSpace, 
            string Class, string Instance, ASStatue Statue)
        {
            ASRegister RegAS = new ASRegister();
            RegAS.Name = Name;
            RegAS.Assembly = Assembly;
            RegAS.NameSpace = NameSpace;
            RegAS.Class = Class;
            RegAS.Instance = Instance;
            RegAS.Statue = Statue;
            return RegeditAS(RegAS);
        }

        /// <summary>
        /// Register Abstarct System
        /// </summary>
        /// <param name="RegNode"></param>
        /// <returns></returns>
        public static bool RegeditAS(XmlNode RegNode)
        {
            ASRegister RegAS = new ASRegister();
            RegAS.FromXmlNode(RegNode);
            return RegeditAS(RegAS);
        }

        /// <summary>
        /// UnReg Abstract System.
        /// </summary>
        /// <param name="ASName"></param>
        /// <returns></returns>
        public static bool UnRegAS(string ASName)
        {
            lock (lockObj)
            {
                if (g_AS_Pool.ContainsKey(ASName))
                {
                    g_AS_Pool.Remove(ASName);
                }
            }
            return true;
        }

        
        /// <summary>
        /// Register the operation.
        /// </summary>
        /// <typeparam name="Provider"></typeparam>
        /// <param name="Op"></param>
        /// <returns></returns>
        public static bool RegOp<Provider>( absOperation<Provider> Op ) where Provider : class, IProvider
        {
            // Check the Abstract System.

            IAS<Provider> AS = null;
            Provider _pv;
            //Type _tAS = typeof(IAS<Provider, Processor>);
            lock (lockObj)
            {
                if (!g_AS_Pool.ContainsKey(Op.ASName)) return false;
                AS = g_AS_Pool[Op.ASName] as IAS<Provider>;
            }
            _pv = AS.GetProvider(Op.BindString);
            try
            {
                AS.StartProvider( _pv );
            }
            catch (Exception exp)
            {
                Op.LastErrorID = ErrorSystem.CatchError(exp);
                AS.ReleaseProvider(Op.BindString, _pv);
                return false;
            }
            Op.myProc = _pv;
            return true;
        }

        /// <summary>
        /// Release the Operator and the Provider.
        /// </summary>
        /// <typeparam name="Provider"></typeparam>
        /// <param name="Op"></param>
        public static void ReleaseOp<Provider>( absOperation<Provider> Op ) where Provider : class, IProvider
        {
            try
            {
                IAS<Provider> AS;
                lock (lockObj)
                {
                    // The AS has been unregistered.
                    if (!g_AS_Pool.ContainsKey(Op.ASName))
                    {
                        return;
                    }
                    AS = g_AS_Pool[Op.ASName] as IAS<Provider>;
                }
                AS.ReleaseProvider(Op.BindString, Op.myProc);
                Op.myProc = null;
            }
            catch (Exception exp)
            {
                Op.LastErrorID = ErrorSystem.CatchError(exp);
            }
        }

        /// <summary>
        /// Do Under Control
        /// </summary>
        /// <typeparam name="Provider"></typeparam>
        /// <param name="Op"></param>
        /// <returns></returns>
        public static bool DoUnderControl<Provider>( absOperation<Provider> Op ) where Provider : class, IProvider
        {
            try
            {
                Op.processUnderControl();
            }
            catch (Exception exp)
            {
                Op.LastErrorID = ErrorSystem.CatchError(exp);
                return false;
            }
            return true;
        }
    }
}
