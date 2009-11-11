using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetMaterialInfo : ISql
    {
        public SqlGetMaterialInfo()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from MaterialInfo";
        }

        #endregion
    }
}
