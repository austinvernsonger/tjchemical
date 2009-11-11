using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlAlumnusCount : ISql
    {
        private int m_Degree;
        private string m_GradYear;

        public SqlAlumnusCount(int degree, string gradYear)
	    {
            m_Degree = degree;
            m_GradYear = gradYear.Trim();
	    }

        #region ISql 成员

        public string GetSql()
        {
            return "Select count(*) as nums from Graduate where Degree = " + m_Degree.ToString() + " and GraduateYear = '" + m_GradYear + "'";
        }

        #endregion
    }
}
