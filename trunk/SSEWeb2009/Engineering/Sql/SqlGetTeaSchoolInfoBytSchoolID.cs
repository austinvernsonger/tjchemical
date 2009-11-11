using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeaSchoolInfoBytSchoolID:ISql
    {
        private string _tSchoolID;

        public SqlGetTeaSchoolInfoBytSchoolID(string tSchoolID)
        {
            _tSchoolID = tSchoolID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select  * from TeachingSchoolInfo where TeaSchoolID='"+_tSchoolID+"'";
        }

        #endregion
    }
}
