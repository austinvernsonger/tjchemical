using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlAddManager:ISql
    {
        private string m_memberid;
        private string m_membername;
        public SqlAddManager(string memberid, string membername)
        {
            m_memberid = memberid.Trim();
            m_membername = membername.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "insert into ManagerInfo values('" + m_memberid + "','" +
                            m_membername + "','0')";
        }

        #endregion
    }
}
