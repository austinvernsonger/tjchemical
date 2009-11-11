using System;
using System.Collections.Generic;
using System.Text;

namespace Education.src
{
    ///<summary>
    /// 助教申请表信息
    /// 作者：JerryChen
    /// 最近一次修改时间：2009-7-30
    ///</summary>
    ///
    public  class TA_ApplyInfo
    {
       private String _name;
       private String _studentId;
       private String _teacherName;
       private String _courseName;
       private bool _isStudied;
       private int _courseScore;
       private String _selfIntrduce;
       private String _phoneNumber;
       private String _Email;
       private String _comment;

       public  TA_ApplyInfo(String name,String id,String teacher,String course,bool studied,
                                 int score,String introduce,String phone,String Email,String comment)
        {
            _name = name;
            _studentId=id;
            _teacherName = teacher;
            _courseName = course;
            _isStudied = studied;
            _courseScore = score;
            _selfIntrduce = introduce;
            _phoneNumber = phone;
            _Email = Email;
            _comment = comment;
        }

        public String Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public String StudentId
        {
            set { _studentId = value; }
            get { return _studentId; }
        }

        public String TeacherName
        {
            set { _teacherName = value; }
            get { return _teacherName; }
        }

        public String CourseName
        {
            set { _courseName = value; }
            get { return _courseName; }
        }

        public bool IsStudied
        {
            set { _isStudied = value; }
            get { return _isStudied; }
        }

        public int CourseScore
        {
            set { _courseScore = value; }
            get { return _courseScore; }
        }

        public String SelfIntrduce
        {
            set { _selfIntrduce = value; }
            get { return _selfIntrduce; }
        }

        public String PhoneNumber
        {
            set { _phoneNumber = value; }
            get { return _phoneNumber; }
        }

        public String Email
        {
            set { _Email = value; }
            get { return _Email; }
        }

        public String Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }

    }
}
