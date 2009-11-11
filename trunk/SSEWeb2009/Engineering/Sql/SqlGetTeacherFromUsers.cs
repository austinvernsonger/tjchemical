using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeacherFromUsers:ISql
    {
        public SqlGetTeacherFromUsers()
        { }

        #region ISql 成员

        public string GetSql()
        {
            //返回角色为教师和导师的用户
            return "select UserID,UserName from Users as u inner join UserRoles as ur on ur.UseId=u.UserID where RoleID=2 or RoleID=3";
        }

        #endregion
    }
}
