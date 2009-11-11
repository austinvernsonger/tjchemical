using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateDefenceApply:ISql
    {
        private string _studentID;
        private int _res;
        private string _reason;

        public SqlUpdateDefenceApply(string studentID,int res, string reason)
        {
            _studentID = studentID;
            _res = res;
            _reason = reason;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update DefenceApplicationStatus Set IsQualified='" + _res + "', Reason='" + _reason + "' where StudentID='" + _studentID + "'";
        }

        #endregion
    }
}
