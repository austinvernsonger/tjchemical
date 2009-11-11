using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseChoosingNum:ISql
    {
        private int _courseID;

        public SqlGetCourseChoosingNum(int courseID)
        {
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select Count(CourID) as num ,CourID from ExamResultInfo where CourID='"+_courseID+"' group by CourID";
        }

        #endregion
    }
}
