using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetUserDeviceApplyingTable : ISql
    {
        string strApplierId;
        public SqlGetUserDeviceApplyingTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public SqlGetUserDeviceApplyingTable()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from DeviceApplyTable where ApplierId='" + strApplierId + "' and Status=0";
        }

        #endregion
    }
}
