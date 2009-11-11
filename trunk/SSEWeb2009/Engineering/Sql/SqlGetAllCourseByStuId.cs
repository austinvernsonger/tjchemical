using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllCourseByStuId:ISql
    {
        private string studentID;

        public SqlGetAllCourseByStuId(string stuID)
        {
            studentID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select c.*, TeacherID from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID join Teacher_Course as t on t.CourseID=c.CourseID where e.StuID = '" + studentID + "' order by CourseTime desc";
        }

        #endregion
    }
}
