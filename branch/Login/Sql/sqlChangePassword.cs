using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlChangePassword:OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "UPDATE Account SET Password=@Password WHERE AccountID=@AccountID";
        }

        #endregion

        public sqlChangePassword(LoginInfo ToChek)
        {
            this.key = new Object[] { "@Password","@AccountID"};
            this.value = new Object[] { ToChek.Password,ToChek.Username};
        }
       
    }
}
