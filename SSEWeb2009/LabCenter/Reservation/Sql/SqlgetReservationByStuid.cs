using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReservationByStuid:ISql
    {
        string Stuid = "";

        public SqlgetReservationByStuid(){}

        public SqlgetReservationByStuid(string stuid)
        {
            Stuid = stuid;
        }

        public string GetSql()
        {
            return "select D.DateIndex as DateIndex,ExperimentName,BeginDayOfWeek,convert(nvarchar(5),BeginTime,8) as BeginTime,EndDayOfWeek,convert(nvarchar(5),EndTime,8) as EndTime " +
                    "from ExperimentInfo A,TimeInfo B,DateInfo C,StuReservationInfo D " +
                    "where D.DateIndex = C.DateIndex and D.ReservationState = 0 and C.ExperimentID = A.ExperimentID and C.TimeSpanID = B.TimeSpanID " +
                    "and D.StuID = '" + Stuid + "'";
        }
    }
}
