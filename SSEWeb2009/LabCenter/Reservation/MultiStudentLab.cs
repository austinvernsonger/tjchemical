using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using LabCenter.LabUtility.XmlBase;

namespace LabCenter.Reservation
{
    public class MultiStudentLab:XmlParseBase
    {
        private List<StudentNo> stuList;

        public MultiStudentLab(){}
        public MultiStudentLab(string path) : base(path) 
        {
            stuList = new List<StudentNo>();
        }

        [XmlArrayItem("Student",typeof(StudentNo))]
        public List<StudentNo> StudentList
        {
            get { return stuList; }
            set { stuList = value; }
        }
    }
}
