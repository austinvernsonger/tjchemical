using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlMaterialInfoInsert : ISql
    {
        string strMaterialName;
        string strAccount;
        string strUnit;


        string strStatus;
        string strRemark;

        public SqlMaterialInfoInsert(string strMaterialName, string strAccount, string strUnit, string strStatus, string strRemark)
        {
            this.strMaterialName = strMaterialName;
            this.strAccount = strAccount;
            this.strUnit = strUnit;
            this.strStatus = strStatus;
            this.strRemark = strRemark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into MaterialInfo values ('" + strMaterialName + "','" + strAccount + "','" + strUnit + "','" + strStatus + "','" + strRemark + "')";
            return sql;
        }

        #endregion
    }
}
