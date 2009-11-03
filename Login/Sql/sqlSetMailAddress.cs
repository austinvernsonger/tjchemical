using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlSetMailAddress:ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "UPDATE Account SET SafetyEmail='" +emailaddress+ "',EmailValidation=0 WHERE AccountID='" + accountid + "'";
        }

        #endregion

        private String emailaddress;
        private String accountid;

        public sqlSetMailAddress(String EMailAddress,String AccountId)
        {
            accountid = AccountId;
            emailaddress = EMailAddress;
        }
    }
}
