using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteUserRole:ISql
    {
        private string _userID;
        private int _roleID;

        public SqlDeleteUserRole(int roleID, string userID)
        {
            _roleID = roleID;
            _userID = userID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from UserRoles where UseId = '" + _userID + "' and RoleID='"+_roleID+"'";
        }

        #endregion
    }
}
