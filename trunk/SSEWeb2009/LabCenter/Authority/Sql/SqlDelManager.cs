using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlDelManager:ISql
    {
        private string m_memberid;
        public SqlDelManager(string memberid)
        {
            m_memberid = memberid.Trim();     
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "delete from ManagerInfo where MemberID='"+m_memberid+"'";
        }

        #endregion
    }
}
