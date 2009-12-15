using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlMailCommit:ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "UPDATE Account SET EmailValidation='1' WHERE AccountID='"+accountid+"'";
        }

        #endregion

        public sqlMailCommit(String AccountId)
        {
            accountid = AccountId;
        }
        private String accountid;
    }
}
