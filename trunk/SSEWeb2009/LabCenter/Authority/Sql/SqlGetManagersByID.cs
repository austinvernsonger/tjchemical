using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlGetManagersByID:ISql
    {
        private string m_memberid;
        public SqlGetManagersByID(string memberid)
        {
            m_memberid = memberid.Trim();
        }

     #region ISql≥…‘±

        public string GetSql()
        {
            return "select MemberID,Name from ManagerInfo where MemberID like '%" + m_memberid + "%' and IsSuper='0'";
        }

     #endregion
    }
}
