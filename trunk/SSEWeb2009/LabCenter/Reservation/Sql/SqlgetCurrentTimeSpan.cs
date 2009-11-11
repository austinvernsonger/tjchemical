using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetCurrentTimeSpan:ISql
    {
        private int _term;
        private int _week;

        public SqlgetCurrentTimeSpan(){}

        public SqlgetCurrentTimeSpan(int term,int week)
        {
            _term = term;
            _week = week;
        }

        public string GetSql()
        {
            return "select TimeSpanID from TimeInfo where TermNumber=" + _term + " and WeekNumber=" + _week +
                "and BeginDayOfWeek=DATEPART(weekday, GETDATE())-1 " +
                "and convert(nvarchar(5),GETDATE(),114)>convert(nvarchar(5),BeginTime,114) " +
                "and convert(nvarchar(5),GETDATE(),114)<convert(nvarchar(5),EndTime,114)"; 
        }
    }
}
