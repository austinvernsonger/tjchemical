using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetNextInfo:ISql
    {
        int _week;
        int _term;

        public SqlgetNextInfo(){}

        public SqlgetNextInfo(int week,int term)
        {
            _week = week;
            _term = term;
        }

        public string GetSql()
        {
            return "select A.RemainCount,B.DateIndex,C.ExperimentName from TimeInfo A,DateInfo B,ExperimentInfo C " +
                "where C.ExperimentID = B.ExperimentID and B.TimeSpanID = A.TimeSpanID " + 
                "and A.TimeSpanID = (select top 1 TimeSpanID from TimeInfo where " +
                "convert(nvarchar(5),GETDATE(),114)<convert(nvarchar(5),BeginTime,114) " +
                "and TermNumber = " + _term + " and WeekNumber = " + _week +
                " and BeginDayOfWeek=DATEPART(weekday, getdate())-1 ORDER BY BeginTime)";
        }
    }
}
