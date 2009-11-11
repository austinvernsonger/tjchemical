using System;
using System.Collections.Generic;
using System.Text;

using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetTimeSpanByYearWeek:ISql
    {
        private SqlgetTimeSpanByYearWeek(){}

        private string m_term;
        private string m_week;

        public SqlgetTimeSpanByYearWeek(string term,string week)
        {
            m_term = term;
            m_week = week;
        }

        public string GetSql()
        {
            return " select TimeSpanID,BeginDayOfWeek,BeginTime,isnull(EndDayOfWeek,BeginDayOfWeek)'EndDayOfWeek',EndTime,RemainCount " +
                        " from TimeInfo where TermNumber = "+m_term+" and WeekNumber = "+m_week;
        }
    }
}
