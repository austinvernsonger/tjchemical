using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetPaperJudgeResultByQueryInfo:ISql
    {
        private QueryInfo _qInfo;

        public SqlGetPaperJudgeResultByQueryInfo(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql= "select *,t.Name as tName from ThesisJudgeInfo as tj inner join StudentMSE as sm on tj.StudentID=sm.StudentID " +
                        "inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID inner join Student as s on " +
                        "s.StudentID = sm.StudentID inner join Teacher as t on tj.TeacherID=t.TeacherID where IsLeader=1";
            if (_qInfo.Grade != null)
            {
                sql = sql + " and s.Grade='" + _qInfo.Grade + "'";
            }
            if (_qInfo.TSchoolID != null)
            { 
                sql = sql +" and sm.TeaSchoolID='"+_qInfo.TSchoolID+"'";
            }
            if(_qInfo.AccountID != null)
            {
                sql = sql + " and s.StudentID='" + _qInfo.AccountID + "'";
            }
            if (_qInfo.ActivityStatus != -1)
            {
                sql = sql + " and IsCriterion='"+(_qInfo.ActivityStatus - 1)+"'";
            }
            return sql;
        }

        #endregion
    }
}
