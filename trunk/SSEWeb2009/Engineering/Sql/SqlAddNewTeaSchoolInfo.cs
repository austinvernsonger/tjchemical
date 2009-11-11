using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddNewTeaSchoolInfo:ISql
    {
        private TeachingSchool _ts;

        public SqlAddNewTeaSchoolInfo(TeachingSchool ts)
        {
            _ts = ts;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into TeachingSchoolInfo(TeaSchoolID, TeaSchoolName, Password) " +
                "values('" + _ts.TeaSchoolID + "', '" + _ts.TeaSchoolName + "','" + _ts.Password+ "')";
        }

        #endregion
    }
}
