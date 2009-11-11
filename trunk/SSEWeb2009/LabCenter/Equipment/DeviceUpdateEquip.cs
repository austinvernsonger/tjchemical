using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class DeviceUpdateEquip
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
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
        public DeviceUpdateEquip(string strDeviceId, string strDeviceName, string strModel, string strFormat, string strAccount,
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
        public Boolean UpdateEquip()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlUpdateEquip(strDeviceId, strDeviceName, strModel, strFormat, strAccount, strPrice, strDate, strFactory, strStatus, strLocation, strLocation2, strUser, strAdmin, strRemark));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
                return false;
            }

            return false;
        }
    }
}
