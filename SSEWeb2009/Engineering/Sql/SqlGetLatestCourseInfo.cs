using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetLatestCourseInfo:ISql
    {
        private string _stuid;

        public SqlGetLatestCourseInfo(string stuid)
        {
            _stuid = stuid;
        }


         #region ISql 成员

        public string GetSql()
        {
            return "select distinct * from Course as c inner join Student as s on c.grade = s.grade " +
                            "inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID where s.StudentID ='" + _stuid + "'" +
                            "and c.CourseTime = (select max(CourseTime) from Course)";
        }

        #endregion

        
    }
}
