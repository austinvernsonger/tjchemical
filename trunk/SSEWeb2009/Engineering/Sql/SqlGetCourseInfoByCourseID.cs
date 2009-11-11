using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseInfoByCourseID:ISql
    {
        private int _courseID;

        public SqlGetCourseInfoByCourseID(int courseID)
        {
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID = ts.TeaSchoolID left join Teacher_Course as tc on tc.CourseID=c.CourseID left join Teacher as t on t.TeacherID=tc.TeacherID where c.CourseID='" + _courseID + "'";
        }

        #endregion
    }
}
