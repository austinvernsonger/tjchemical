using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlGetManager:ISql
    {
        private string m_memberid;
        public SqlGetManager(string memberid)
        {
            m_memberid = memberid.Trim();
        }

     #region ISql≥…‘±

        public string GetSql()
        {
            return "select * from ManagerInfo where MemberID='" + m_memberid + "' and IsSuper='0'";
        }

     #endregion
    }
}
