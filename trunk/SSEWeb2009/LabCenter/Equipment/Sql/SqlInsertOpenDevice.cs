using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlInsertOpenDevice : ISql
    {
        string strDeviceId;
        
        string strRemark;

        public SqlInsertOpenDevice(string strDeviceId,string strRemark)
        {
            this.strDeviceId = strDeviceId;
            
            this.strRemark = strRemark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into OpenDeviceList values ('" + strDeviceId + "','" + strRemark + "')";
            return sql;
        }

        #endregion
    }
}
