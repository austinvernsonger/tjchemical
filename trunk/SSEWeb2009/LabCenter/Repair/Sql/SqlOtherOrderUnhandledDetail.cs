using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlOtherOrderUnhandledDetail:ISql
    {
        string m_recordID;
        public SqlOtherOrderUnhandledDetail(string recordID)
        {
            m_recordID = recordID.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select RecordID,FacilityName,FacilityLocation," +
                "Description,UpdateTime,Reporter " +
                "from OtherRepair where State=0 and " +
                "RecordID='" + m_recordID + "'";
        }

        #endregion
    }
}
