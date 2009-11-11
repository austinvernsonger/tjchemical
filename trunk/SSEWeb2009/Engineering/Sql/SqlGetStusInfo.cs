using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStusInfo:ISql
    {
        private QueryInfo _qInfo;
        private string sql = "";
     

        public SqlGetStusInfo(QueryInfo qInfo)
        {
            _qInfo = qInfo;
            
        }

        #region ISql 成员

        public string GetSql()
        {
            sql = "select s.StudentID, s.Name as sName, s.Gender as sGender, Degree, Grade, TeaSchoolName, t.Name as tName from Student as s inner join " +
                "StudentMSE as se on s.StudentID = se.StudentID inner join " +
                "TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID left join Teacher as t on t.TeacherID=se.TeacherID " +
                "where 1=1";
            if (_qInfo.AccountID != null)
            {
                sql = sql + " and s.StudentID='" + _qInfo.AccountID + "'";
            }
            if (_qInfo.TSchoolID != null)
            {
                sql = sql + " and ts.TeaSchoolID='" + _qInfo.TSchoolID + "'";
            }
            if (_qInfo.Grade != null)
            {
                sql = sql + " and Grade='" + _qInfo.Grade + "'";
            }
            if (_qInfo.Name != null)
            {
                sql = sql + " and s.Name like'%" + _qInfo.Name + "%'";
            }
            return sql;
        }
        #endregion

    }
}
