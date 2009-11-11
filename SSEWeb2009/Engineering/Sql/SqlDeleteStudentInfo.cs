using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentInfo:ISql
    {
        private string _studentID;

        public SqlDeleteStudentInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from Student where StudentID ='" + _studentID + "'";
        }

        #endregion
    }
}
