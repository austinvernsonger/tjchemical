using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Admission.Sql
{
    class SqlDelAdmin : ISql
    {
        private string m_TeacherID;
        public SqlDelAdmin(string ID)
        {
            m_TeacherID = ID; 
        }
        #region ISql 成员

        public string GetSql()
        {
            return "delete Admission where TeacherID = '" +m_TeacherID+ "'";
        }

        #endregion
    }
}