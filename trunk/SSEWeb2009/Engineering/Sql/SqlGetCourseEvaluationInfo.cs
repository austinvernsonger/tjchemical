using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseEvaluationInfo:ISql
    {
        public SqlGetCourseEvaluationInfo()
        { }
         #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID inner join TeachingManageInfo as tm on (tm.Grade=c.Grade and tm.TeaSchoolID=ts.TeaSchoolID and tm.Term=c.CourseTime) where c.CourseID in (select CourID from ExamResultInfo where IsOpened=1) and tm.TeaMagType=3 order by CourseTime desc";
        }

        #endregion
        
    }
}
