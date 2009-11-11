using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseFromExamByqInfo:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetCourseFromExamByqInfo(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            //string sql = "select distinct CourID, c.CourseName, c.CourseTime,StudentNumber,* from ExamResultInfo as e inner join Course as c on c.CourseID=e.CourID inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=c.TeaSchoolID  where IsOpened=1";
            string sql = "select * from Course as c inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=c.TeaSchoolID where c.CourseID in (select CourID from ExamResultInfo where IsOpened=1) ";
            if (_qInfo.Grade != null)
            {
                sql = sql + " and c.Grade = '"+_qInfo.Grade+"'";
            }
            if (_qInfo.TSchoolID != null)
            {
                sql = sql + " and c.TeaSchoolID = '" + _qInfo.TSchoolID + "'";
            }
            if (_qInfo.Time != null)
            {
                sql = sql + " and CourseTime='"+Convert.ToInt32(_qInfo.Time)+"'";
            }
            return sql;
        }

        #endregion
    }
}
