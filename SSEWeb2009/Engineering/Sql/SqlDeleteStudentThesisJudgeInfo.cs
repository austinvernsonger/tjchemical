using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentThesisJudgeInfo:ISql
    {
        private string _studentID;

        public SqlDeleteStudentThesisJudgeInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from ThesisJudgeInfo where StudentID ='" + _studentID + "'";
        }

        #endregion
    }
}
