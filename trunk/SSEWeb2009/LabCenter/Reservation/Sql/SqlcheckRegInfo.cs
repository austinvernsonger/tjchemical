using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlcheckRegInfo:ISql
    {
        string _stuid;
        int _term;
        int _week;
        int _minute;

        public SqlcheckRegInfo(){}

        public SqlcheckRegInfo(string stuid,int term, int week,int minute)
        {
            _stuid = stuid;
            _term = term;
            _week = week;
            _minute = minute;
        }

        public string GetSql()
        {
            return "select A.DateIndex from RegInfo A,DateInfo B,TimeInfo C,StuReservationInfo D " +
                "where A.StuID = '" + _stuid + "' and LogoutTime is null " +
                "and D.DateIndex = A.DateIndex and ReservationState = 1 and IfPenalty = 0 " +
                "and  B.DateIndex = A.DateIndex and C.TimeSpanID = B.TimeSpanID " +
                "and TermNumber = " + _term + " and WeekNumber = " + _week +
                " and isnull(EndDayOfWeek,BeginDayOfWeek) = DATEPART(weekday,GETDATE())-1 " +
                "and convert(nvarchar(5),GETDATE(),114)>convert(nvarchar(5),DATEADD(minute," + _minute + ",EndTime),114)";
        }
    }
}
