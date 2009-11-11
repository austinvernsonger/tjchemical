using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    
    public class EquipDetails
    {
        string m_DbName = "LabCenter";
        string strDeviceId;


        public EquipDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }

        public DataSet getEquipDetails()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetEquipDetails(strDeviceId));
            i.Do();



            return i.Ds;
        }
    }
}
