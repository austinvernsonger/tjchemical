using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetRoleName:ISql
    {
        private int _roleID;

        public SqlGetRoleName(int roleID)
        {
            _roleID = roleID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select RoleName from Roles where RoleId='"+_roleID+"'";
        }

        #endregion
    }
}
