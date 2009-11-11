using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlIsSuper:ISql
    {
        private string m_memberid;
         public SqlIsSuper(string memberid)
        {
            m_memberid = memberid;
        }
        #region ISql 成员

        public string GetSql()
        {
            return "select MemberID,Name from ManagerInfo where MemberID='"
                +m_memberid+"' and IsSuper='1'";
        }

        #endregion
    }
}
