using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeachersNotCurrentRole:ISql
    {
        private int _roleID;

        public SqlGetTeachersNotCurrentRole(int roleID)
        {
            _roleID = roleID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Teacher as t left join TeacherOrdinary as tr on t.TeacherID = tr.TeacherID left join TeacherExternal as te on te.TeacherID=t.TeacherID where t.TeacherID not in (select UserID from Users as u inner join UserRoles as ur on ur.UseId=u.UserID where ur.RoleID='"+_roleID+"')";
        }

        #endregion
    }
}
