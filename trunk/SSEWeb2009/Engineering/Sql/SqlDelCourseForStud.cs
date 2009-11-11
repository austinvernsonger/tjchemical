using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDelCourseForStud:ISql
    {
        private int courseID;
        private string studentID = null;

        public SqlDelCourseForStud(int courId, string stuId)
        {
            courseID = courId;
            studentID = stuId;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from ExamResultInfo where CourID = '" + courseID + "' and StuID='"+studentID+"'";
        }

        #endregion
    }
}
