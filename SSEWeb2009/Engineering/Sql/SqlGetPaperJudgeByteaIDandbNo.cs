using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetPaperJudgeByteaIDandbNo:ISql
    {
        private string _teacherid;
        private string _bNo;

        public SqlGetPaperJudgeByteaIDandbNo(string teacherid, string bNo)
        {
            _teacherid = teacherid;
            _bNo = bNo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from ThesisJudgeInfo as tj inner join Teacher as t on t.TeacherID=tj.TeacherID inner join StudentMSE as sm on sm.StudentID = tj.StudentID where t.TeacherID='" + _teacherid + "' and BlindReviewNo='"+_bNo+"'";
        }

        #endregion
    }
}
