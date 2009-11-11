using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlDeviceApply:ISql
    {
        string strApplyId;
        string strDeviceName;
        string strApplierId;
        string strDate;
        int nStatus = 0;
        string strRemark;

        public SqlDeviceApply(string applyId, string deviceName, string applierId, string date, int status, string remark)
        {
            strApplyId = applyId;
            strDeviceName = deviceName;
            strApplierId = applierId;
            strDate = date;
            nStatus = status;
            strRemark = remark;
        }

        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into DeviceApplyTable" + " values('" + strApplyId + "','" + strDeviceName + "','" + strApplierId + "','" + strDate + "'," + nStatus + ",'" + strRemark + "')";
            return sql;
        }

        #endregion

    }
}
