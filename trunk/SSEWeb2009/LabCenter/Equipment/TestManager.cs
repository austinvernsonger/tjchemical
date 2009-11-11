using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Equipment.Ops;
using LabCenter.Equipment.Sql;

namespace LabCenter.Equipment
{
    public class TestManager
    {
        string m_DBName = "LabCenter";
        public void Test()
        {
            OpEquiExecute i = new OpEquiExecute(m_DBName, new SqlTest());
            i.Do();
        }
    }
}
