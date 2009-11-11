using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlAddAuthority:ISql
    {
        private string m_memberid;
        private int m_funcindex;
        private int m_sonfuncindex;
        public SqlAddAuthority(string memberid,int funcindex,int sonfuncindex)
        {
            m_memberid = memberid.Trim();
            m_funcindex = funcindex;
            m_sonfuncindex = sonfuncindex;
        }

        #region ISql ≥…‘±

        public string GetSql()
        {
            return "insert into ManagerAuthority values('" + m_memberid + "','" +
                            m_funcindex.ToString() + "','" +
                            m_sonfuncindex.ToString() + "')";
        }

        #endregion

    }
}
