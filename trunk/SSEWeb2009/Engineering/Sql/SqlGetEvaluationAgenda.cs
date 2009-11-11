using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetEvaluationAgenda:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetEvaluationAgenda(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "select * from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID=ts.TeaSchoolID where TeaMagType =3";
            if (_qInfo.Time != null)
            {
                sql = sql + " and Term='" + Convert.ToInt32(_qInfo.Time) + "'";
            }
            if (_qInfo.Grade != null)
            {
                sql = sql + " and Grade='" + _qInfo.Grade + "'";
            }
            if (_qInfo.TSchoolID != null)
            {
                sql = sql + " and tm.TeaSchoolID='" + _qInfo.TSchoolID + "'";
            }
            return sql;
        }

        #endregion
    }
}
