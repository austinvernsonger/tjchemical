using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllCourse:ISql
    {
        private string _stuID;

        public SqlGetAllCourse(string stuID)
        {
            _stuID = stuID;
        }
        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join ExamResultInfo as er on er.CourID = c.CourseID "+
                    "inner join Student as s on s.StudentID=er.StuID inner join StudentMSE as sm on sm.StudentID=s.StudentID "+
                     "inner join TeachingSchoolInfo as tsi on tsi.TeaSchoolID=sm.TeaSchoolID where StuID='" + _stuID + "'";
        }

        #endregion

    }
}
