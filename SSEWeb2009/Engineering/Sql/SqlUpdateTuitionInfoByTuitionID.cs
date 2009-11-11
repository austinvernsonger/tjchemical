using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTuitionInfoByTuitionID:ISql
    {
        private TuitionInfo _tInfo;

        public SqlUpdateTuitionInfoByTuitionID(TuitionInfo tInfo)
        {
            _tInfo = tInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            if (_tInfo.Remark != null)
            {
                return "update TuitionInfo Set ActualMoney='" + _tInfo.ActualMoney + "',MustMoney='" + _tInfo.MustMoney + "', Remark='"+_tInfo.Remark+"' where TuitionID='" + _tInfo.TuitionID + "'";
            }
            else
            {
                return "update TuitionInfo Set ActualMoney='" + _tInfo.ActualMoney + "',MustMoney='" + _tInfo.MustMoney + "' where TuitionID='" + _tInfo.TuitionID + "'";
            }
        }

        #endregion
    }
}
