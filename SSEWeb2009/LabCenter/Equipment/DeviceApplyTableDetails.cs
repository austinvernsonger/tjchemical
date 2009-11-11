using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    
    public class DeviceApplyTableDetails
    {
        string m_DbName = "LabCenter";
        string strDeviceId;


        public DeviceApplyTableDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }

        public DataSet getDeviceApplyTableDetails()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlDeviceApplyTableDetails(strDeviceId));
            i.Do();



            return i.Ds;
        }
    }
}
