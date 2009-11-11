using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlDeleteMaterialApplyTable : ISql
    {
        string strApplyId;


        public SqlDeleteMaterialApplyTable(string strApplyId)
        {
            this.strApplyId = strApplyId;
            
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "delete from MaterialApplyTable where ApplyId='" + strApplyId + "'";
            return sql;
        }

        #endregion
    }
}
