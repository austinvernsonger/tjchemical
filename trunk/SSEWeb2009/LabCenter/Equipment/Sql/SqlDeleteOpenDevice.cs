using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlDeleteOpenDevice : ISql
    {
        string strDeviceId;


        public SqlDeleteOpenDevice(string strDeviceId)
        {
            this.strDeviceId = strDeviceId;
            
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "delete from OpenDeviceList where DeviceID='" + strDeviceId + "'";
            return sql;
        }

        #endregion
    }
}
