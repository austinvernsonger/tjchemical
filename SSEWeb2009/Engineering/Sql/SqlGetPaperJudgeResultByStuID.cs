using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetPaperJudgeResultByStuID:ISql
    {
        private string _studentID;

        public SqlGetPaperJudgeResultByStuID(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select *,t.Name as tName from ThesisJudgeInfo as tj inner join StudentMSE as sm on tj.StudentID=sm.StudentID " +
                        "inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID inner join Student as s on " +
                        "s.StudentID = sm.StudentID inner join Teacher as t on tj.TeacherID=t.TeacherID where tj.StudentID='" + _studentID + "' and IsLeader=1";
        }

        #endregion
    }
}
