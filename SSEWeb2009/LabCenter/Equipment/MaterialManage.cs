using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;
using System.Data;

namespace LabCenter.Equipment
{
    public class MaterialManage
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";

        public Boolean AddMaterial(string name, int account, string unit, char status, string remark)
        {
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlAddMaterial(name, account, unit, status, remark));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
                return false;
            }

            return true;
        }
        public DataSet GetOpenMaterial()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName,
                new SqlGetOpenMaterial());
            if (i.Do())
            {
                ;
            }
            return i.Ds;
        }
    }
}
