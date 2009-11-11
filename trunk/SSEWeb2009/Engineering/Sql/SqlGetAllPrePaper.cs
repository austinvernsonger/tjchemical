using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllPrePaper:ISql
    {
        private string _teacherID;

        public SqlGetAllPrePaper(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
           return  "select * from ThesisJudgeInfo as tj inner join StudentMSE as sm on sm.StudentID=tj.StudentID inner join AttachmentInfo as a on sm.StudentID =a.CreateByUser where a.Category = 5 and tj.TeacherID='" + _teacherID + "' and JudgeStatue=0";
        }

        #endregion
    }
}
