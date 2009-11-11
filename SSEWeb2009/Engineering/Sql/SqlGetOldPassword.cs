using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetOldPassword : ISql
    {
        private string userID;

        public SqlGetOldPassword(string userId)
        {
            userID = userId;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Select * from Account where AccountID = '" + userID + "'";
        }

        #endregion
    }
}
