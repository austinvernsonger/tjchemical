using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetMaterialApplyTable : ISql
    {
        public SqlGetMaterialApplyTable()
        {
        }
        #region ISql ��Ա

        public string GetSql()
        {
            return "select * from MaterialApplyTable";
        }

        #endregion
    }
}
