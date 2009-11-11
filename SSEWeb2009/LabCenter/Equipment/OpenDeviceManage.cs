using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class OpenDeviceManage
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        public Boolean AddDevice(string strName, string strRemark)
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlAddOpenDevice(strName, strRemark));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "����ϵͳԭ���ύʧ�ܣ����Ժ����ԡ�";
                return false;
            }
            return true;
        }
    }
}
