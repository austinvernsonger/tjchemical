using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class OpenDeviceUpdate
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        string strBeforeDeviceId;
        string strAfterDeviceId;
        string strRemark;
        public OpenDeviceUpdate(string strBeforeDeviceId, string strAfterDeviceId, string strRemark)
        {
            this.strBeforeDeviceId = strBeforeDeviceId;
            this.strAfterDeviceId = strAfterDeviceId;
            
            this.strRemark = strRemark;
        }
        public Boolean UpdateOpenDevice()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlUpdateOpenDevice(strBeforeDeviceId, strAfterDeviceId, strRemark));
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
