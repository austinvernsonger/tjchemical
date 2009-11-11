using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseListByGT : ISql
    {
        private string _grade;
        private int _teaSchoolID;

        public SqlGetCourseListByGT(string grade, int teaSchoolID)
        {
            _grade = grade;
            _teaSchoolID = teaSchoolID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select c.CourseID, c.CourseName, Name, ExamMode, ExamStTime " +
                   "from Course as c left outer join Teacher_Course as tc on c.CourseID=tc.CourseID " +
                   "left outer join Teacher as t on tc.TeacherID=t.TeacherID " +
                   "left outer join ExamArrangeInfo as ea on c.CourseID=ea.CourID " +
                   "where Grade = '" + _grade + "' and TeaSchoolID = '" + _teaSchoolID + "' " +
                   "order by c.CourseID asc";
        }

        #endregion
    }
}
