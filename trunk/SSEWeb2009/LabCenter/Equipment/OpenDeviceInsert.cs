using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class OpenDeviceInsert
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        string strDeviceId;
        
        string strRemark;
        public OpenDeviceInsert(string strDeviceId, string strRemark)
        {
            this.strDeviceId = strDeviceId;
            
            this.strRemark = strRemark;
        }
        public Boolean InsertOpenDevice()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlInsertOpenDevice(strDeviceId, strRemark));
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
