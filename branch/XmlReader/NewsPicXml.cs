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
    public class NewsPicItem
    {
        private String picLink;

        public String PicLink
        {
            get { return picLink; }
            set { picLink = value; }
        }

        private String newsDescription;

        public String NewsDescription
        {
            get { return newsDescription; }
            set { newsDescription = value; }
        }

        private String newsID;

        public String NewsID
        {
            get { return newsID; }
            set { newsID = value; }
        }
    }

    /// <summary>
    /// 功能类：NewsPicXmlParse - 用于新闻图片管理的类
    /// 作者：Constantine
    /// 最近一次修改时间：2009-6-8
    /// </summary>
    public class NewsPicXmlParse : XmlDataParse
    {
        [XmlElement(Type = typeof(NewsPicItem))]
        public ArrayList itemList = new ArrayList();
        
        private NewsPicXmlParse():base() {}
        public NewsPicXmlParse(String xmlPath)
            :base(xmlPath)
        {}
        //反序列化 - 重载父类
        public override void Deserialize()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(GetType());
                FileStream fs = new FileStream(XmlFileName, FileMode.Open, FileAccess.Read);
                NewsPicXmlParse rt = xmlSer.Deserialize(fs) as NewsPicXmlParse;

                for (int i = 0; i < rt.itemList.Count;++i)
                {
                    this.itemList.Add(rt.itemList[i]);
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
