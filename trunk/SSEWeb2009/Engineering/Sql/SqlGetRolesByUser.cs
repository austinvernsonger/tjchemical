using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetRolesByUser:ISql
    {
        private string _userID;

        public SqlGetRolesByUser(string userID)
        {
            _userID = userID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Roles as r inner join UserRoles as ur on r.RoleId = ur.RoleID where UseId='"+_userID+"'";
        }

        #endregion
    }
}
