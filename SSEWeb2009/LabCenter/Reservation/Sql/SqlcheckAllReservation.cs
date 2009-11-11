using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlcheckAllReservation:ISql
    {
        int _term;
        int _week;

        public SqlcheckAllReservation(){}

        public SqlcheckAllReservation(int term,int week)
        {
            _term = term;
            _week = week;
        }

        public string GetSql()
        {
            return "select StuID,A.DateIndex as dateindex " +
                    "from StuReservationInfo A,DateInfo B,TimeInfo C " +
                    "where ReservationState = 0 and B.DateIndex = A.DateIndex and C.TimeSpanID = B.TimeSpanID " +
                    "and ((TermNumber < " + _term + ") or (TermNumber = " + _term + " and WeekNumber < " + _week + ") or" +
                    "(TermNumber = " + _term + " and WeekNumber = " + _week + " and isnull(EndDayOfWeek,BeginDayOfWeek) < DATEPART(weekday,GETDATE())-1) or " +
                    "(TermNumber = " + _term + " and WeekNumber = " + _week + " and isnull(EndDayOfWeek,BeginDayOfWeek) = DATEPART(weekday,GETDATE())-1) and convert(nvarchar(5),GETDATE(),114)>convert(nvarchar(5),EndTime,114))";
        }
    }
}
