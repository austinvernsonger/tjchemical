using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetExamResByStuID:ISql
    {
        private string studentID;

        public SqlGetExamResByStuID(string stuId)
        {
            studentID = stuId;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct c.CourseID,* from ExamResultInfo as e inner join Course as c on e.CourID = c.CourseID "+
                    "left  join ExamArrangeInfo as ea on ea.CourseID=c.CourseID inner join Student as s on "+
                    "s.StudentID=e.StuID inner join StudentMSE as sm on sm.StudentID=s.StudentID inner join "+
                    "TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID where StuID = '" + studentID + "' and IsOk=1 and IsOpened=1 and CourResult is not null order by CourseTime asc";
        }

        #endregion
    }
}
