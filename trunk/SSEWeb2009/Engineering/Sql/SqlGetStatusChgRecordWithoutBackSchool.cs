using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStatusChgRecordWithoutBackSchool:ISql
    {
        public SqlGetStatusChgRecordWithoutBackSchool()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from StuStatusChangeInfo as sc inner join " +
                "StudentMSE as se on sc.StuID = se.StudentID inner join " +
                "Student as s on s.StudentID = se.StudentID inner " +
                "join TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID " +
                "where sc.Activiy = 0";
        }
        #endregion

    }
}
