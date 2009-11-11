using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlUpdateOpenDevice : ISql
    {
        string strBeforeDeviceId;
        string strAfterDeviceId;
        
        string strRemark;

        public SqlUpdateOpenDevice(string strBeforeDeviceId,string strAfterDeviceId, string strRemark)
        {
            this.strBeforeDeviceId = strBeforeDeviceId;
            this.strAfterDeviceId = strAfterDeviceId;
            
            this.strRemark = strRemark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "update OpenDeviceList set DeviceID='" + strAfterDeviceId + "',Remark='" + strRemark + "' where DeviceID='" + strBeforeDeviceId + "'";
            return sql;
        }

        #endregion
    }
}
