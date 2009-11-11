using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTSchoolingID:ISql
    {
        private string _tSchoolID;

        public SqlGetTSchoolingID(string schoolID)
        {
            _tSchoolID = schoolID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select TeaSchoolID from TeachingSchoolInfo where TeaSchoolID='" + _tSchoolID + "'";
        }

        #endregion
    }
}
