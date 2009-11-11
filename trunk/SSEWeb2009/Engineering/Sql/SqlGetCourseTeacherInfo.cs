using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseTeacherInfo:ISql
    {
        private int _courseID;

        public SqlGetCourseTeacherInfo(int courseId)
        {
            _courseID = courseId;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c left join Teacher_Course as tc on c.CourseID = tc.CourseID left join Teacher as t on tc.TeacherID = t.TeacherID where c.CourseID='"+_courseID+"'";
        }

        #endregion
    }
}
