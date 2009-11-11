using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{

    public class DeviceApplyTableDelete
    {
        string m_DbName = "LabCenter";
        string strApplyId;
        string ErrorMsg;


        public DeviceApplyTableDelete(string strApplyId)
        {
            this.strApplyId = strApplyId;
        }

        public Boolean DeleteMaterialApplyTable()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlDeleteDeviceApplyTable(strApplyId));
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
