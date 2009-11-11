using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    
    public class MaterialApplyTableDetails
    {
        string m_DbName = "LabCenter";
        string strDeviceId;


        public MaterialApplyTableDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }

        public DataSet getEquipDetails()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlMaterialApplyTableDetails(strDeviceId));
            i.Do();



            return i.Ds;
        }
    }
}
