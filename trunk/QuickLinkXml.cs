using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace SysCom
{
    /// <summary>
    /// 需要序列化的数据结构，存于一个ArrayList中
    /// </summary>
    public class LinkItem
    {
        private String linkName;
        public String LinkName
        {
            get { return linkName; }
            set { linkName = value; }
        }

        private String linkAddr;
        public String LinkAddr
        {
            get { return linkAddr; }
            set { linkAddr = value; }
        }
    }

    /// <summary>
    /// 功能类：QuickLinkXmlParse - 用于快速链接管理的类
    /// 作者：Constantine
    /// 最近一次修改时间：2009-5-??
    /// 继承而来的需要序列化和反序列化的类
    /// </summary>
    public class QuickLinkXmlParse : XmlDataParse
    {
        [XmlElement(Type = typeof(LinkItem))]
        public ArrayList ItemList = new ArrayList(10);

        //不让你用这个
        private QuickLinkXmlParse():base() {}
        //就用这个
        public QuickLinkXmlParse(String path)
            : base(path) {}

        //反序列化 - 重载父类
        public override void Deserialize()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(GetType());
                FileStream fs = new FileStream(XmlFileName, FileMode.Open, FileAccess.Read);
                QuickLinkXmlParse rt = xmlSer.Deserialize(fs) as QuickLinkXmlParse;

                for (int i = 0; i < rt.ItemList.Count; ++i)
                {
                    this.ItemList.Add(rt.ItemList[i]);
                }

                fs.Close();
            }
            catch (System.Exception e)
            {
                e.ToString();
                throw e;
            }
        }
    }
}
