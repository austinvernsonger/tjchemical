using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlAddSuper:ISql
    {
        private string m_memberid;
        private string m_membername;
        public SqlAddSuper(string memberid, string membername)
        {
            m_memberid = memberid.Trim();
            m_membername = membername.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "insert into ManagerInfo values('" + m_memberid + "','" +
                            m_membername + "','1')";
        }

        #endregion
    }
}
