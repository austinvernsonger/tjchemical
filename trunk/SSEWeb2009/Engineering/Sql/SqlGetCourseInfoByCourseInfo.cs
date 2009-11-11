using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseInfoByCourseInfo:ISql
    {

        private CourseInfo _cInfo;

        public SqlGetCourseInfoByCourseInfo(CourseInfo cInfo)
        {
            _cInfo = cInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "";
             sql = "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID where 1=1 ";
                    if (_cInfo.Grade != null)
                    {
                        sql = sql + " and Grade ='" + _cInfo.Grade + "'";
                    }
                    if (_cInfo.TeaSchoolID != null)
                    {
                        sql = sql + " and c.TeaSchoolID='" + _cInfo.TeaSchoolID + "'";
                    }
                    if (_cInfo.CourseTime != null)
                    {
                        sql = sql + " and CourseTime='" + Convert.ToInt32(_cInfo.CourseTime) + "'";
                    }
                    if (_cInfo.CourseName != null)
                    {
                        sql = sql + " and CourseName='" + _cInfo.CourseName + "'";
                    }
                    return sql; 
        }

        #endregion
    }
}
