using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTuitionInfoByTuitionID:ISql
    {
        private int _tuitionID;

        public SqlGetTuitionInfoByTuitionID(int tuitionID)
        { 
            _tuitionID = tuitionID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select t.StuID, * from TuitionInfo as t inner join " +
                            "StudentMSE as se on t.StuID = se.StudentID inner join " +
                            "Student as s on s.StudentID = se.StudentID inner join " +
                            "TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID where TuitionID='"+_tuitionID+"'";
        }

        #endregion 
    }
}
