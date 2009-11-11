using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetNoLeaderPaperJudge:ISql
    {
        private string _bNo;

        public SqlGetNoLeaderPaperJudge(string bNo)
        {
            _bNo = bNo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Select * from ThesisJudgeInfo as tj inner join Teacher as t on tj.TeacherID=t.TeacherID inner join StudentMSE as sm on sm.StudentID=tj.StudentID where IsLeader=0 and JudgeStatue=1 and BlindReviewNo='"+_bNo+"'";
        }

        #endregion
    }
}
