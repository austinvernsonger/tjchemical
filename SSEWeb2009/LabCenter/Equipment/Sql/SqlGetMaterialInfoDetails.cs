using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetMaterialInfoDetails : ISql
    {
        string strDeviceId;


        public SqlGetMaterialInfoDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }
        
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "select * from MaterialInfo where MaterialName='" + strDeviceId + "'";
            return sql;
        }

        #endregion


    }
}
