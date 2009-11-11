using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStuApplyStatus:ISql
    {
        private string _stuid;

        public SqlGetStuApplyStatus(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from DefenceApplicationStatus where StudentID='" + _stuid + "'";
        }

        #endregion
    }
}
