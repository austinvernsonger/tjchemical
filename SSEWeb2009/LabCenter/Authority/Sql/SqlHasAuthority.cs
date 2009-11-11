using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlHasAuthority : ISql
    {
        private string m_memberid;
        private int m_index;
        private int m_sonindex;
        public SqlHasAuthority(string memberid,int index,int sonindex)
        {
            m_memberid = memberid;
            m_index = index;
            m_sonindex = sonindex;
        }

     #region ISql≥…‘±

        public string GetSql()
        {
            return "select * from ManagerAuthority where MemberID='" + m_memberid + "' and FuncIndex='" + m_index 
                +"' and SonFuncIndex='"+m_sonindex+"'";
        }

     #endregion
    }
}
