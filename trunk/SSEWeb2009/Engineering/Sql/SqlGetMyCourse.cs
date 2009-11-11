using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetMyCourse:ISql
    {
        private string _studentID;

        public SqlGetMyCourse(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID where e.StuID = '" + _studentID + "' and IsOpened=1 and c.CourseTime = (select max(CourseTime) from Course)";
        }

        #endregion
    }
}
