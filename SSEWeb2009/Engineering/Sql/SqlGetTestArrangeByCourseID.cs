using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTestArrangeByCourseID:ISql
    {
        private int _courseID;

        public SqlGetTestArrangeByCourseID(int courserID)
        {
            _courseID = courserID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from ExamArrangeInfo where CourseID='"+_courseID+"'";
        }

        #endregion
    }
}
