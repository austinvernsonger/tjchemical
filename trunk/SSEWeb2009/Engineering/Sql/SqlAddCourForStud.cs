using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddCourForStud:ISql
    {
        private int courseID;
        private string studentID;

        public SqlAddCourForStud(int courId, string stuId)
        {
            courseID = courId;
            studentID = stuId;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into ExamResultInfo(CourID,StuID) values('"+courseID+"','"+studentID+"')";
        }

        #endregion
    }
}
