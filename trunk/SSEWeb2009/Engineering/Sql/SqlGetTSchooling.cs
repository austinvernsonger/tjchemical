using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTSchooling:ISql
    {
        private string selectedValue;

        public SqlGetTSchooling(string selValue)
        {
            selectedValue = selValue;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct t.TeaSchoolName,t.TeaSchoolID from TeachingSchoolInfo as t inner join StudentMSE as se on t.TeaSchoolID = se.TeaSchoolID inner join Student as s on se.StudentID = s.StudentID where s.Grade = '" + selectedValue + "'";
        }

        #endregion
    }
}
