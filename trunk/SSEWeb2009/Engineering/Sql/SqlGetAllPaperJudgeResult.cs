using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllPaperJudgeResult:ISql
    {
        public SqlGetAllPaperJudgeResult()
        { 
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select *,sm.TeacherID as sTeacherID from ThesisJudgeInfo as tj inner join StudentMSE as sm on tj.StudentID=sm.StudentID "+
                        "inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID inner join Student as s on "+
                        "s.StudentID = sm.StudentID where IsLeader=1 order by JudgeTime desc";
        }

        #endregion
    }
}
