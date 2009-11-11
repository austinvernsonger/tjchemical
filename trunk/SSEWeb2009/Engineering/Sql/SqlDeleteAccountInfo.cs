using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteAccountInfo:ISql
    {
        private string _studentID;

        public SqlDeleteAccountInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from Account where AccountID = '" + _studentID + "'";
        }

        #endregion
    }
}
