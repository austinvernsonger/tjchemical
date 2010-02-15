using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginList : OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "SELECT * FROM Account";
        }

        #endregion
    }
}