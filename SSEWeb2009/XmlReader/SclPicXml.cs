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
    public class SclPicItem
    {
        private String picUrl;
        public System.String PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }
        private String picThumUrl;
        public System.String PicThumUrl
        {
            get { return picThumUrl; }
            set { picThumUrl = value; }
        }
    }

    /// <summary>
    /// 功能类：SclPicXmlParse - 用于学院图片管理的类
    /// 作者：Constantine
    /// 最近一次修改时间：2009-6-8
    /// </summary>
    public class SclPicXmlParse : XmlDataParse
    {
        [XmlElement(Type = typeof(SclPicItem))]
        public ArrayList itemList = new ArrayList();

        private SclPicXmlParse() : base(){}
        public SclPicXmlParse(String xmlPath)
            :base(xmlPath)
        {}
        //反序列化 - 重载父类
        public override void Deserialize()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(GetType());
                FileStream fs = new FileStream(XmlFileName, FileMode.Open, FileAccess.Read);
                SclPicXmlParse rt = xmlSer.Deserialize(fs) as SclPicXmlParse;

                for (int i = 0; i < rt.itemList.Count; ++i)
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
