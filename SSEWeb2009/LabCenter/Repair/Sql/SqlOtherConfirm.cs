using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlOtherConfirm:ISql
    {
        string m_recordid;
        public SqlOtherConfirm(string recordid)
        {
            m_recordid = recordid.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "update OtherRepair set " +
                "State=1,ConfirmTime=getdate() where RecordID='" +
                m_recordid + "' and State=0";
        }

        #endregion
    }
}
