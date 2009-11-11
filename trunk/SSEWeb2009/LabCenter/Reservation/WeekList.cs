using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using LabCenter.LabUtility.XmlBase;

namespace LabCenter.Reservation
{
     public class WeekList:XmlParseBase
    {
         public WeekList(){}
         public WeekList(String path)
            : base(path) { }

        private List<int> m_weeklist=new List<int>();

        [XmlElement(Type = typeof(int), ElementName = "Week")]
        public List<int> Weeks
        {
            get { return m_weeklist; }
            set { m_weeklist = value; }
        }
    }
}
