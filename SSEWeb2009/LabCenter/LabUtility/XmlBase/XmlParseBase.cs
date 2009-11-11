using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LabCenter.LabUtility.XmlBase
{
    public class XmlParseBase
    {
        public XmlParseBase()
        {

        }
        public XmlParseBase(String filepath)
        {
            m_filepath = filepath;
        }

        /// <summary>
        /// XML的文件路径
        /// </summary>
        private String m_filepath;
        [XmlIgnore]
        public String FilePath
        {
            get { return m_filepath; }
            set { m_filepath = value; }
        }

        public virtual void Serialize()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(GetType());
                FileStream fs = new FileStream(m_filepath, FileMode.Create, FileAccess.Write);
                xmlSer.Serialize(fs, this);
                fs.Close();
            }
            catch (Exception e)
            {
                e.ToString();
                throw e;
            }
        }
        public virtual XmlParseBase Deserialize()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(GetType());
                FileStream fs = new FileStream(m_filepath, FileMode.Open, FileAccess.Read);
                XmlParseBase rt = xmlSer.Deserialize(fs) as XmlParseBase;
                fs.Close();
                return rt;
            }
            catch (System.Exception e)
            {
                e.ToString();
                return null;
            }
        }
    }
}
