using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateRoles:ISql
    {
        private int _roleID;
        private string _roleName;

        public SqlUpdateRoles(int roleid, string roleName)
        {
            _roleID = roleid;
            _roleName = roleName;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update Roles Set RoleName = '" + _roleName + "' where RoleId = '" + _roleID + "'";
        }

        #endregion
    }
}
