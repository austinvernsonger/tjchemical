using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetDiscussionByTeacherIDAndQuery:ISql
    {
        private string _teacherID;
        private QueryInfo _qInfo;

        public SqlGetDiscussionByTeacherIDAndQuery(string teacherID, QueryInfo qInfo)
        {
            _teacherID = teacherID;
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "";
            sql =  "select d.*,Name,StudentID,(select count(*)-1 from Discussion as d2 where left(d2.DisplayOrder,len(rtrim(d.DisplayOrder)))=d.DisplayOrder) " +
                    "as ChildCount from Discussion as d inner join Student as s on s.StudentID=left(Communicators,10) where (len(DisplayOrder)/23)=1 " +
                    "and right(Communicators,len(Communicators)-11)='" + _teacherID + "'";
            if (_qInfo.ActivityStatus != -1)
            { 
                sql = sql + " and d.Category = '"+_qInfo.ActivityStatus+"'";
            }
            if (_qInfo.AccountID != null)
            {
                sql = sql + " and s.StudentID='" + _qInfo.AccountID + "'";
            }
            return sql;
        }

        #endregion
    }
}
