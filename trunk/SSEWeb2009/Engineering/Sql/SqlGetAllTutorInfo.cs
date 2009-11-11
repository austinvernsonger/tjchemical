using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllTutorInfo:ISql
    {
        public SqlGetAllTutorInfo()
        { 
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select UserID,UserName from Users as u inner join UserRoles as ur on u.UserID=ur.UseId where ur.RoleID=3";
        }

        #endregion
    }
}
