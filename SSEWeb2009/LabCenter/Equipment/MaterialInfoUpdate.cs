using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class MaterialInfoUpdate
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        string strBeforeMaterialName;
        string strAfterMaterialName;
        string strAccount;
        string strUnit;
        string strStatus;
        string strRemark;
        public MaterialInfoUpdate(string strBeforeMaterialName, string strAfterMaterialName, string strAccount, string strUnit, string strStatus, string strRemark)
        {
            this.strBeforeMaterialName = strBeforeMaterialName;
            this.strAfterMaterialName = strAfterMaterialName;
            this.strAccount = strAccount;
            this.strUnit = strUnit;
            this.strStatus = strStatus;
            this.strRemark = strRemark;
        }
        public Boolean UpdateMaterialInfo()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlUpdateMaterialInfo(strBeforeMaterialName, strAfterMaterialName, strAccount, strUnit, strStatus, strRemark));
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
