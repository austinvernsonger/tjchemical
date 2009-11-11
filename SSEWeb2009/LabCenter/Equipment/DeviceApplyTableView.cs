using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class DeviceApplyTableView
    {
        string m_DbName = "LabCenter";

        public DataSet getDeviceApplyTableView()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetDeviceApplyTableView());
            i.Do();



            return i.Ds;
        }
    }
}