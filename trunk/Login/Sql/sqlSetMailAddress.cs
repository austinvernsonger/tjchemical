using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlSetMailAddress:OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "UPDATE Account SET SafetyEmail=@SafetyEmail,EmailValidation=0 WHERE AccountID=@Account";
        }

        #endregion

        public sqlSetMailAddress(String EMailAddress,String AccountId)
        {
            this.key = new Object[] { "@SafetyEmail", "@Account" };
            this.value = new Object[] { EMailAddress, AccountId };
        }
    }
}
