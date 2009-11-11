using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlComputerCancel:ISql
    {
        string m_cp_num;
        public SqlComputerCancel(string cp_number)
        {
            m_cp_num = cp_number.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "update ComputerRepair set " +
                "State=2,ConfirmTime=getdate() where ComputerNumber='" +
                m_cp_num + "' and State=0";
        }

        #endregion
    }
}
