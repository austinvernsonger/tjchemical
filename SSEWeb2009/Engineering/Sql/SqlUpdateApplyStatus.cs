using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateApplyStatus:ISql
    {
        private string _stuid;
        private int _status;
        private string _reason;

        public SqlUpdateApplyStatus(string stuid, int status, string reason)
        {
            _stuid = stuid;
            _status = status;
            _reason = reason;
        }

        #region ISql 成员

        public string GetSql()
        {
            if (_reason != "")
            {
                return "update DefenceApplicationStatus Set IsAnswered='" + _status + "', Reason='" + _reason + "' where StudentID='" + _stuid + "'";
            }
            else
            {
                return "update DefenceApplicationStatus Set IsAnswered='" + _status + "' where StudentID='" + _stuid + "'";
            }
        }

        #endregion

    }
}
