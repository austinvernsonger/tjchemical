using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlDelAuthority:ISql
    {
        private string m_memberid;
        public SqlDelAuthority(string memberid)
        {
            m_memberid = memberid.Trim();
        }

        #region ISql≥…‘±
        public string GetSql()
        {
            return "delete from ManagerAuthority where MemberID='" + m_memberid + "'";
        }
        #endregion
    }
}
