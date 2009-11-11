using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeaSchoolInfoBytSchoolName:ISql
    {
        private string _name;

        public SqlGetTeaSchoolInfoBytSchoolName(string name)
        {
            _name = name;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select  * from TeachingSchoolInfo where TeaSchoolName='" + _name + "'";
        }

        #endregion
    }
}
