using System;
using System.Collections.Generic;
using System.Text;
using SunMkr.Kernel.CfgElem;
using System.Xml;

namespace SunMkr.Proc
{
    //   <AS Name="DBPool" Assembly="SunMkr.AS.DB2.0.dll" NameSpace="SunMkr.AS" Class="DBPool" Instance="Instance" Statue="Running" />
    /// <summary>
    /// ASRegister XML
    /// </summary>
    public class ASRegister : ICfgElem
    {
        string m_name = string.Empty;
        /// <summary>
        /// The AS's name
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value.Clone() as string; }
        }
        string m_assembly = string.Empty;
        /// <summary>
        /// The AS's Assembly
        /// </summary>
        public string Assembly
        {
            get { return m_assembly; }
            set { m_assembly = value.Clone() as string; }
        }
        string m_namespace = string.Empty;
        /// <summary>
        /// The Namespace of the AS
        /// </summary>
        public string NameSpace
        {
            get { return m_namespace; }
            set { m_namespace = value.Clone() as string; }
        }
        string m_class = string.Empty;
        /// <summary>
        /// The AS's Class name
        /// </summary>
        public string Class
        {
            get { return m_class; }
            set { m_class = value.Clone() as string; }
        }
        string m_instance = string.Empty;
        /// <summary>
        /// The function to get the instance.
        /// </summary>
        public string Instance
        {
            get { return m_instance; }
            set { m_instance = value.Clone() as string; }
        }
        ASStatue m_statue = ASStatue.Abandon;
        /// <summary>
        /// The Statue of the AS.
        /// </summary>
        public ASStatue Statue
        {
            get { return m_statue; }
            set { m_statue = value; }
        }

        #region ICfgElem 成员

        /// <summary>
        /// To XmlNode
        /// </summary>
        /// <returns></returns>
        public XmlNode ToXmlNode()
        {
            //throw new NotImplementedException();
            XmlDocument xml = new XmlDocument();
            XmlNode xmlAS = xml.CreateElement("AS");
            xmlAS.Attributes["Name"].InnerText = this.Name;
            xmlAS.Attributes["Assembly"].InnerText = this.Assembly;
            xmlAS.Attributes["NameSpace"].InnerText = this.NameSpace;
            xmlAS.Attributes["Class"].InnerText = this.Class;
            xmlAS.Attributes["Instance"].InnerText = this.Instance;
            xmlAS.Attributes["Statue"].InnerText = this.Statue.ToString();

            return xmlAS;
        }

        /// <summary>
        /// Generate ASRegister from a XmlNode
        /// </summary>
        /// <param name="node"></param>
        public void FromXmlNode(XmlNode node)
        {
            //throw new NotImplementedException();
            if (node == null) throw new NullReferenceException("Node cannot be null.");
            if (node.Name != "AS") throw new ArgumentException("Node's name is not AS");
            this.Name = node.Attributes["Name"].InnerText;
            this.Assembly = node.Attributes["Assembly"].InnerText;
            this.NameSpace = node.Attributes["NameSpace"].InnerText;
            this.Class = node.Attributes["Class"].InnerText;
            this.Instance = node.Attributes["Instance"].InnerText;
            this.Statue = (ASStatue)Enum.Parse(typeof(ASStatue), node.Attributes["Statue"].InnerText);
        }

        /// <summary>
        /// Key word to identify
        /// </summary>
        public string KeyWord
        {
            get { return this.Name; }
        }

        #endregion
    }
}
