using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlUpdateDeviceApplyTable : ISql
    {
        string strApplyId;

        string strStatus;
        string strRemark;

        public SqlUpdateDeviceApplyTable(string strApplyId, string strStatus, string strRemark)
        {
            this.strApplyId = strApplyId;
            this.strStatus = strStatus;
            this.strRemark = strRemark;
        }
        #region ISql ��Ա

        public string GetSql()
        {
            string sql = "update DeviceApplyTable set Status='" + strStatus + "',Remark='" + strRemark + "' where ApplyId='" + strApplyId + "'";
            return sql;
        }

        #endregion
    }
}
