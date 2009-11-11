using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentMSE:ISql
    {
        private string _studentID;

        public SqlDeleteStudentMSE(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from StudentMSE where StudentID ='" + _studentID + "'";
        }

        #endregion
    }
}
