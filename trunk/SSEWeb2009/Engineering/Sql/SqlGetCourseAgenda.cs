using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseAgenda:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetCourseAgenda(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "select * from Course as c left join TeachingManageInfo as tm on c.Grade=tm.Grade and c.TeaSchoolID=tm.TeaSchoolID and c.CourseTime=tm.Term left join TeachingSchoolInfo as ts on tm.TeaSchoolID=ts.TeaSchoolID where TeaMagType=1";
            if (_qInfo.Time != null)
            {
                sql = sql + " and Term='" + Convert.ToInt32(_qInfo.Time) + "'";
            }
            if(_qInfo.Grade != null)
            {
                sql = sql + " and c.Grade='"+_qInfo.Grade+"'";
            }
            if(_qInfo.TSchoolID != null)
            {
                sql = sql + " and tm.TeaSchoolID='" + _qInfo.TSchoolID + "'";
            }
            return sql;
        }

        #endregion
    }
}
