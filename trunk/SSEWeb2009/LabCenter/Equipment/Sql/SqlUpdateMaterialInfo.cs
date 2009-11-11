using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlUpdateMaterialInfo : ISql
    {
        string strBeforeMaterialName;
        string strAfterMaterialName;
        string strAccount;
        string strUnit;
        string strStatus;
        string strRemark;
        
        public SqlUpdateMaterialInfo(string strBeforeMaterialName, string strAfterMaterialName, string strAccount, string strUnit, string strStatus, string strRemark)
        {
            this.strBeforeMaterialName = strBeforeMaterialName;
            this.strAfterMaterialName = strAfterMaterialName;
            this.strAccount = strAccount;
            this.strUnit = strUnit;
            this.strStatus = strStatus;
            this.strRemark = strRemark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "update MaterialInfo set MaterialName='" + strAfterMaterialName + "',Account='" + strAccount + "',Unit='" + strUnit + "',Status='" + strStatus + "',Remark='" + strRemark + "' where MaterialName='" + strBeforeMaterialName + "'";
            return sql;
        }

        #endregion
    }
}

