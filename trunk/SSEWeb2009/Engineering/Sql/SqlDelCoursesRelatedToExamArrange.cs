using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDelCoursesRelatedToExamArrange:ISql
    {
        private int _courseID;

        public SqlDelCoursesRelatedToExamArrange(int courseID)
        {
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from ExamArrangeInfo where CourseID = '" + _courseID + "'";
        }

        #endregion
    }
}
