using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetEquipDetails : ISql
    {
        string strDeviceId;


        public SqlGetEquipDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }
        
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "select * from DeviceInfo where DeviceId='" + strDeviceId + "'";
            return sql;
        }

        #endregion


    }
}
