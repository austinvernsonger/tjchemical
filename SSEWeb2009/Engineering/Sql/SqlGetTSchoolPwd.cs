using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTSchoolPwd : ISql
    {
        private string _username;

        public SqlGetTSchoolPwd(string username)
        {
            _username = username;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "SELECT * FROM TeachingSchoolInfo WHERE TeaSchoolID='"+_username+"'";
        }

        #endregion

        
    }
}
