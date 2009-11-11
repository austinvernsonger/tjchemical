using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetCurrentReservation:ISql
    {
        string _stuid;
        int _curterm;
        int _curweek;

        public SqlgetCurrentReservation()
        {

        }

        public SqlgetCurrentReservation(string stuid,int curterm,int curweek)
        {
            _stuid = stuid;
            _curterm = curterm;
            _curweek = curweek;
        }

        public string GetSql()
        {
            return "select A.DateIndex from StuReservationInfo A,DateInfo B,TimeInfo C where A.StuID = '"
                + _stuid + "' and A.ReservationState = 0 and A.DateIndex = B.DateIndex and B.TimeSpanID = C.TimeSpanID " +
                "and TermNumber = " + _curterm + " and WeekNumber = " + _curweek +
                " and ((BeginDayOfWeek=DATEPART(weekday, GETDATE())-1 and isnull(EndDayOfWeek,BeginDayOfWeek) = DATEPART(weekday, GETDATE())-1 " +
                "and convert(nvarchar(5),GETDATE(),114)>convert(nvarchar(5),BeginTime,114) " +
                "and convert(nvarchar(5),GETDATE(),114)<convert(nvarchar(5),EndTime,114)) "+
                "or (BeginDayOfWeek=DATEPART(weekday, GETDATE())-1 and EndDayOfWeek <> DATEPART(weekday, GETDATE())-1 " +
                "and convert(nvarchar(5),GETDATE(),114)>convert(nvarchar(5),BeginTime,114) ))";
        }
    }
}
