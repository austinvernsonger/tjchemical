using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReservation:ISql
    {
        string stuID = "";

        public SqlgetReservation(){}

        public SqlgetReservation(string stuid)
        {
            stuID = stuid;
        }

        public string GetSql()
        {
            return "select ExperimentID,TimeInfo.TimeSpanID as TimeSpanID from DateInfo,StuReservationInfo,TimeInfo " +
                "where StuReservationInfo.DateIndex = DateInfo.DateIndex and DateInfo.TimeSpanID = TimeInfo.TimeSpanID " +
                "and ReservationState = 0 and StuID = '" + stuID + "'";
        }
    }
}
