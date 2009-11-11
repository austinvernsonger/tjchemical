using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using LabCenter.LabUtility.XmlBase;

namespace LabCenter.Reservation
{
    public class TermList:XmlParseBase
    {
        public TermList(){}
        public TermList(String path)
            : base(path) { }

        private List<int> m_termlist=new List<int>();

        [XmlElement(Type = typeof(int), ElementName = "Term")]
        public List<int> Terms
        {
            get { return m_termlist; }
            set { m_termlist = value; }
        }
    }
}
