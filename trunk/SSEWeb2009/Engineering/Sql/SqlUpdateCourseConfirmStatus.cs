using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateCourseConfirmStatus:ISql
    {
        private int _courseID;
        private string _studentID;
        private int _status;

        public SqlUpdateCourseConfirmStatus(int courseID, string studentID,int status)
        {
            _courseID = courseID;
            _studentID = studentID;
            _status = status;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update ExamResultInfo Set IsOk='" + _status + "' where StuID = '" + _studentID + "' and CourID='" + _courseID + "'";
        }

        #endregion
    }
}
