using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    public class sqlGetNewsAthuoutyList: OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "SELECT id,name FROM NewsAuthority";
        }

        #endregion
    }
}
