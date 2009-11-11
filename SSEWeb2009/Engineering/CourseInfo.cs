using System;
using System.Collections.Generic;
using System.Text;

namespace Department.Engineering
{
    public class CourseInfo
    {
        private int _courseID =-1;
        private string _courseName = null;
        private int _target = -1;
        private string _courseTime = null;
        private int _diglossia =-1;
        private int _externalOrNot=-1;
        private string _textBook=null;
        private string _examMode =null;
        private int _studentNum =-1 ;  //课程人数
        private int _foreignTextBook =-1;
        private int _foreignPPT=-1;
        private string _languageClass =null;   //授课语种
        private float _foreignPercent =-1;
        private int _property =-1 ;    //课程性质
        private int _category = -1;    //课程类别
        private int _credit =-1;     //课程学分
        private int _creditHour =-1;  //学时
        private string _place = null;    //上课地点
        private string _classPeriod = null;  //上课时间
        private string _teaSchoolID =null;
        private string _grade = null;
        private string _instruMode = null;
        private string _teacher = null;  //任课教师

        public int CourseID
        {
            set { _courseID = value; }
            get { return _courseID; }
        }
        public string CourseName
        {
            set { _courseName = value; }
            get { return _courseName; }
        }
        public int Target
        {
            set { _target = value; }
            get { return _target;}
        }
        public string CourseTime
        {
            set { _courseTime = value; }
            get { return _courseTime; }
        }
        public int Diglossia
        {
            set { _diglossia = value; }
            get { return _diglossia; }
        }
        public int ExternalOrNot
        {
            set { _externalOrNot = value; }
            get { return _externalOrNot; }
        }
        public string TextBook
        {
            set { _textBook = value; }
            get { return _textBook; }
        }
        public string ExamMode
        {
            set { _examMode = value; }
            get { return _examMode; }
        }
        public int StudentNum
        {
            set { _studentNum = value; }
            get { return _studentNum; }
        }
        public int ForeignTextBook
        {
            set { _foreignTextBook = value; }
            get { return _foreignTextBook; }
        }
        public int ForeignPPT
        {
            set { _foreignPPT = value;}
            get { return _foreignPPT; }
        }
        public string LanguageClass
        {
            set { _languageClass = value; }
            get { return _languageClass; }
        }
        public float ForeignPercent
        {
            set { _foreignPercent = value; }
            get { return _foreignPercent;}
        }
        public int Property
        {
            set { _property = value; }
            get { return _property; }
        }
        public int Category
        {
            set { _category = value; }
            get { return _category; }
        }
        public int Credit
        {
            set { _credit = value; }
            get { return _credit; }
        }
        public int CreditHour
        {
            set { _creditHour = value; }
            get { return _creditHour; }
        }
        public string Place
        {
            set { _place = value; }
            get { return _place; }
        }
        public string ClassPeriod
        {
            set { _classPeriod = value; }
            get { return _classPeriod; }
        }
        public string TeaSchoolID
        {
            set { _teaSchoolID = value; }
            get { return _teaSchoolID;}
        }
        public string Grade
        {
            set{_grade = value;}
            get{return _grade;}
        }

        public string InstruMode
        {
            set { _instruMode = value; }
            get { return _instruMode; }
        }

        public string Teacher
        {
            set{_teacher = value;}
            get{return _teacher;}
        }

    }
}
