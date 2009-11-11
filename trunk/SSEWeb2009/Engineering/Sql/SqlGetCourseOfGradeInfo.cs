using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseOfGradeInfo:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetCourseOfGradeInfo(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID where c.CourseID in (select CourID from ExamResultInfo where IsOpened=1) ";
            if (_qInfo.Grade != null)
            {
                sql = sql + " and Grade ='" + _qInfo.Grade + "'";
            }
            if (_qInfo.TSchoolID != null)
            {
                sql = sql + " and c.TeaSchoolID='" + _qInfo.TSchoolID + "'";
            }
            if (_qInfo.Time != null)
            {
                sql = sql + " and CourseTime='" + Convert.ToInt32(_qInfo.Time) + "'";
            }
            return sql;
        }

        #endregion

        
    }
}
