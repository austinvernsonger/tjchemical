using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class UserMaterialAppliedTable
    {
        string m_DbName = "LabCenter";
        string strApplierId;
        public UserMaterialAppliedTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public DataSet getUserMaterialAppliedTable()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetUserMaterialAppliedTable(strApplierId));
            i.Do();



            return i.Ds;
        }
    }
}