using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetUserMaterialApplyingTable : ISql
    {
        string strApplierId;
        public SqlGetUserMaterialApplyingTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public SqlGetUserMaterialApplyingTable()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from MaterialApplyTable where ApplierId='" + strApplierId + "' and Status=0";
        }

        #endregion
    }
}
