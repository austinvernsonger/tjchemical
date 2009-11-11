using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlAddComputerOrder:ISql
    {
        string m_reporterid;
        string m_cp_number;
        string m_discription;
        public SqlAddComputerOrder(string reporterid,string cp_number,string description)
        {
            m_reporterid = reporterid.Trim();
            m_cp_number = cp_number.Trim();
            m_discription = description.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "insert into ComputerRepair(ComputerNumber,Description,Reporter,UpdateTime) " +
                            "values('"+m_cp_number+"','"+
                            m_discription + "','" +
                            m_reporterid + "',GetDate())";
        }

        #endregion
    }
}
