using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class MaterialInfo
    {
        string m_DbName = "LabCenter";

        public DataSet getMaterialInfo()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetMaterialInfo());
            i.Do();



            return i.Ds;
        }
    }
}
