using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddExamArrangement:ISql
    {
        private TestInfo _tInfo;

        public SqlAddExamArrangement(TestInfo tInfo)
        {
            _tInfo = tInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "insert into ExamArrangeInfo(CourseID, ExamPlace, ExamTime";
            if (_tInfo.Supervisor1 != null && _tInfo.Supervisor2 == null)
            {
                sql = sql + ", Supervisor1) values('" + _tInfo.CourseID + "','" + _tInfo.TestPlace + "','" + _tInfo.TestTime + "','" + _tInfo.Supervisor1 + "')";
            }
            if (_tInfo.Supervisor1 == null && _tInfo.Supervisor2 != null)
            {
                sql = sql + ", Supervisor2) values('" + _tInfo.CourseID + "','" + _tInfo.TestPlace + "','" + _tInfo.TestTime + "','" + _tInfo.Supervisor2 + "')";
            }
            if (_tInfo.Supervisor1 != null && _tInfo.Supervisor2 != null)
            {
                sql = sql + ", Supervisor1, Supervisor2) values('" + _tInfo.CourseID + "','" + _tInfo.TestPlace + "','" + _tInfo.TestTime + "','" + _tInfo.Supervisor1 + "','" + _tInfo.Supervisor2 + "')";
            }
            else
            {
                sql = sql + ") values('" + _tInfo.CourseID + "','" + _tInfo.TestPlace + "','" + _tInfo.TestTime + "')";
            }
            return sql;
        }

        #endregion
    }
}
