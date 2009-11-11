using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlSetManagerSuper:ISql
    {
        private string m_memberid;
        private bool m_issuper;
        public SqlSetManagerSuper(string memberid,bool issuper)
        {
            m_memberid = memberid.Trim();
            m_issuper = issuper;
        }

        #region ISql≥…‘±
        public string GetSql()
        {
            if (m_issuper)
            {
                return "update ManagerInfo set IsSuper='1' where MemberID='"
           + m_memberid + "'";
            }
            else
            {
                return "update ManagerInfo set IsSuper='0' where MemberID='"
          + m_memberid + "'";
            }
           
        }
        #endregion
    }
}
