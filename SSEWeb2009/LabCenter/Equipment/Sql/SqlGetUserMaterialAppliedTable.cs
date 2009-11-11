using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetUserMaterialAppliedTable : ISql
    {
        string strApplierId;
        public SqlGetUserMaterialAppliedTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public SqlGetUserMaterialAppliedTable()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from MaterialApplyTable where ApplierId='" + strApplierId + "' and Status!=0";
        }

        #endregion
    }
}
