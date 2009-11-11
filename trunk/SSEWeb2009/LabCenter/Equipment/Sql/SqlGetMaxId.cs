using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetMaxId : ISql
    {
        string m_table;
        string m_col;
        public SqlGetMaxId(string table, string col)
        {
            m_table = table;
            m_col = col;            
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "select MAX(" + m_col + ")" + " from " + m_table;
            return sql;
        }

        #endregion
    }
}
