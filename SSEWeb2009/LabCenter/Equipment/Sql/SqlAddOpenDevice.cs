using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlAddOpenDevice : ISql
    {
        string m_DeviceName;
        string m_Remark;
        public SqlAddOpenDevice(string name, string remark)
        {
            m_DeviceName = name;
            m_Remark = remark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into OpenDeviceList values('" + m_DeviceName + "','" + m_Remark + "')";
            return sql;
        }

        #endregion
    }
}
