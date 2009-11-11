using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStatusAppInfoByAppID:ISql
    {
        private int _applyID;

        public SqlGetStatusAppInfoByAppID(int applyID)
        {
            _applyID = applyID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select *,t.Name as tName from StuStatusChangeInfo as ssc inner join Student as s on ssc.StuID = s.StudentID " +
                     "inner join StudentMSE as sm on s.StudentID=sm.StudentID inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID " +
                     "left join Teacher as t on t.TeacherID=sm.TeacherID where ssc.StuStatusID='" + _applyID + "'";
        }

        #endregion
    }
}
