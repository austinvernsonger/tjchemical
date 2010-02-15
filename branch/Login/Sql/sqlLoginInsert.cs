using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginInsert : OldtoNewSql
    {

        #region ISql 成员

        public override string GetSql()
        {
            return "INSERT INTO Account (AccountID, Password, AccountState, SafetyEmail, EmailValidation) VALUES(@AccountID, @Password, @AccountState, @SafetyEmail,@EmailValidation)";
        }

        #endregion

        public sqlLoginInsert(LoginInfo ToInsert)
        {
            this.key = new Object[] { "@AccountID", "@Password", "@AccountState", "@SafetyEmail", "@EmailValidation" };
            this.value = new Object[] {ToInsert.Username,ToInsert.Password,ToInsert.Accoutstate,ToInsert.Emailaddress,ToInsert.Emailvalidation };
        }
    }
}
