using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlAddMaterial : ISql
    {
        string m_name;
        int m_count;
        string m_unit;
        char m_status;
        string m_remark;
        public SqlAddMaterial(string name, int count, string unit, char status, string remark)
        {
            m_name = name;
            m_count = count;
            m_unit = unit;
            m_status = status;
            m_remark = remark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into MaterialInfo" + " values('" + m_name + "'," + m_count + ",'" + m_unit + "'," + m_status + ",'" + m_remark + "')";
            return sql;

        }

        #endregion
    }
}
