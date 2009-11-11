using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlGetManagersByName:ISql
    {
        private string m_membername;
        public SqlGetManagersByName(string membername)
        {
            m_membername = membername.Trim();
        }

     #region ISql≥…‘±

        public string GetSql()
        {
            return "select MemberID,Name from ManagerInfo where Name like '%" + m_membername + "%' and IsSuper='0'";
        }

     #endregion
    }
}
