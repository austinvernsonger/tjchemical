using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class EquiView
    {
        string m_DbName = "LabCenter";
        
        public DataSet EquipmentView()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetEquipView());
            i.Do();
            

           
            return i.Ds;
        }
    }
}
