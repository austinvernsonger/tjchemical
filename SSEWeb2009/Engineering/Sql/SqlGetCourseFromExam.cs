using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseFromExam:ISql
    {
        private int _courseID;
        private string _studentID;

        public SqlGetCourseFromExam(int courId, string studentid)
        {
            _courseID = courId;
            _studentID = studentid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from ExamResultInfo where CourID='" + _courseID + "' and StuID='"+_studentID+"'";
        }

        #endregion
    }
}
