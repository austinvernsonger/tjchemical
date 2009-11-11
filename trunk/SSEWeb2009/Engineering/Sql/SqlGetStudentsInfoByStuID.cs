using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStudentsInfoByStuID:ISql
    {
        private string _stuID;

        public SqlGetStudentsInfoByStuID(string stuID)
        {
            _stuID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select s.StudentID, s.Name as sName, s.Gender as sGender, Degree, Grade, TeaSchoolName,ts.TeaSchoolID, t.Name as tName, a.Password from Student as s inner join " +
                    "StudentMSE as se on s.StudentID = se.StudentID inner join Account as a on a.AccountID=s.StudentID inner join " +
                    "TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID left join Teacher as t on t.TeacherID=se.TeacherID " +
                    "where s.StudentID='" + _stuID +"'";
        }
        #endregion
    }
}
