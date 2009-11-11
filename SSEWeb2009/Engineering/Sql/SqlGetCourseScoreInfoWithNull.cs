using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseScoreInfoWithNull : ISql
    {
        public SqlGetCourseScoreInfoWithNull()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return  "select * from Course as c inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=c.TeaSchoolID where c.CourseID in (select CourID from ExamResultInfo where IsOpened=1) order by CourseTime desc";
        }

        #endregion
    }
}
