using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteDefenceApply:ISql
    {
        private string _stuid;

        public SqlDeleteDefenceApply(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from DefenceApplicationStatus where StudentID = '" + _stuid + "'";
        }

        #endregion
    }
}
