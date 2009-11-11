using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlUpdateTSchoolPwd : ISql
    {
        private String _teaSchoolID;
        private String _password;

        public SqlUpdateTSchoolPwd(string TeaSchoolID, string Password)
        {
            _teaSchoolID = TeaSchoolID;
            _password = Password;
        }
        
        #region ISql 成员

        public string GetSql()
        {
            return "UPDATE TeachingSchoolInfo SET Password='" + _password +
                                         "' WHERE TeaSchoolID='" + _teaSchoolID + "'";
        }

        #endregion

       
    }
}
