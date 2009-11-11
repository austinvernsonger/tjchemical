using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTutorAgendaMagStatus:ISql
    {
        private QueryInfo _qInfo;

        public SqlUpdateTutorAgendaMagStatus(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TeachingManageInfo Set confirmation=1 where TeaMagType=2 and Grade='" + _qInfo.Grade + "' and TeaSchoolID='"+_qInfo.TSchoolID+"'";
        }

        #endregion
    }
}
