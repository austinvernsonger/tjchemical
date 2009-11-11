using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlDeviceApplyTableDetails : ISql
    {
        string strDeviceId;


        public SqlDeviceApplyTableDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }
        
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "select * from DeviceApplyTable where ApplyId='" + strDeviceId + "'";
            return sql;
        }

        #endregion


    }
}
