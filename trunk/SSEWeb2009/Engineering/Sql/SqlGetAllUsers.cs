using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllUsers:ISql
    {
        public SqlGetAllUsers()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select UserID,UserName from Users as u inner join Teacher as t on t.TeacherID = u.UserID ";
        }

        #endregion
    }
}
