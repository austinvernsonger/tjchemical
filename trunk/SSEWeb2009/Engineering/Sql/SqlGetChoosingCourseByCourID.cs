using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetChoosingCourseByCourID:ISql
    {
        private int _courseID;

        public SqlGetChoosingCourseByCourID(int courseID)
        {
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct s.StudentID, *  from Student as s inner join StudentMSE as sm on s.StudentID=sm.StudentID " +
                    "inner join TeachingSchoolInfo as ts on ts.TeaSchoolID = sm.TeaSchoolID inner join ExamResultInfo as e on e.StuID = s.StudentID "+
                    "inner join Course as c on c.CourseID=e.CourID where c.CourseID='"+_courseID+"'";
        }

        #endregion
    }
}
