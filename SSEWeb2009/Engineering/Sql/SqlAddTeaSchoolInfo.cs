using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddTeaSchoolInfo : ISql
    {
        private string tSchoolName;

        public SqlAddTeaSchoolInfo(string name)
        {
            tSchoolName = name;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into TeachingSchoolInfo values('" + tSchoolName + "') select SCOPE_IDENTITY() as id";
        }

        #endregion
    }
}
