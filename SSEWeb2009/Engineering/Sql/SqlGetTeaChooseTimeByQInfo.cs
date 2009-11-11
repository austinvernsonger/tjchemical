using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeaChooseTimeByQInfo:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetTeaChooseTimeByQInfo(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "select distinct * from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID = ts.TeaSchoolID where TeaMagType=2";
            if (_qInfo.Grade != null)
            {
                sql = sql + " and Grade='" + _qInfo.Grade + "'";
            }
            if (_qInfo.TSchoolID != null)
            {
                sql = sql + " and ts.TeaSchoolID='"+_qInfo.TSchoolID+"'";
            }
            return sql;
        }

        #endregion
    }
}
