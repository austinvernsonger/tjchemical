using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTutorsInfoList : ISql
    {
        public SqlGetTutorsInfoList()
        {
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Teacher as t left join TeacherOrdinary as tr on t.TeacherID = tr.TeacherID left join TeacherExternal as te on te.TeacherID=t.TeacherID "+
                        "inner join Users as u on u.UserID = t.TeacherID inner join UserRoles as ur on u.UserID = ur.UseId where ur.RoleID = 3";
        }

        #endregion
    }
}

