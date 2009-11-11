using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlReturnDevice:ISql
    {
        string m_ApplyId;

        public SqlReturnDevice(string strApplyId)
        {
            m_ApplyId = strApplyId;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "update DeviceApplyTable set Status = 3 where ApplyId = '" + m_ApplyId + "'";
            return sql;
        }

        #endregion
    }
}
