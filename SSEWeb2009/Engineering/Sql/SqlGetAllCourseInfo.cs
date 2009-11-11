using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllCourseInfo:ISql
    {
        public SqlGetAllCourseInfo()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID order by c.CourseTime desc, left(Grade,4) desc ";
        }

        #endregion
    }
}
