using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseTeacherByCourseID:ISql
    {
        private int _courseid;

        public SqlGetCourseTeacherByCourseID(int courseid)
        {
            _courseid = courseid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Teacher_Course where CourseID='"+_courseid+"'";
        }

        #endregion
    }
}
