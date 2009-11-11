using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeacherInfoByteacherID:ISql
    {
        private string _teacherID;

        public SqlGetTeacherInfoByteacherID(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Teacher as t left join TeacherOrdinary as tr on t.TeacherID = tr.TeacherID left join TeacherExternal as te on te.TeacherID=t.TeacherID where t.TeacherID = '" + _teacherID + "'";
        }

        #endregion
    }
}
