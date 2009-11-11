using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class UserMaterialApplyingTable
    {
        string m_DbName = "LabCenter";
        string strApplierId;
        public UserMaterialApplyingTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public DataSet getUserMaterialApplyingTable()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetUserMaterialApplyingTable(strApplierId));
            i.Do();



            return i.Ds;
        }
    }
}