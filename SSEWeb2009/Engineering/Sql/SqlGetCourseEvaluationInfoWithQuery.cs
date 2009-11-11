using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseEvaluationInfoWithQuery : ISql
    {
        private QueryInfo _qInfo;

        public SqlGetCourseEvaluationInfoWithQuery(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "";
            sql = "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID inner join TeachingManageInfo as tm on (tm.Grade=c.Grade and tm.TeaSchoolID=ts.TeaSchoolID and tm.Term=c.CourseTime) where c.CourseID in (select CourID from ExamResultInfo where IsOpened=1) and tm.TeaMagType=3 ";
            if (_qInfo.Grade != null)
            {
                sql = sql + " and c.Grade ='" + _qInfo.Grade + "'";
            }
            if (_qInfo.TSchoolID != null)
            {
                sql = sql + " and c.TeaSchoolID='" + _qInfo.TSchoolID + "'";
            }
            if (_qInfo.Time != null)
            {
                sql = sql + " and c.CourseTime='" + Convert.ToInt32(_qInfo.Time) + "'";
            }
            return sql + " order by CourseTime desc";
        }

        #endregion
    }
}
