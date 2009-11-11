using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetOtherPaperJudgeMembers:ISql
    {
        private string _studentID;

        public SqlGetOtherPaperJudgeMembers(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select Name from ThesisJudgeInfo as tj inner join Teacher as t on t.TeacherID=tj.TeacherID where StudentID='"+_studentID+"' and IsLeader=0";
        }

        #endregion
    }
}
