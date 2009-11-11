using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetDefenceApplyByTeaID:ISql
    {
        private string _teacherID;

        public SqlGetDefenceApplyByTeaID(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct s.StudentID,* from DefenceApplicationStatus as da inner join StudentMSE as sm on da.StudentID = sm.StudentID inner join Student as s on s.StudentID=sm.StudentID where IsAnswered=0 and sm.TeacherID='" + _teacherID + "'";
        }

        #endregion
    }
}
