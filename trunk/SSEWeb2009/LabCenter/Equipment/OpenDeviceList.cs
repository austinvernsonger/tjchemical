using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class OpenDeviceList
    {
        string m_DbName = "LabCenter";

        public DataSet getOpenDeviceList()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetOpenDeviceList());
            i.Do();



            return i.Ds;
        }
    }
}
