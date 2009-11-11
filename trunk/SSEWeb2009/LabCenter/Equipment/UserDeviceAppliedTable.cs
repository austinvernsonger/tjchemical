using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class UserDeviceAppliedTable
    {
        string m_DbName = "LabCenter";
        string strApplierId;
        public UserDeviceAppliedTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public DataSet getUserDeviceAppliedTable()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetUserDeviceAppliedTable(strApplierId));
            i.Do();



            return i.Ds;
        }
    }
}