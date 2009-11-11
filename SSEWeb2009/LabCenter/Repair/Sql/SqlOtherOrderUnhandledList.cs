using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlOtherOrderUnhandledList:ISql
    {
        
        public SqlOtherOrderUnhandledList()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select RecordID,FacilityName,FacilityLocation," +
                "UpdateTime from OtherRepair where State=0";
        }

        #endregion
    }
}
