using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.LabUtility.XmlBase;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;

namespace LabCenter.Repair
{
    public class ComputerNumbers:XmlParseBase
    {
        public ComputerNumbers(){}
        public ComputerNumbers(String path):base(path){}


        /// <summary>
        /// 电脑编号，Key表示房间号，Value表示最大编号
        /// </summary>
        List<KeyValuePair<int, int>> m_cnumbers=new List<KeyValuePair<int,int>>();

        /// <summary>
        /// 同上
        /// </summary>
        public List<KeyValuePair<int, int>> CNumberList
        {
            get { return m_cnumbers; }
            set { m_cnumbers = value; }
        }

        public override void Serialize()
        {
            //定义XMLDocument
            XmlDocument xmlDocument = new XmlDocument();

            //定义XML文档头文件
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            //增加XML文档头
            xmlDocument.AppendChild(xmlDeclaration);

            //定义XML的根
            XmlElement xmlRoot = xmlDocument.CreateElement("ComputerNumbers");
            //添加XML的根
            xmlDocument.AppendChild(xmlRoot);

            //定义节点
            XmlNode xmlElement;

            //XML需要的属性列表
            foreach (KeyValuePair<int,int> keyValuePair in m_cnumbers)
            {
                xmlElement = xmlDocument.CreateElement("OneRoom");
                //定义XML根的节点中的属性
                XmlAttribute oneAttribute = xmlDocument.CreateAttribute("RoomNumber");
                oneAttribute.Value = keyValuePair.Key.ToString();

                XmlAttribute secAttribute = xmlDocument.CreateAttribute("MaxNumber");
                secAttribute.Value = keyValuePair.Value.ToString();

                //添加XML根的节点中的属性
                xmlElement.Attributes.Append(oneAttribute);
                xmlElement.Attributes.Append(secAttribute);

                //添加XML根的节点
                xmlRoot.AppendChild(xmlElement);
            }

            //保存XML文档
            xmlDocument.Save(FilePath);
        }
        public override XmlParseBase Deserialize()
        {
            try
            {
                XmlDocument x = new XmlDocument();
                x.Load(FilePath);

                XmlNodeList xnl = x.SelectNodes("//OneRoom");
                foreach (XmlNode xn in xnl)
                {
                    int key=int.Parse(xn.Attributes["RoomNumber"].Value);
                    int value=int.Parse(xn.Attributes["MaxNumber"].Value);
                    KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(key,value);
                    m_cnumbers.Add(kvp);
                }
                return this;
            }
            catch (System.Exception e)
            {
                e.ToString();
                return this;
            }
            
        }
    }
}
