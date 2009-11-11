using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTeaSchoolInfo:ISql
    {
        private TeachingSchool _ts;

        public SqlUpdateTeaSchoolInfo(TeachingSchool ts)
        {
            _ts = ts;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TeachingSchoolInfo Set TeaSchoolName = '" + _ts.TeaSchoolName + "',Password = '" + _ts.Password + "' where TeaSchoolID='"+_ts.TeaSchoolID+"'";
        }

        #endregion
    }
}
