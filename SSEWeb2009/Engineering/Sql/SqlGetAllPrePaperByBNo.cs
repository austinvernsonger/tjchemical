using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllPrePaperByBNo:ISql
    {
        private string _bNo;

        public SqlGetAllPrePaperByBNo(string bNo)
        {
            _bNo = bNo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from ThesisJudgeInfo as tj inner join Teacher as t on tj.TeacherID = t.TeacherID inner join StudentMSE as sm on sm.StudentID=tj.StudentID inner join AttachmentInfo as a on a.CreateByUser=sm.StudentID where BlindReviewNo='"+_bNo+"' and a.Category=5";
        }

        #endregion
    }
}
