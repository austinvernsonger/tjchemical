using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class sqlChange : ISql
    {
        protected String mSQL;

        public sqlChange(String SQL)
        {
            mSQL = SQL;
        }
        #region ISql Members

        public string GetSql()
        {
            return mSQL;
        }

        #endregion
    }
}
