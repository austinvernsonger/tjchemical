using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlAlumnusList : ISql
    {
        private int m_Degree;
        private string m_GradYear;

        public SqlAlumnusList(int degree, string gradYear)
	    {
            m_Degree = degree;
            m_GradYear = gradYear.Trim();
	    }

        #region ISql 成员

        public string GetSql()
        {
            return "Select * From alumnus where degree = " + m_Degree + " and gradyear = '" + m_GradYear + "' ORDER BY stdnumber";
        }

        #endregion
    }
}
