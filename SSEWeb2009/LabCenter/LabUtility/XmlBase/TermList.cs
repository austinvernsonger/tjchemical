using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace LabCenter.LabUtility.XmlBase
{
    public class TermList:XmlParseBase
    {
        public TermList(){}
        public TermList(String path)
            : base(path) { }

        private List<string> m_termlist=new List<string>();

        [XmlElement(Type = typeof(string), ElementName = "Term")]
        public List<string> Terms
        {
            get { return m_termlist; }
            set { m_termlist = value; }
        }
    }
}
