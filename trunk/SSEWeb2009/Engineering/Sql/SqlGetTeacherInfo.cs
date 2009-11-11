using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeacherInfo:ISql
    {
        private string studentID;

        public SqlGetTeacherInfo(string stuID)
        {
            studentID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from StudentMSE as sm left join Teacher as t on sm.TeacherID=t.TeacherID "+
                        "left join TeacherOrdinary as td on td.TeacherID=t.TeacherID left join TeacherExternal as te "+
                        "on te.TeacherID=t.TeacherID where sm.StudentID='"+studentID+"'";
        }

        #endregion
    }
}
