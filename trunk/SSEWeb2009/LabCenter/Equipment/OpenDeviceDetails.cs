using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    
    public class OpenDeviceDetails
    {
        string m_DbName = "LabCenter";
        string strDeviceId;


        public OpenDeviceDetails(string DeviceId)
        {
            strDeviceId = DeviceId;
        }

        public DataSet getOpenDeviceDetails()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetOpenDeviceDetails(strDeviceId));
            i.Do();



            return i.Ds;
        }
    }
}
