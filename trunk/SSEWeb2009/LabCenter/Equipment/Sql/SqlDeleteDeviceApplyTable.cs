using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlDeleteDeviceApplyTable : ISql
    {
        string strApplyId;


        public SqlDeleteDeviceApplyTable(string strApplyId)
        {
            this.strApplyId = strApplyId;
            
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "delete from DeviceApplyTable where ApplyId='" + strApplyId + "'";
            return sql;
        }

        #endregion
    }
}
