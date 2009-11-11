using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class DeviceReturnManager
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        public Boolean ReturnDevice(string strId)
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlReturnDevice(strId));
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
