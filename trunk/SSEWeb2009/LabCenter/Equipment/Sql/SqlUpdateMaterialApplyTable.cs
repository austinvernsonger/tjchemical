using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlUpdateMaterialApplyTable : ISql
    {
        string strApplyId;

        string strStatus;
        string strRemark;

        public SqlUpdateMaterialApplyTable(string strApplyId, string strStatus, string strRemark)
        {
            this.strApplyId = strApplyId;
            this.strStatus = strStatus;
            this.strRemark = strRemark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "update MaterialApplyTable set Status='" + strStatus + "',Remark='" + strRemark + "' where ApplyId='" + strApplyId + "'";
            return sql;
        }

        #endregion
    }
}

