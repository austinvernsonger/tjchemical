using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class DeviceApplyTable
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";

        private string GetId(string table, string col)
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName,
                new SqlGetMaxId(table, col));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
                return "0";
            }
            else
            {
                string maxId = i.Ds.Tables[0].Rows[0][0].ToString();
                if (maxId.Equals(""))
                    return "0";
                int t = int.Parse(maxId);
                return Convert.ToString(++t);
            }
        }

        public int DeviceApplySubmit(string id,string strName, string strRemark)
        {
            string strTime = DateTime.Now.ToString();
            string strId = GetId("DeviceApplyTable", "ApplyId");
            OpEquipmentExecute i = new OpEquipmentExecute(m_DbName, 
                new SqlDeviceApply(strId, strName, id, strTime, 0, strRemark));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
                return -1;
            }

            return int.Parse(strId);
        }
    }
}
