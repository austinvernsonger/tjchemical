using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetOpenMaterial : ISql
    {
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select MaterialName from MaterialInfo where Status = 1";
        }

        #endregion
    }
}
