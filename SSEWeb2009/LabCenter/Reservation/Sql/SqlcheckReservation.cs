using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlcheckReservation:ISql
    {
        string _stuid;
        int _term;
        int _week;

        public SqlcheckReservation(){}

        public SqlcheckReservation(string stuid,int term,int week)
        {
            _stuid = stuid;
            _term = term;
            _week = week;
        }

        public string GetSql()
        {
            return "select A.DateIndex from StuReservationInfo A,DateInfo B,TimeInfo C " +
                "where StuID = '" + _stuid + "' and ReservationState = 0 " +
                "and B.DateIndex = A.DateIndex and C.TimeSpanID = B.TimeSpanID " +
                "and TermNumber = " + _term + " and WeekNumber = " + _week +
                " and isnull(EndDayOfWeek,BeginDayOfWeek) = DATEPART(weekday,GETDATE())-1 " +
                "and convert(nvarchar(5),GETDATE(),114)>convert(nvarchar(5),EndTime,114)";
        }
    }
}
