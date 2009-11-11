using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlCpOrderUnhandledList:ISql
    {
        public SqlCpOrderUnhandledList()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select ComputerNumber,count(*)'count',min(UpdateTime)'earliest' " +
                "from ComputerRepair where State=0 group by ComputerNumber order by earliest asc";
        }

        #endregion
    }
}
