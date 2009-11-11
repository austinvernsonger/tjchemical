using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlGetByID : ISql
    {
        private string m_memberid;
        public SqlGetByID(string memberid)
        {
            m_memberid = memberid.Trim();
        }

        #region ISql成员

        public string GetSql()
        {
            return "select * from ManagerInfo where MemberID='" + m_memberid + "'";
        }

        #endregion
    }
}
