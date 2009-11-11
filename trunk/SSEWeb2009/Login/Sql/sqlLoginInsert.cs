using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginInsert:ISql
    {

        #region ISql 成员

        public string GetSql()
        {
            return "INSERT INTO Account (AccountID, Password, AccountState, SafetyEmail, EmailValidation) VALUES('"+AccountID+
                                                                                                                "','"+Password+
                                                                                                                "','"+AccountState+
                                                                                                                "','"+SafetyEmail+
                                                                                                                "','"+EmailValidation+"')";
        }

        #endregion

        private String AccountID;
        private String Password;
        private String AccountState;
        private String SafetyEmail;
        private int EmailValidation;

        public sqlLoginInsert(LoginInfo ToInsert)
        {
            AccountID = ToInsert.Username;
            Password = ToInsert.Password;
            AccountState = ToInsert.Accoutstate;
            SafetyEmail = ToInsert.Emailaddress;
            EmailValidation = ToInsert.Emailvalidation;
        }
    }
}
