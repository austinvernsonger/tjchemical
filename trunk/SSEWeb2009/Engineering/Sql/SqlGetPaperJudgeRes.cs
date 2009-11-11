using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetPaperJudgeRes:ISql
    {
        private string _stuid;

        public SqlGetPaperJudgeRes(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Select * from ThesisJudgeInfo where StudentID='" + _stuid + "' and IsLeader=1 and JudgeStatue=1";
        }

        #endregion
    }
}
