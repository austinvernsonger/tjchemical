using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStudentsByteaIdWithNoneQuery:ISql
    {
        private string _teacherID;

        public SqlGetStudentsByteaIdWithNoneQuery(string teacherID)
        {
            _teacherID = teacherID;
        }

        public string GetSql()
        {
            return "select distinct s.StudentID, s.Name, s.Gender, s.Grade, t.TeaSchoolName, s.Degree from StudentMSE as sm " +
                    "inner join Student as s on s.StudentID = sm.StudentID inner join TeachingSchoolInfo as t on t.TeaSchoolID=sm.TeaSchoolID " +
                    "where TeacherID = '" + _teacherID + "'";
        }
    }
}
