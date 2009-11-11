using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using Education.src;

namespace Education.Sql
{
    public class sqlAddTAapply : ISql
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

        public sqlAddTAapply(TA_ApplyInfo theInfo)
        {
            _name = theInfo.Name;
            _studentId = theInfo.StudentId;
            _teacherName = theInfo.TeacherName;
            _courseName = theInfo.CourseName;
            _isStudied = theInfo.IsStudied;
            _courseScore = theInfo.CourseScore;
            _selfIntrduce = theInfo.SelfIntrduce;
            _phoneNumber = theInfo.PhoneNumber;
            _Email = theInfo.Email;
            _comment = theInfo.Comment;
        }

        /// <summary>
        /// Get Sql Sentence
        /// </summary>
        #region ISql members
        public string GetSql()
        {
            return "insert into assistantApply(id, teacher, course_id, is_studied,	score, Self_appraise, Phone_number, E_mail, comment)'" +
            "values(" + _studentId + "','" + _teacherName + "','" + _courseName + "','" + _isStudied + "','" + _courseScore + "','" + _selfIntrduce +
            "','" + _phoneNumber + "','" + _Email + "','" + _comment + "')";
        }
        #endregion
    }
}
