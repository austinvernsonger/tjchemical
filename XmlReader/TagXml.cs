using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using System.Collections;
using System.IO;

namespace SysCom
{
    /// <summary>
    /// 给装TagXml的ArrayList排序用的，是降序排列
    /// </summary>
    public class TagItemComparer : IComparer
    {
        public int Compare(Object leftItem,Object rightItem)
        {
            TagItem fItem = leftItem as TagItem;
            TagItem rItem = rightItem as TagItem;
            if (fItem.TagNum < rItem.TagNum)
            {
                return 1;
            }
            else if (fItem.TagNum > rItem.TagNum)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }


    /// <summary>
    /// 用于序列化的单个项
    /// </summary>
    public class TagItem
    {
        private int tagNum;
        public int TagNum
        {
            get { return tagNum; }
            set { tagNum = value; }
        }
        private String tagName;
        public String TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
    }

    /// <summary>
    /// 功能类：TagXmlParse - 用于Tag管理的类
    /// 作者：Constantine
    /// 最近一次修改时间：2009-5-??
    /// </summary>
    public class TagXmlParse : XmlDataParse
    {
        [XmlElement(Type = typeof(TagItem))]
        public ArrayList ItemList = new ArrayList();

        private TagXmlParse() : base(){}

        public TagXmlParse(String xmlPath)
            : base(xmlPath)
        {}

        //反序列化 - 重载父类
        public override void Deserialize()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(GetType());
                FileStream fs = new FileStream(XmlFileName, FileMode.Open, FileAccess.Read);
                TagXmlParse rt = xmlSer.Deserialize(fs) as TagXmlParse;

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

        //得到List中最大的值
        public int GetMaxNum()
        {
            if (ItemList.Count == 0)
            {
                return 0;
            }
            TagItem tagItem = null;
            int maxNum = ((TagItem)ItemList[0]).TagNum;
            for (int i = 1; i < ItemList.Count;++i )
            {
                tagItem = (TagItem)ItemList[i];
                if (maxNum < tagItem.TagNum)
                {
                    maxNum = tagItem.TagNum;
                }
            }

            return maxNum;
        }
    }
}
