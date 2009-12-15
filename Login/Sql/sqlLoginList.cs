using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class sqlLoginList : ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "SELECT * FROM Account";
        }

        #endregion
    }
}