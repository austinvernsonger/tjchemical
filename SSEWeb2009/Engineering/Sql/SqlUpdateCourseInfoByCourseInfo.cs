using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{

    class SqlUpdateCourseInfoByCourseInfo:ISql
    {
        private CourseInfo _cInfo;

        public SqlUpdateCourseInfoByCourseInfo(CourseInfo cInfo)
        {
            _cInfo = cInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "update Course set CourseName = '" + _cInfo.CourseName + "'";
            if (_cInfo.Credit != -1)
            {
                sql = sql + " ,Credit='" + _cInfo.Credit + "'";
            }
            if (_cInfo.CreditHour != -1)
            {
                sql = sql + " ,CreditHour='" + _cInfo.CreditHour + "'";
            }
            if (_cInfo.Property != -1)
            {
                sql = sql + " ,Property='"+_cInfo.Property+"'";
            }
            if (_cInfo.Category != -1)
            {
                sql = sql + ",Category='"+_cInfo.Category+"'";
            }
            if (_cInfo.ClassPeriod != null)
            {
                sql = sql + ",ClassPeriod='"+_cInfo.ClassPeriod+"'";
            }
            if (_cInfo.Place != null)
            {
                sql = sql + ",Place='"+_cInfo.Place+"'";
            }
            return sql + " where CourseID='" + _cInfo.CourseID + "'";
        }

        #endregion
    }
}
