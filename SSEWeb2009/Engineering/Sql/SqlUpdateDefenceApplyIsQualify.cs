using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateDefenceApplyIsQualify:ISql
    {
        private string _stuid;

        public SqlUpdateDefenceApplyIsQualify(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update DefenceApplicationStatus Set IsQualified=1 where StudentID='"+_stuid+"'";
        }

        #endregion
    }
}
