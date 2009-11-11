using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetDetailedScoreByStuID:ISql
    {
        private string _stuID;

        public SqlGetDetailedScoreByStuID(string stuID)
        {
            _stuID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID "+
                    "inner join Student as s on s.StudentID=e.StuID inner join StudentMSE as sm on sm.StudentID=s.StudentID "+
                    "inner join TeachingSchoolInfo as tsi on tsi.TeaSchoolID=sm.TeaSchoolID where e.StuID = '"+_stuID+"' order by CourseTime desc";
        }

        #endregion
    }
}
