using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetbegDayofweek:ISql
    {
        int _term;
        int _week;

        public SqlgetbegDayofweek()
        {

        }

        public SqlgetbegDayofweek(int term,int week)
        {
            _term = term;
            _week = week;
        }

        public string GetSql()
        {
            return "select BeginDayOfWeek,convert(nvarchar(5),[EndTime],8) as EndTime from TimeInfo " +
                "where TermNumber = " + _term + " and WeekNumber = " + _week + "order by BeginDayOfWeek";
        }
    }
}
