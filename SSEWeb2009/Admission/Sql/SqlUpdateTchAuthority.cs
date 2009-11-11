using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Admission.Sql
{
    class SqlSetHSAuthority : ISql
    {
        private string m_TeacherID;
        public SqlSetHSAuthority(string ID)
        {
            m_TeacherID = ID; 
        }


        #region ISql 成员

        public string GetSql()
        {
            return "update Admission set HS_stu = true where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }

    class SqlSetMSAuthority : ISql
    {
        private string m_TeacherID;
        public SqlSetMSAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "update Admission set MS_stu = true where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }
    class SqlSetMEAuthority : ISql
    {
        private string m_TeacherID;
        public SqlSetMEAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "update Admission set ME_stu = true where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }


    class SqlSetMTIAuthority : ISql
    {
        private string m_TeacherID;
        public SqlSetMTIAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "update Admission set MTI_stu = true where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }

    class SqlSetAuthority : ISql
    {
        private string m_TeacherID;
        public SqlSetAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "update Admission set HS_stu = false,MS_stu = false,ME_stu = false,MTI_stu = false,SUPER = false where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }

    class SqlSetSUPERAuthority : ISql
    {
        private string m_TeacherID;
        public SqlSetSUPERAuthority(string ID)
        {
            m_TeacherID = ID;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "update Admission set SUPER = true where TeacherID = '" + m_TeacherID + "'";
        }

        #endregion
    }


}