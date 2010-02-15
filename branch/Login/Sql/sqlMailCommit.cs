using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlMailCommit:OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "UPDATE Account SET EmailValidation='1' WHERE AccountID=@AccountID";
        }

        #endregion

        public sqlMailCommit(String AccountId)
        {
            this.key = new Object[] { "@AccountID" };
            this.value = new Object[] { AccountId };
        }
    }
}
