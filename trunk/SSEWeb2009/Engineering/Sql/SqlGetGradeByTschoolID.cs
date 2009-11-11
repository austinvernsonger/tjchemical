using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlGetGradeByTschoolID : ISql
    {
        private int teaSchoolID;

        public SqlGetGradeByTschoolID(int TschoolID)
        {
            teaSchoolID = TschoolID;
        }

        #region Sql成员

        public string GetSql()
        {
            return "select distinct Grade from Student as s inner join StudentMSE as se on s.StudentID=se.StudentID where TeaSchoolID = '"+ teaSchoolID +"'";
        }

        #endregion
    }
}
