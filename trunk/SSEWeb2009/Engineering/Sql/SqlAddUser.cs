using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddUser:ISql
    {
        private string _userID;
        private string _name;

        public SqlAddUser(string userID, string name)
        {
            _userID = userID;
            _name = name;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into Users(UserID, UserName) values('" + _userID + "', '" + _name + "')";
        }

        #endregion
    }
}
