using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStdsOfTutor : ISql
    {
        private string _teacherID;

        public SqlGetStdsOfTutor(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select sm.StudentID,Name,Gender,Grade,TeaSchoolName,Degree " + 
                "from StudentMSE as sm inner join Student as s on sm.StudentID=s.StudentID " + 
                "inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID " + 
                "where TeacherID='"+ _teacherID +"' " +
                "order by Grade desc";
        }

        #endregion
    }
}
