using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    public class sqlCheckInfo:ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "SELECT * FROM Account WHERE AccountID='"+UserName+"'";
        }

        #endregion

        private String UserName;
        private String PassWord;

        public sqlCheckInfo(LoginInfo ToCheck)
        {
            UserName = ToCheck.Username;
            PassWord = ToCheck.Password;
        }
    }
}
