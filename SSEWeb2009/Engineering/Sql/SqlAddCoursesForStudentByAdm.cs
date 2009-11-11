using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddCoursesForStudentByAdm:ISql
    {
        private int _courseID;
        private string _studentID;

        public SqlAddCoursesForStudentByAdm(int courseID, string studentID)
        {
            _courseID = courseID;
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into ExamResultInfo(CourID,StuID,IsOpened) values('" + _courseID + "','" + _studentID + "',1)";
        }

        #endregion
    }
}
