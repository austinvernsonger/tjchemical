using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class DeviceApplyTableUpdate
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        string strApplyId;
        
        string strStatus;
        string strRemark;
        public DeviceApplyTableUpdate(string strApplyId, string strStatus, string strRemark)
        {
            this.strApplyId = strApplyId;
            this.strStatus = strStatus;
            this.strRemark = strRemark;
        }
        public Boolean UpdateMaterialApplyTable()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlUpdateDeviceApplyTable(strApplyId, strStatus, strRemark));
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
