using System;
using System.Collections.Generic;
using System.Text;

namespace Department.Engineering
{
    public class TestInfo
    {
        private int _examID = -1;
        private int _courseID =-1;
        private string _testTime = null;
        private string _testPlace = null;
        private string _supervisor1 = null;
        private string _supervisor2 = null;

        public TestInfo()
        { }

        public int ExamID
        {
            set { _examID = value; }
            get { return _examID; }
        }

        public int CourseID
        {
            set { _courseID = value; }
            get { return _courseID; }
        }

        public string TestTime 
        {
            set { _testTime = value; }
            get { return _testTime; }
        }

        public string TestPlace
        {
            set { _testPlace = value; }
            get { return _testPlace; }
        }

        public string Supervisor1
        {
            set { _supervisor1 = value; }
            get { return _supervisor1; }
        }

        public string Supervisor2
        {
            set { _supervisor2 = value; }
            get { return _supervisor2; }
        }
    }
}
