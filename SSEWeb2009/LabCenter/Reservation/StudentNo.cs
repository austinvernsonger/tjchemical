using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using LabCenter.LabUtility.XmlBase;

namespace LabCenter.Reservation
{
    [XmlRoot()]
    public class StudentNo
    {
        private string keyNo;
 
        public StudentNo(){}

        public StudentNo(string key, List<string> values)
        {
            keyNo = key;
            valuesNo = values;
        }

        [XmlAttribute()]
        public string KeyNo
        {
            get { return keyNo; }
            set { keyNo = value; }
        }

        private List<string> valuesNo;

        [XmlElement("valueNo",typeof(string))]
        public List<string> ValuesNo
        {
            get { return valuesNo; }
            set { valuesNo = value; }
        }
    }
}
