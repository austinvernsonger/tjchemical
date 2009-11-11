using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{

    public class MaterialInfoDelete
    {
        string m_DbName = "LabCenter";
        string strMaterialName;
        string ErrorMsg;


        public MaterialInfoDelete(string MaterialName)
        {
            strMaterialName = MaterialName;
        }

        public Boolean DeleteMaterialInfo()
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlDeleteMaterialInfo(strMaterialName));
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
