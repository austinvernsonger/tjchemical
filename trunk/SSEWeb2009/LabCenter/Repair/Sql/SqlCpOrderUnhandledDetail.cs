using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlCpOrderUnhandledDetail:ISql
    {
        string m_cp_number;
        public SqlCpOrderUnhandledDetail(string cp_number)
        {
            m_cp_number = cp_number.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select Reporter,Description,UpdateTime " +
                "from ComputerRepair where State=0 and " + 
                "ComputerNumber='"+m_cp_number+"' order by UpdateTime asc";
        }

        #endregion
    }
}
