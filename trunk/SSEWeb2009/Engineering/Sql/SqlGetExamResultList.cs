using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlGetExamResultList : ISql
    {
        private int _CourseID;

        public SqlGetExamResultList(int CourseID)
        {
            _CourseID = CourseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select e.StuID, s.Name, t.Name, CourResult from ExamResultInfo as e inner join " +
                   "Student as s on e.StuID=s.StudentID inner join " +
                   "Teacher_Course as tc on tc.CourseID=e.CourID inner join " +
                   "Teacher as t on t.TeacherID=tc.TeacherID " +
                   "where e.CourID = '"+ _CourseID +"' " +
                   "order by e.StuID asc";
        }

        #endregion
    }
}
