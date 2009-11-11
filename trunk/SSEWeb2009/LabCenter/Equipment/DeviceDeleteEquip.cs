using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{

    public class DeviceDeleteEquip
    {
        string m_DbName = "LabCenter";
        string strDeviceId;
        string ErrorMsg;


        public DeviceDeleteEquip(string DeviceId)
        {
            strDeviceId = DeviceId;
        }

        public Boolean DeleteEquip()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlDeleteEquip(strDeviceId));
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
