using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlHasFunction : ISql
    {
        private string m_memberid;
        private int m_index;
        public SqlHasFunction(string memberid,int index)
        {
            m_memberid = memberid;
            m_index = index;
        }

     #region ISql≥…‘±

        public string GetSql()
        {
            return "select * from ManagerAuthority where MemberID='" + m_memberid + "' and FuncIndex='" + m_index +"'";
        }

     #endregion
    }
}
