using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteUser:ISql
    {
        private string _userID;

        public SqlDeleteUser(string userID)
        {
            _userID = userID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from Users where UserID = '" + _userID + "'";
        }

        #endregion
    }
}
