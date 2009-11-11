using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class ExportEquiView
    {
        string m_DbName = "LabCenter";

        public DataSet getExportEquiView()
        {
            OpEquiQuery i = new OpEquiQuery(m_DbName, new SqlGetExportEquiView());
            i.Do();
            

           
            return i.Ds;
        }
    }
}
