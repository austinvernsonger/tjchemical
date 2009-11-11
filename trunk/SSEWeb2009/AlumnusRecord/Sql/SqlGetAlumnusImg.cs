using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlGetAlumnusImg : ISql
    {
        private string m_ID;

        public SqlGetAlumnusImg(string id)
        {
            m_ID = id; 
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select HeadPicture from Graduate where StudentID='" + m_ID + "'";
        }

        #endregion
    }
}
