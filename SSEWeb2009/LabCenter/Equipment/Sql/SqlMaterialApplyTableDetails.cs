using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlMaterialApplyTableDetails : ISql
    {
        string strDeviceId;


        public SqlMaterialApplyTableDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }
        
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "select * from MaterialApplyTable where ApplyId='" + strDeviceId + "'";
            return sql;
        }

        #endregion


    }
}
