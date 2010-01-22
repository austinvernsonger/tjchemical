using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginDelete :OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "DELETE FROM Account WHERE AccountID=@AccountID";
        }

        #endregion

        public sqlLoginDelete(LoginInfo ToCheck)
        {
            this.key = new Object[] { "@Account" };
            this.value = new Object[] { ToCheck.Username };
        }
        public sqlLoginDelete()
        {
        }
    }
}
