using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;
using System.Data;

namespace LabCenter.Equipment
{
    public class EquipmentManager
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        public Boolean AddEquipment(string dvc_id, string dvc_name, string dvc_model, string dvc_format, string dvc_account, 
            string dvc_price, string dvc_date, string dvc_factory, string  dvc_status,
            string dvc_location, string dev_location2, string dvc_user, string dvc_admin, string dvc_remark)
        {
         
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName,
                new SqlAddEquipment(dvc_id,dvc_name, dvc_model, dvc_format, dvc_account,
                dvc_price, dvc_date, dvc_factory, dvc_status, dvc_location, dev_location2, dvc_user,
                dvc_admin, dvc_remark));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
                return false;
            }

            return true;
        }

        public DataSet GetOpenDevice()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName,
                new SqlGetOpenDevice());
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
                
            }
            return i.Ds;
        }
    }
}
