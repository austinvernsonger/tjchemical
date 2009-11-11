using System;
using System.Collections.Generic;
using System.Text;

namespace Department.Engineering
{
    class TeacherInfo
    {
         #region Member Variables

        private string _teaID;
        private string _teaName;
        private int _teaGender;    //0-M,1-F
        private DateTime _birthDay;
        private string _teaAddr;
        private string _teaPhone;
        private string _teaFax;
        private string _teaEmail;
        private string _teaTitle;     //教师职称
        private string _teaPost;      //职务
        private string _educationDegree;  //学历
        private string _researchArea;  //研究方向
        private string _teaMemo;      //备注

        #endregion

        #region Constructor

        public TeacherInfo() { }

        #endregion

        #region Public Properties

        public string TeaID
        {
            set { _teaID = value; }
            get { return _teaID; }
        }

        public string TeaName
        {
            set { _teaName = value; }
            get { return _teaName; }
        }

        public int TeaGender
        {
            set { _teaGender = value; }
            get { return _teaGender; }
        }

        public DateTime Birthday
        {
            set { _birthDay = value; }
            get { return _birthDay; }
        }

        public string TeaAddr
        {
            set { _teaAddr = value; }
            get { return _teaAddr; }
        }

        public string TeaPhone
        {
            set { _teaPhone = value; }
            get { return _teaPhone; }
        }

        public string TeaFax
        {
            set { _teaFax = value; }
            get { return _teaFax; }
        }

        public string TeaEmail
        {
            set { _teaEmail = value; }
            get { return _teaEmail; }
        }

        public string TeaTitle
        {
            set { _teaTitle = value; }
            get { return _teaTitle; }
        }

        public string TeaPost
        {
            set { _teaPost = value; }
            get { return _teaPost; }
        }

        public string EducationDegree
        {
            set { _educationDegree = value; }
            get { return _educationDegree; }
        }

        public string ResearchArea
        {
            set { _researchArea = value; }
            get { return _researchArea; }
        }

        public string TeaMemo
        {
            set { _teaMemo = value; }
            get { return _teaMemo; }
        }

        
        #endregion


        
    }
}
