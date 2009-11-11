using System;
using System.Collections.Generic;
using System.Text;

namespace Department.Engineering
{
    /// <summary>
    /// 实体类
    /// 查询条件信息或插入条件信息
    /// </summary>
    /// 
    [Serializable]
    public class QueryInfo
    {

        #region Member Variables

        private string _grade = null;         //年级
        private string _tSchoolName = null;   //教学点名称
        private string _tSchoolID =null;           //教学点ID
        private string _accountId = null;     //工号或学号
        private string _name = null;          //姓名
        private string _time = null;
        private string _starttime = null;      //课程安排的开始时间
        private string _endtime = null;          //课程安排的结束时间
        private int _activityStatus = -1;  //活动状态
        private string _schoolStatus = null;     //学籍状态
       
        #endregion

        #region Constructor

        public QueryInfo() { }

        #endregion

        #region Public Properties

        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }

        public string TSchoolName
        {
            set { _tSchoolName = value; }
            get { return _tSchoolName; }
        }

        public string TSchoolID
        {
            set { _tSchoolID = value; }
            get { return _tSchoolID; }
        }

        public string AccountID
        {
            set { _accountId = value; }
            get { return _accountId; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Time
        {
            set { _time = value; }
            get { return _time; }
        }

        public string StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        public string EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }

        public int ActivityStatus
        {
            set { _activityStatus = value; }
            get { return _activityStatus; }
        }
        public string SchoolStatus
        {
            set { _schoolStatus = value; }
            get { return _schoolStatus; }
        }

        #endregion
    }

    /// <summary>
    /// 学生用户的查询条件信息
    /// 学生所用到的查询条件可用该实体类来表示
    /// </summary>
    public class StuQueryInfo
    {
        private string _grade = null;         //年级
        private string _tSchoolName = null;   //教学点名称
        private int _tSchoolID = 0;           //教学点ID
        private string _accountId = null;     //工号或学号
        private string _name = null;          //姓名
        private string _time = null;
        private string _starttime = null;      //课程安排的开始时间
        private string _endtime = null;          //课程安排的结束时间
        private int _activityStatus = -1;  //活动状态
        private string _schoolStatus = null;     //学籍状态

        private int _courseProperty = -1;
        private int _courseCategory = -1;
        private string _courseName = null;

        public int CourseProperty
        {
            set { _courseProperty = value; }
            get { return _courseProperty; }
        }
        public int CourseCategory
        {
            set { _courseCategory = value; }
            get { return _courseCategory; }
        }
        public string CourseName
        {
            set { _courseName = value; }
            get { return _courseName; }
        }
        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }

        public string TSchoolName
        {
            set { _tSchoolName = value; }
            get { return _tSchoolName; }
        }

        public int TSchoolID
        {
            set { _tSchoolID = value; }
            get { return _tSchoolID; }
        }

        public string AccountID
        {
            set { _accountId = value; }
            get { return _accountId; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Time
        {
            set { _time = value; }
            get { return _time; }
        }

        public string StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        public string EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }

        public int ActivityStatus
        {
            set { _activityStatus = value; }
            get { return _activityStatus; }
        }
        public string SchoolStatus
        {
            set { _schoolStatus = value; }
            get { return _schoolStatus; }
        }
    }

    /// <summary>
    /// 学生志愿信息
    /// </summary>
    public class Willing
    {
        private string _firstTeaID;
        private string _secondTeaID;
        private string _thirdTeaID;
        private string _teacherID;
        private string _stuID;

        public string TeacherID
        {
            set { _teacherID = value; }
            get { return _teacherID; }
        }

        public string StuID
        {
            set { _stuID = value; }
            get { return _stuID; }
        }

        public string FirstTeaID
        {
            set { _firstTeaID = value; }
            get { return _firstTeaID; }
        }

        public string SecondTeaID
        {
            set { _secondTeaID = value; }
            get { return _secondTeaID; }
        }

        public string ThirdTeaID
        {
            set { _thirdTeaID = value; }
            get { return _thirdTeaID; }
        }
    }

    /// <summary>
    /// 查询学生已选导师信息
    /// </summary>
    public class ChosenTutor
    {
        //private string _teaSchoolName = null;
        private int _teaSchoolID = -1;
        private string _grade = null;
        private string _studentID = null;

        /*
        public string TeaSchoolName
        {
            set { _teaSchoolName = value; }
            get { return _teaSchoolName; }
        }
         * */
        public int TeaSchoolID
        {
            set { _teaSchoolID = value; }
            get { return _teaSchoolID; }
        }

        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }

        public string StudentID
        {
            set { _studentID = value; }
            get { return _studentID; }
        }

    }

    public class PaperJudge
    {
        private int _isCriterion = -1;
        private string _result = null;
        private string _teacherid = null;
        private string _bNo = null;
        private int _judgeStatue = -1;
        private string _studentID = null;

        public string StudentID
        {
            set { _studentID = value; }
            get { return _studentID; }
        }

        public int Criterion
        {
            set { _isCriterion = value; }
            get { return _isCriterion; }
        }

        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }

        public string Teacherid
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }

        public string BNo
        {
            set { _bNo = value; }
            get { return _bNo; }
        }

        public int JudgeStatue
        {
            set { _judgeStatue = value; }
            get { return _judgeStatue; }
        }
    }
}
