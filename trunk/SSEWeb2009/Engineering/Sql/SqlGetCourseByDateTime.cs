using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseByDateTime:ISql
    {
        private DateTime dTime = new DateTime();

        private string studentID;

        public SqlGetCourseByDateTime(DateTime dt, string stuID)
        {
            dTime = dt;
            studentID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select c.*, TeacherID from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID join Teacher_Course as t on t.CourseID=c.CourseID where e.StuID = '" + studentID + "' and c.CourseTime = '"+dTime+"' ";
        }

        #endregion
    }
}
