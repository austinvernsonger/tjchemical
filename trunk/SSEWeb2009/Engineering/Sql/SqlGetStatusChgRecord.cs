using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlGetStatusChgRecord : ISql
    {
        private QueryInfo _qInfo;

        public SqlGetStatusChgRecord(QueryInfo qInfo)
        {
            _qInfo = qInfo;
            
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "select * from StuStatusChangeInfo as sc inner join " +
                "StudentMSE as se on sc.StuID = se.StudentID inner join " +
                "Student as s on s.StudentID = se.StudentID inner "+
                "join TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID " +
                "where 1=1";
            if (_qInfo.SchoolStatus != null)
            {
                sql = sql + " and ApplyCategory='"+ _qInfo.SchoolStatus+"'" ;
            }
            if (_qInfo.ActivityStatus == 1)
            {
                sql = sql + " and sc.Activiy = 0";
            }
            else if (_qInfo.ActivityStatus == 2)
            {
                sql = sql + " and sc.Activiy != 0";
            }
           
            return sql;
        }
        #endregion

    }
    
}
