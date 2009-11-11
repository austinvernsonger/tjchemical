using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{

    public class MaterialApplyTableDelete
    {
        string m_DbName = "LabCenter";
        string strApplyId;
        string ErrorMsg;


        public MaterialApplyTableDelete(string strApplyId)
        {
            this.strApplyId = strApplyId;
        }

        public Boolean DeleteMaterialApplyTable()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlDeleteMaterialApplyTable(strApplyId));
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
