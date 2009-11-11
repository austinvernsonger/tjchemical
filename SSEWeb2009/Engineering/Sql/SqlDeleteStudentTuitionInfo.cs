using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentTuitionInfo:ISql
    {
        private string _studentID;

        public SqlDeleteStudentTuitionInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from TuitionInfo where StuID ='" + _studentID + "'";
        }

        #endregion
    }
}
