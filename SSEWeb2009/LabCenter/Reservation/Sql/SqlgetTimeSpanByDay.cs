using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetTimeSpanByDay:ISql
    {
        int dayofweek = -1;
        int currentterm;
        int currentweek;

        public SqlgetTimeSpanByDay(int dow,int term,int week)
        {
            dayofweek = dow;
            currentterm = term;
            currentweek = week;
        }

        public SqlgetTimeSpanByDay()
        {

        }

        public string GetSql()
        {
            return "SELECT convert(varchar(5),[BeginTime],114) as BeginTime," +
                    "convert(varchar(5),[EndTime],114) as EndTime, [TimeSpanID] as spannumber,[EndDayOfWeek] FROM [TimeInfo]" +
                    "where [BeginDayOfWeek] = "+dayofweek+" and TermNumber = "+currentterm+" and WeekNumber = "+currentweek+" ORDER BY [BeginTime]";
        }
    }
}
