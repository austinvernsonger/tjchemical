using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDelCourseForStudByCourseID:ISql
    {
        private int _courseID;

        public SqlDelCourseForStudByCourseID(int courseID)
        {
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from ExamResultInfo where CourID = '" + _courseID + "'";
        }

        #endregion
    }
}
