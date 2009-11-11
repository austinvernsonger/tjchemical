using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlAlumnusNameID : ISql
    {
        private int m_Degree;
        private string m_GradYear;
        private int m_BeginIndex;
        private int m_Count;

        public SqlAlumnusNameID(int degree, string gradYear, int beginIndex, int count)
	    {
            m_Degree = degree;
            m_GradYear = gradYear.Trim();
            if (beginIndex <= 0)
                m_BeginIndex = 1;
            else
                m_BeginIndex = beginIndex;
            m_Count = count;

	    }

        #region ISql 成员

        public string GetSql()
        {
            if (m_Count < 0)
                return "Select StudentID,Name From Graduate where Degree = " + m_Degree + " and GraduateYear = '" + m_GradYear + "' ORDER BY StudentID";
            else
            {
                return "select top " + m_Count.ToString() + "StudentID, Name from Graduate where StudentID not in (select top " + (m_BeginIndex - 1).ToString() + " StudentID from Graduate where Degree = " + m_Degree + " and GraduateYear = '" + m_GradYear + "' order by StudentID) and Degree = " + m_Degree + " and GraduateYear = '" + m_GradYear + "' order by StudentID";
            }
        }

        #endregion

    }
}
