using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTutorChoosingStatus:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetTutorChoosingStatus(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingManageInfo where confirmation=1 and TeaMagType=2 and  Grade='" + _qInfo.Grade + "' and TeaSchoolID='" + _qInfo.TSchoolID + "'";
        }

        #endregion
    }
}
