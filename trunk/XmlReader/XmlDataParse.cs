using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace SysCom
{
    /// <summary>
    /// 功能类：XmlDataParse - 解析XML并提供序列化和反序列化功能的基类
    /// 作者：Constantine
    /// 最近一次修改时间：2009-5-??
    /// </summary>
    public class XmlDataParse
    {
        public XmlDataParse()
        {
            xmlFileName = null;
        }

        public XmlDataParse(String fileName)
        {
            xmlFileName = fileName;
        }

        /// <summary>
        /// XML的文件路径
        /// </summary>
        private String xmlFileName;
        public String XmlFileName
        {
            get { return xmlFileName; }
            // set { xmlFileName = value; }
            // 取消set，让你不能序列化
        }

        /// <summary>
        /// 序列化对象为文件
        /// </summary>
        public virtual void Serialize()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(GetType());
                FileStream fs = new FileStream(XmlFileName, FileMode.Create, FileAccess.Write);
                xmlSer.Serialize(fs, this);
                fs.Close();
            }
            catch (System.Exception e)
            {
                e.ToString();
                throw e;
            }
        }

        /// <summary>
        /// 从文件中反序列化为对象
        /// </summary>
        public virtual void Deserialize()
        {
            //这里根据子类的不同数据结构，由子类进行重载
        }
    }
}
