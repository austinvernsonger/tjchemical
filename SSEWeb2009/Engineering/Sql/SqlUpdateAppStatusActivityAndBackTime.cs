using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateAppStatusActivityAndBackTime:ISql
    {
        private int _applyID;

        public SqlUpdateAppStatusActivityAndBackTime(int applyID)
        {
            _applyID = applyID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update StuStatusChangeInfo Set Activiy=1,BackTime='"+System.DateTime.Now+"' where StuStatusID = '" + _applyID + "'";
        }

        #endregion
    }
}
