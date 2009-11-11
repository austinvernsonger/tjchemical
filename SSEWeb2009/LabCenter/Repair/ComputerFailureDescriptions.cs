using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.LabUtility.XmlBase;
using System.Xml.Serialization;

namespace LabCenter.Repair
{
    public class ComputerFailureDescriptions:XmlParseBase
    {
        public ComputerFailureDescriptions(){}
        public ComputerFailureDescriptions(String path):base(path){}

        List<String> m_failures = new List<String>();

        [XmlElement(ElementName="Description")]
        public List<String> Failures
        {
            get { return m_failures; }
            set { m_failures = value; }
        }
    }
}
