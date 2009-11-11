using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetExamArrangeByStu:ISql
    {
        private string _stuid;

        public SqlGetExamArrangeByStu(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select CourseTime,CourseName,ExamTime,ExamPlace,Supervisor1,Supervisor2 from ExamResultInfo as e inner join Course as c on e.CourID = c.CourseID inner join ExamArrangeInfo as ea on ea.CourseID=c.CourseID where StuID = '" + _stuid + "' and e.IsOpened=1 and c.CourseTime = (select max(CourseTime) from Course)";
        }

        #endregion
    }
}
