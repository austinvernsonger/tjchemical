using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlOtherCancel:ISql
    {
        string m_recordid;
        public SqlOtherCancel(string recordid)
        {
            m_recordid = recordid.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "update OtherRepair set " +
                "State=2,ConfirmTime=getdate() where RecordID='" +
                m_recordid + "' and State=0";
        }

        #endregion
    }
}
