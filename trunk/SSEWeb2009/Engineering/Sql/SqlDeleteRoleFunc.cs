using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteRoleFunc:ISql
    {
        private int _roleID;

        public SqlDeleteRoleFunc(int roleID)
        {
            _roleID = roleID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from RoleFuncs where RoleID='" + _roleID + "'";
        }

        #endregion
    }
}
