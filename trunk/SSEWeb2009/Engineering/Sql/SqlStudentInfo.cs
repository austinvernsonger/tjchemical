using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlStudentInfo : ISql
    {
        private string stuId;

        public SqlStudentInfo(string studentId)
        {
            stuId = studentId;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "SELECT b.*,e.*, t.Name as tName, TeaSchoolName FROM Student as b INNER JOIN StudentMSE as e ON b.StudentID = e.StudentID inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=e.TeaSchoolID left join Teacher as t on e.TeacherID=t.TeacherID  where b.StudentID ='" + stuId + "'";
        }

        #endregion

    }
}
