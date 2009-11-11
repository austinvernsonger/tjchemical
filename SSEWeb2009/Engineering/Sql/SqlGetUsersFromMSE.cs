using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetUsersFromMSE:ISql
    {
        private string _userID;

        public SqlGetUsersFromMSE(string userID)
        {
            _userID = userID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Users where UserID='"+_userID+"'";
        }

        #endregion
    }
}
