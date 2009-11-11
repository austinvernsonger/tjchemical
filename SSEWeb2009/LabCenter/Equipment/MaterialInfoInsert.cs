using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class MaterialInfoInsert
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        string strMaterialName;
        string strAccount;
        string strUnit;

        
        string strStatus;
        string strRemark;
       
        
        public MaterialInfoInsert(string strMaterialName, string strAccount, string strUnit, string strStatus, string strRemark)
        {
            this.strMaterialName = strMaterialName;
            this.strAccount = strAccount;
            this.strUnit = strUnit;
            this.strStatus = strStatus;
            this.strRemark = strRemark;


        }
        public Boolean InsertMaterialInfo()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlMaterialInfoInsert(strMaterialName, strAccount, strUnit, strStatus, strRemark));
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
