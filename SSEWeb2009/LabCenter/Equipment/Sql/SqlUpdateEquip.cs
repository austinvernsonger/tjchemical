using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlUpdateEquip : ISql
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

        public SqlUpdateEquip(string strDeviceId, string strDeviceName, string strModel, string strFormat, string strAccount,
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
            string sql = "update DeviceInfo set DeviceName='" + strDeviceName + "',Model='" + strModel + "',Format='" + strFormat + "',Account='" + strAccount + "',Price='" + strPrice + "',Date='" + strDate + "',Factory='" + strFactory + "',Status='" + strStatus + "',Location='" + strLocation + "',Location2='" + strLocation2 + "',[User]='" + strUser + "',Admin='" + strAdmin + "',Remark='" + strRemark + "' where DeviceID='" + strDeviceId + "'";
            return sql;
        }

        #endregion
    }
}
