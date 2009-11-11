using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class MaterialApplyTable
    {
        string m_DbName = "LabCenter";

        public DataSet getMaterialApplyTable()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetMaterialApplyTable());
            i.Do();



            return i.Ds;
        }
    }
}