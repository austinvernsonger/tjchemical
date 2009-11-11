using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Admission.Sql
{
    class SqlGetHSAuthority : ISql
    {
        private string m_TeacherID;
        public SqlGetHSAuthority(string ID)
        {
            m_TeacherID = ID; 
        }


        #region ISql 成员

        public string GetSql()
        {
            return "SELECT HS_stu from Admission where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }

    class SqlGetMSAuthority : ISql
    {
        private string m_TeacherID;
        public SqlGetMSAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "SELECT MS_stu from Admission where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }
    class SqlGetMEAuthority : ISql
    {
        private string m_TeacherID;
        public SqlGetMEAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "SELECT ME_stu from Admission where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }


    class SqlGetMTIAuthority : ISql
    {
        private string m_TeacherID;
        public SqlGetMTIAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "SELECT MTI_stu from Admission where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }

    class SqlGetSUPERAuthority : ISql
    {
        private string m_TeacherID;
        public SqlGetSUPERAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "SELECT SUPER from Admission where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }

}