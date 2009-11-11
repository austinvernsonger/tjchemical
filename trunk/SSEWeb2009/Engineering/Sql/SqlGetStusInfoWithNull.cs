using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStusInfoWithNull:ISql
    {
        public SqlGetStusInfoWithNull()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select s.StudentID, s.Name as sName, s.Gender as sGender, Degree, Grade, TeaSchoolName, t.Name as tName from Student as s inner join " +
                "StudentMSE as se on s.StudentID = se.StudentID inner join " +
                "TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID left join Teacher as t on t.TeacherID=se.TeacherID order by left(s.Grade,4) desc";
        }
        #endregion
    }
}
