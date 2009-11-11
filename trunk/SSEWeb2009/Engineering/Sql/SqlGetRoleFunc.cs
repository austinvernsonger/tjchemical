using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetRoleFunc:ISql
    {
        private int _roleID;

        public SqlGetRoleFunc(int roleID)
        {
            _roleID = roleID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from RoleFuncs where RoleId='" + _roleID + "'";
        }

        #endregion
    }
}
