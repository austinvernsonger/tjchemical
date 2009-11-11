using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Department.Engineering
{
    public class StudentInfo
    {
        #region Member Variables

        private string _stuID = null;
        private string _stuName = null;
        private string _password = null;
        private string _passwordAgn = null; //验证密码
        private int _accountState = -1; //账号状态
        private int _gender = -1;      //0表男，1表女
        private string _nativePro = null;  //籍贯
        private string _grade =null;     //年级
        private int _class = -1;    //班级
        private string _dormitory = null ;   //寝室
        private string _position = null ;    //职位
        private string _polStatus= null ;   //政治面貌
        private string _mobPhone = null ;   //手机号码
        private string _fixedPhone = null ;  //固定电话
        private string _advantage = null ;   //邮电
        private string _homeAddress = null ;  //家庭住址
        private string _birthday = null ;   //生日
        private string _nation =null ;     //民族
        private string _stuIDNumber = null ;  //身份证
        private string _degree = null ;      //学位
        private string _address = null ;     //地址
        private string _postalCode = null ;   //邮编
        private string _emailAddress = null ;  //EMAIL
        private int _marStatus = -1;       //婚姻状况
        private string _origDegree = null ;    //原学历
        private string _major= null ;         //专业领域名称
        private string _workPlace = null ;     //工作单位
        private string _workPlaceAdd = null ;   //工作单位地址
        private string _schooling = null ;       //学制
        private string _teacherName =null ;      //导师工号
        private string _teaSchoolID =null;    //教学点的编号
        private string _teaSchoolName = null; //教学点名称
        private string _graduateTime =null ;  //毕业时间

        #endregion

        #region Constructor

        public StudentInfo() { }

        #endregion

        #region Public Properties

        public string StuID
        {
            set { _stuID = value; }
            get { return _stuID; }
        }
        public string StuName
        {
            set { _stuName = value; }
            get { return _stuName; }
        }
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        public string PasswordAgn
        {
            set { _passwordAgn = value; }
            get { return _passwordAgn; }
        }
        public int AccountState
        {
            set { _accountState = value; }
            get { return _accountState; }
        }
        public int Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        public string NativePro
        {
            set { _nativePro = value; }
            get { return _nativePro; }
        }
        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        public int Class
        {
            set { _class = value; }
            get { return _class; }
        }
        public string Dormitory
        {
            set { _dormitory = value; }
            get { return _dormitory; }
        }
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        public string PolStatus
        {
            set { _polStatus = value; }
            get { return _polStatus; }
        }
        public string MobPhone
        {
            set { _mobPhone = value; }
            get { return _mobPhone; }
        }
        public string FixedPhone
        {
            set { _fixedPhone = value; }
            get { return _fixedPhone; }
        }
        public string Advantage
        {
            set { _advantage = value; }
            get { return _advantage; }
        }
        public string HomeAddress
        {
            set { _homeAddress = value; }
            get { return _homeAddress; }
        }
        public string Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        public string StuIDNumber
        {
            set { _stuIDNumber = value; }
            get { return _stuIDNumber; }
        }
        public string Degree
        {
            set { _degree = value; }
            get { return _degree; }
        }
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        public string PostalCode
        {
            set { _postalCode = value; }
            get { return _postalCode; }
        }
        public string EmailAddress
        {
            set { _emailAddress = value; }
            get { return _emailAddress; }
        }
        public int MarStatus
        {
            set { _marStatus = value; }
            get { return _marStatus; }
        }
        public string OrigDegree
        {
            set { _origDegree = value; }
            get { return _origDegree; }
        }
        public string Major
        {
            set { _major = value; }
            get { return _major; }
        }
        public string WorkPlace
        {
            set { _workPlace = value; }
            get { return _workPlace; }
        }
        public string WorkPlaceAdd
        {
            set { _workPlaceAdd = value; }
            get { return _workPlaceAdd; }
        }
        public string Schooling
        {
            set { _schooling = value; }
            get { return _schooling; }
        }
        public string TeacherName
        {
            set { _teacherName = value; }
            get { return _teacherName; }
        }
        public string TeaSchoolID
        {
            set { _teaSchoolID = value; }
            get { return _teaSchoolID; }
        }

        public string TeaSchoolName
        {
            set { _teaSchoolName = value; }
            get { return _teaSchoolName; }
        }

        public string GraduateTime
        {
            set { _graduateTime = value; }
            get { return _graduateTime; }
        }

        #endregion

    }
}
