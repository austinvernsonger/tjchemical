using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlAlumnusUpdate : ISql
    {
        private string m_Name;    

        private string m_StdNumber;    

        private string m_Birthplace;

        private string m_WorkUnit;

        private string m_WorkPlace;

        private string m_Tel;

        private string m_Email;

        private string m_Intro;

        private int m_Openstatus;

        private string m_TeachingPoint;

        public SqlAlumnusUpdate(Alumnus alumnus)
	    {
            m_Name = alumnus.Name;
            m_StdNumber = alumnus.StdNumber;
            m_Birthplace = alumnus.BirthPlace;
            m_WorkUnit = alumnus.WorkUnit;
            m_WorkPlace = alumnus.WorkPlace;
            m_Tel = alumnus.Tel;
            m_Email = alumnus.Email;
            m_Intro = alumnus.Intro;
            m_Openstatus = alumnus.Openstatus;
            m_TeachingPoint = alumnus.GradPlace;
	    }

        #region ISql 成员

        public string GetSql()
        {
            return "UPDATE Graduate SET " +
                        "TeachingPoint = '" + m_TeachingPoint + "', " +
                        "Origin = '" + m_Birthplace + "', " +
                        "WorkPlace = '" + m_WorkUnit + "', " +
                        "WorkAddress = '" + m_WorkPlace + "', " +
                        "Phone = '" + m_Tel + "', " +
                        "Email = '" + m_Email + "', " +
                        "Summary = '" + m_Intro + "', " +
                        "Publicity = " + m_Openstatus + " " +
                    "where StudentID = '" + m_StdNumber + "'";
        }

        #endregion
    }
}
