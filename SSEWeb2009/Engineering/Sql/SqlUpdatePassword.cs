using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdatePassword : ISql
    {
        private string userID;
        private string newPassword;

        public SqlUpdatePassword(string userId, string newPass)
        {
            userID = userId;
            newPassword = newPass;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update Account Set Password = '" + newPassword + "' where AccountID = '" + userID + "'";
        }

        #endregion
    }
}
