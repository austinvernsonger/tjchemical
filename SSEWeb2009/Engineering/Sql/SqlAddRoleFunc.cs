using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddRoleFunc:ISql
    {
        private int _roleID;
        private string _funcID;

        public SqlAddRoleFunc(int roleID, string funcID)
        {
            _roleID = roleID;
            _funcID = funcID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into RoleFuncs(RoleID,FuncID) values('" + _roleID + "','" + _funcID + "')";
        }

        #endregion
    }
}
