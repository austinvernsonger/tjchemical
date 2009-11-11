using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateCourseStudentNum:ISql
    {
        private int _courseID;

        public SqlUpdateCourseStudentNum(int courseID)
        {
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update Course Set StudentNumber=StudentNumber+1 where CourseID='" + _courseID + "'";
        }

        #endregion
    }
}
