using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCurrentSuperAdmin:ISql
    {
        public SqlGetCurrentSuperAdmin() { }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Users as u inner join UserRoles as ur on u.UserID = ur.UseId where RoleID=5";
        }

        #endregion
    }
}
