using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginUpdate : ISql
    {

        #region ISql 成员

        public string GetSql()
        {
            return "UPDATE Account SET AccountID='"+ AccountID+
                                        "',Password='"+Password+
                                        "',AccountState='"+AccountState+
                                        "',SafetyEmail='" +SafetyEmail+
                                        "',EmailValidation='" +EmailValidation+
                                        "' WHERE AccountID='"+AccountID+"'";
        }

        #endregion

        private String AccountID;
        private String Password;
        private String AccountState;
        private String SafetyEmail;
        private int EmailValidation;

        public sqlLoginUpdate(LoginInfo ToInsert)
        {
            AccountID = ToInsert.Username;
            Password = ToInsert.Password;
            AccountState = ToInsert.Accoutstate;
            SafetyEmail = ToInsert.Emailaddress;
            EmailValidation = ToInsert.Emailvalidation;
        }
    }
}
