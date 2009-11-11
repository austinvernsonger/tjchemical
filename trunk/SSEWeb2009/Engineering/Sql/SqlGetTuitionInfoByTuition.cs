using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTuitionInfoByTuition:ISql
    {
        private TuitionInfo _tInfo;

       public SqlGetTuitionInfoByTuition(TuitionInfo tInfo)
        {
            _tInfo = tInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "select t.StuID, * from TuitionInfo as t inner join " +
                           "StudentMSE as se on t.StuID = se.StudentID inner join " +
                           "Student as s on s.StudentID = se.StudentID inner join " +
                           "TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID " +
                           "where 1=1";
            if (_tInfo.StudID != null)
            {
                sql = sql + " and t.StuID='" + _tInfo.StudID + "'";
            }
            if (_tInfo.TSchoolID != null)
            {
                sql = sql + " and ts.TeaSchoolID='" + _tInfo.TSchoolID + "'";
            }
            if (_tInfo.Grade != null)
            {
                sql = sql + " and Grade='" + _tInfo.Grade + "'";
            }
            if (_tInfo.PaymentTerm != null)
            {
                sql = sql + " and PaymentTerm='" + _tInfo.PaymentTerm + "'";
            }
            return sql + " order by PaymentTime desc";
        }

        #endregion
    }
}
