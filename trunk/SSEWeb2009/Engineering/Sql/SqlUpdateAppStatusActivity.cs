using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateAppStatusActivity:ISql
    {
        private int _applyID;

        public SqlUpdateAppStatusActivity(int applyID)
        {
            _applyID = applyID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update StuStatusChangeInfo Set Activiy=1 where StuStatusID = '" + _applyID + "'";
        }

        #endregion
    }
}
