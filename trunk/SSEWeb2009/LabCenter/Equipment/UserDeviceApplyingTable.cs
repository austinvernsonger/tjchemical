using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class UserDeviceApplyingTable
    {
        string m_DbName = "LabCenter";
        string strApplierId;
        public UserDeviceApplyingTable(string strApplierId)
        {
            this.strApplierId = strApplierId;
        }

        public DataSet getUserDeviceApplyingTable()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetUserDeviceApplyingTable(strApplierId));
            i.Do();



            return i.Ds;
        }
    }
}