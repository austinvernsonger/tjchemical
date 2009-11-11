using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddUserRole:ISql
    {
        private string _userID;
        private int _roleID;

        public SqlAddUserRole(string userID, int roleID)
        {
            _userID = userID;
            _roleID = roleID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into UserRoles(UseId, RoleID) values('" + _userID + "', '" + _roleID + "')";
        }

        #endregion
    }
}
