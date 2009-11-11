using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetGrade:ISql
    {
        public SqlGetGrade()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct Grade from Student as s inner join StudentMSE as se on s.StudentID=se.StudentID";
        }

        #endregion
    }
}
