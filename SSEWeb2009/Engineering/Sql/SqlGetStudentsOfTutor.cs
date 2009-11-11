using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStudentsOfTutor : ISql
    {
        private string _teacherID = null;

        public SqlGetStudentsOfTutor(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select s.StudentID, s.Name, Gender, Grade, TeaSchoolName, Degree from Student as s inner join " +
                "StudentMSE as se on s.StudentID = se.StudentID inner join " +
                "TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID " +
                "where TeacherID = '"+ _teacherID +"'";
        }

        #endregion
    }
}
