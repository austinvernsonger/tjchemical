using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseTimeBystuId:ISql
    {
        private string studentID;

        public SqlGetCourseTimeBystuId(string stuID)
        {
            studentID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct CourseTime from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID where e.StuID = '"+studentID+"' order by CourseTime desc ";
        }

        #endregion
    }
}
