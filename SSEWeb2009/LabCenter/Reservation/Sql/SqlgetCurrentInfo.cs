using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetCurrentInfo:ISql
    {
        int _week;
        int _term;

        public SqlgetCurrentInfo(){}

        public SqlgetCurrentInfo(int week,int term)
        {
            _week = week;
            _term = term;
        }

        public string GetSql()
        {
            return "select convert(nvarchar(5),BeginTime,114) as BeginTime,RemainCount,B.DateIndex,ExperimentName " +
                "from TimeInfo A,DateInfo B,ExperimentInfo C " +
            "where B.ExperimentID = C.ExperimentID and B.TimeSpanID = A.TimeSpanID "+
            "and convert(nvarchar(5),GETDATE(),114)>convert(nvarchar(5),BeginTime,114) " +
            "and convert(nvarchar(5),GETDATE(),114)<convert(nvarchar(5),EndTime,114) "+
            "and TermNumber = " + _term + " and WeekNumber = " + _week + " and BeginDayOfWeek=DATEPART(weekday, getdate())-1";
        }
    }
}
