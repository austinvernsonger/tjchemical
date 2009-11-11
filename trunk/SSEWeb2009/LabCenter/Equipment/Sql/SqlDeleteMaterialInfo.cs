using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlDeleteMaterialInfo : ISql
    {
        string strMaterialName;


        public SqlDeleteMaterialInfo(string strMaterialName)
        {
            this.strMaterialName = strMaterialName;
            
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "delete from MaterialInfo where MaterialName='" + strMaterialName + "'";
            return sql;
        }

        #endregion
    }
}
