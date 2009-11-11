using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetUserDeviceAppliedTable : ISql
    {
        string strApplierId;
        public SqlGetUserDeviceAppliedTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public SqlGetUserDeviceAppliedTable()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from DeviceApplyTable where ApplierId='" + strApplierId + "' and Status!=0";
        }

        #endregion
    }
}
