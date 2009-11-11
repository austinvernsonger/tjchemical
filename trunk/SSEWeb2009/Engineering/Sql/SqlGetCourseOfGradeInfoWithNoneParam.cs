using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseOfGradeInfoWithNoneParam:ISql
    {
        public SqlGetCourseOfGradeInfoWithNoneParam()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID where c.CourseID in (select CourID from ExamResultInfo where IsOpened=1) order by CourseTime desc";
        }

        #endregion
    }
}
