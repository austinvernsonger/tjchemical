using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTSchoolStatusList : ISql
    {
        private int _teaSchoolID;
        private string _grade;

        public SqlGetTSchoolStatusList(int teaSchoolID, string grade)
        {
            _teaSchoolID = teaSchoolID;
            _grade = grade;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select s.StudentID,s.Name,ApplyCategory from Student as s inner join "+ 
                    "StudentMSE as sm on s.StudentID=sm.StudentID left outer join StuStatusChangeInfo as sc on sc.StuID=s.StudentID "+
                    "where Grade = '"+ _grade +"' and TeaSchoolID = '"+ _teaSchoolID +"'";
        }

        #endregion 
    }
}
