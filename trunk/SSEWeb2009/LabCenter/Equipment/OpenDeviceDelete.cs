using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{

    public class OpenDeviceDelete
    {
        string m_DbName = "LabCenter";
        string strDeviceId;
        string ErrorMsg;


        public OpenDeviceDelete(string DeviceId)
        {
            strDeviceId = DeviceId;
        }

        public Boolean DeleteOpenDevice()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlDeleteOpenDevice(strDeviceId));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "����ϵͳԭ���ύʧ�ܣ����Ժ����ԡ�";
                return false;
            }

            return false;
        }
    }
}
