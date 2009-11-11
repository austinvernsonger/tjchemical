using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetUsersByRoleID:ISql
    {
        private int _roleID;

        public SqlGetUsersByRoleID(int roleID)
        {
            _roleID = roleID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Users as u inner join UserRoles as ur on ur.UseId = u.UserID where ur.RoleID='"+_roleID+"'";
        }

        #endregion
    }
}
