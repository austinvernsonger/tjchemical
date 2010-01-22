using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginUpdate : OldtoNewSql
    {

        #region ISql 成员

        public override string GetSql()
        {
            return "UPDATE Account SET AccountID=@AccountID,Password=@Password,AccountState=@AccountState,SafetyEmail=@SafetyEmail,EmailValidation=@EmailValidation WHERE AccountID=@AccountID";
        }

        #endregion

        public sqlLoginUpdate(LoginInfo ToInsert)
        {
            this.key = new Object[] { "@AccountID", "@Password", "@AccountState", "@SafetyEmail", "@EmailValidation" };
            this.value = new Object[] { ToInsert.Username, ToInsert.Password, ToInsert.Accoutstate, ToInsert.Emailaddress, ToInsert.Emailvalidation };
        }
    }
}
