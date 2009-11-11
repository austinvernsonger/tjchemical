using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginDelete : ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "DELETE FROM Account WHERE AccountID='" + UserName + "'";
        }

        #endregion

        private String UserName;
        private String PassWord;

        public sqlLoginDelete(LoginInfo ToCheck)
        {
            UserName = ToCheck.Username;
            PassWord = ToCheck.Password;
        }
        public sqlLoginDelete()
        {
        }
    }
}
