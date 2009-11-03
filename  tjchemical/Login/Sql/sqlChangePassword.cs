using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlChangePassword:ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "UPDATE Account SET Password='" + Password +
                                         "' WHERE AccountID='" + AccountID + "'";
        }

        #endregion

        public sqlChangePassword(LoginInfo ToChek)
        {
            Password = ToChek.Password;
            AccountID = ToChek.Username;
        }
        private String AccountID;
        private String Password;
        
    }
}
