using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteCourseTeacherByCourseID:ISql
    {

        private int _courseid;

        public SqlDeleteCourseTeacherByCourseID(int courseid)
        {
            _courseid = courseid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from Teacher_Course where CourseID = '" + _courseid + "'";
        }

        #endregion
    }
}
