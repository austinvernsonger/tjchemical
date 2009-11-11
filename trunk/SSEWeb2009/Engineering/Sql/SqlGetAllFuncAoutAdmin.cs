using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllFuncAoutAdmin:ISql
    {
        public SqlGetAllFuncAoutAdmin()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select FuncID from Funcs where left(FuncID,2)='1-'";
        }

        #endregion
    }
}
