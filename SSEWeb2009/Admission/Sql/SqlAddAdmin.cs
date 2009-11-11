using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Admission.Sql
{
    class SqlAddAdmin : ISql
    {
        private string m_TeacherID;
        public SqlAddAdmin(string ID)
        {
            m_TeacherID = ID; 
        }
        #region ISql 成员

        public string GetSql()
        {
            return "INSERT INTO Admission(TeacherID,HS_stu,MS_stu,MH_stu,MTI_stu,SUPER)VALUES ('"+m_TeacherID+"','false','false','false','false','false')";
        }

        #endregion
    }
}