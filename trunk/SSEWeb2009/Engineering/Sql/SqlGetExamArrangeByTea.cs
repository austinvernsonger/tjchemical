using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetExamArrangeByTea:ISql
    {
        private string _teacherID;

        public SqlGetExamArrangeByTea(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select CourseTime,CourseName,ExamTime,ExamPlace,Supervisor1,Supervisor2 from Course as c  inner join ExamArrangeInfo as ea on ea.CourseID=c.CourseID where  (Supervisor1 = '" + _teacherID + "' or Supervisor2='" + _teacherID + "') and c.CourseTime = (select max(CourseTime) from ExamResultInfo as e inner join Course as c1 on c1.CourseID = e.CourID where IsOpened=1) ";
        }

        #endregion
    }
}
