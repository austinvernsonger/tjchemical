using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetUserAndRole:ISql
    {
        private string _userID;
        private int _roleID;

        public SqlGetUserAndRole(string userID, int roleID)
        {
            _userID = userID;
            _roleID = roleID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from UserRoles where UseId='" + _userID + "' and RoleID='"+_roleID+"'";
        }

        #endregion
    }
}
