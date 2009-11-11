using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTestArrangeByQuery:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetTestArrangeByQuery(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "select * from ExamArrangeInfo as ea inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=ea.TeaSchoolID where 1=1";
            if (_qInfo.Grade != null)
            {
                sql = sql + " and Grade='" + _qInfo.Grade + "'";
            }
            if (_qInfo.TSchoolID != null)
            {
                sql = sql + " and ts.TeaSchoolID='" + _qInfo.TSchoolID + "'";
            }
            if (_qInfo.Time != null)
            {
                sql = sql +" and Term='"+Convert.ToInt32(_qInfo.Time )+"'";
            }
            return sql;
        }

        #endregion
    }
}
