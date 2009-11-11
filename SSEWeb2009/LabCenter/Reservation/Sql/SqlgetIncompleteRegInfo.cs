using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetIncompleteRegInfo:ISql
    {
        string _stuid;
        int _term;
        int _week;
        public SqlgetIncompleteRegInfo(){}

        public SqlgetIncompleteRegInfo(string stuid,int term,int week)
        {
            _stuid = stuid;
            _term = term;
            _week = week;
        }

        public string GetSql()
        {
            return "select A.DateIndex as DateIndex,LoginTime,DeviceID,convert(nvarchar(5),BeginTime,114) as BeginTime," +
                "EndDayOfWeek,convert(nvarchar(5),EndTime,114) as EndTime,ExperimentName from RegInfo A,DateInfo B,TimeInfo C,ExperimentInfo D,StuReservationInfo E " +
                "where A.StuID = '" + _stuid + "' and LogoutTime is null " +
                "and A.DateIndex = E.DateIndex and ReservationState = 1 and IfPenalty = 0 " +
                "and A.DateIndex = B.DateIndex and B.ExperimentID = D.ExperimentID and B.TimeSpanID = C.TimeSpanID " +
                "and TermNumber = " + _term + " and WeekNumber = " + _week + " and BeginDayOfWeek = DATEPART(weekday,GETDATE())-1";
        }
    }
}
