using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddCourseTeacher:ISql
    {
        private int _courseid;
        private string _teacherid;

        public SqlAddCourseTeacher(int courseid, string teacherid)
        {
            _courseid = courseid;
            _teacherid = teacherid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into Teacher_Course(TeacherID, CourseID) values('"+_teacherid+"','"+_courseid+"')";
        }

        #endregion
    }
}
