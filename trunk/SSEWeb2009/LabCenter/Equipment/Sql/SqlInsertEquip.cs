using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlInsertEquip : ISql
    {
        string strDeviceId;
        string strDeviceName;
        string strModel;
        string strFormat;
        string strAccount;
        string strPrice;
        string strDate;
        string strFactory;
        string strStatus;
        string strLocation;
        string strLocation2;
        string strUser;
        string strAdmin;
        string strRemark;

        public SqlInsertEquip(string strDeviceId, string strDeviceName, string strModel, string strFormat, string strAccount,
            string strPrice, string strDate, string strFactory, string strStatus, string strLocation, string strLocation2,
            string strUser, string strAdmin, string strRemark)
        {
            this.strDeviceId = strDeviceId;
            this.strDeviceName = strDeviceName;
            this.strModel = strModel;
            this.strFormat = strFormat;
            this.strAccount = strAccount;
            this.strPrice = strPrice;
            this.strDate = strDate;
            this.strFactory = strFactory;
            this.strStatus = strStatus;
            this.strLocation = strLocation;
            this.strLocation2 = strLocation2;
            this.strUser = strUser;
            this.strAdmin = strAdmin;
            this.strRemark = strRemark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into DeviceInfo values ('" + strDeviceId + "','" + strDeviceName + "','" + strModel + "','" + strFormat + "','" + strAccount + "','" + strPrice + "','" + strDate + "','" + strFactory + "','" + strStatus + "','" + strLocation + "','" + strLocation2 + "','" + strUser + "','" + strAdmin + "','" + strRemark + "')";
            return sql;
        }

        #endregion
    }
}
