using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    public class sqlFindByAccountId:ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "SELECT * FROM Account WHERE AccountId='" + accountid + "'";
        }

        #endregion

        private String accountid;

        public sqlFindByAccountId(String AccountId)
        {
            accountid = AccountId;
        }
    }
}
