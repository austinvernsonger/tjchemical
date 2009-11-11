using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllTSchool:ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingSchoolInfo";
        }

        #endregion
    }
}
