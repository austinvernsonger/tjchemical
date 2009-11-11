using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlupdateCourseOpened:ISql
    {
        private int _courseID;

        public SqlupdateCourseOpened(int courseID)
        {
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update ExamResultInfo Set IsOpened=1 where CourID='" + _courseID + "'";
        }

        #endregion
    }
}
