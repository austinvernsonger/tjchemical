using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllTeacherInfo:ISql
    {
        public SqlGetAllTeacherInfo()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select t.TeacherID,t.Name from Teacher as t left join TeacherOrdinary as td on t.TeacherID=td.TeacherID left join TeacherExternal as te on te.TeacherID= t.TeacherID";
        }

        #endregion
    }
}
