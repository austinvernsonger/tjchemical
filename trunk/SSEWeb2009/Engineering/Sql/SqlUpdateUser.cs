using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateUser:ISql
    {
        private string _userID;
        private string _userName;

        public SqlUpdateUser(string userID, string userName)
        {
            _userID = userID;
            _userName = userName;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update Users Set UserName = '" + _userName + "' where UserID='" + _userID + "'";
        }

        #endregion
    }
}
