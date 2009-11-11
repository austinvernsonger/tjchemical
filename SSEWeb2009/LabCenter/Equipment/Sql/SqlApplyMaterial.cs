using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlApplyMaterial : ISql
    {
        string m_id;
        string m_name;
        string m_applier;
        string m_count;
        string m_time;
        string m_status;
        string m_remark;
        public SqlApplyMaterial(string id, string name, string applier, string count, string time, string status, string remark)
        {
            m_id = id;
            m_name = name;
            m_applier = applier;
            m_count = count;
            m_time = time;
            m_status = status;
            m_remark = remark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into MaterialApplyTable" + " values('" + m_id + "','" + m_name + "','" + m_applier + "'," + m_count + ",'" + m_time + "'," + m_status + ",'" + m_remark + "')";
            return sql;
        }

        #endregion
    }
}
