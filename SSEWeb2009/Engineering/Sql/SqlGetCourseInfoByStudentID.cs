using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseInfoByStudentID:ISql
    {
        private string _studentID;

        public SqlGetCourseInfoByStudentID(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID  "+
                        "inner join Student as s on e.StuID=s.StudentID inner join StudentMSE as sm on "+
                        "sm.StudentID = s.StudentID inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID "+
                        "where e.StuID = '"+_studentID+"' and IsOpened=1 order by c.CourseTime asc";
        }

        #endregion
    }
}
