using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetOpenDeviceDetails : ISql
    {
        string strDeviceId;


        public SqlGetOpenDeviceDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }

        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "select * from OpenDeviceList where DeviceID='" + strDeviceId + "'";
            return sql;
        }

        #endregion


    }
}
