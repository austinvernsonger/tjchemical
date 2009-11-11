using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlDeleteEquip : ISql
    {
        string strDeviceId;
        

        public SqlDeleteEquip(string strDeviceId)
        {
            this.strDeviceId = strDeviceId;
            
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "delete from DeviceInfo where DeviceID='" + strDeviceId + "'";
            return sql;
        }

        #endregion
    }
}
