using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReservationDetails:ISql
    {
        int _dateindex;
        public SqlgetReservationDetails()
        {

        }

        public SqlgetReservationDetails(int dateindex)
        {
            _dateindex = dateindex;
        }

        public string GetSql()
        {
            return "select ExperimentInfo.ExperimentID,ExperimentName,TermNumber,WeekNumber,BeginDayOfWeek,convert(nvarchar(5),BeginTime,114) as BeginTime,EndDayOfWeek,convert(nvarchar(5),EndTime,114) as EndTime " +
                "from ExperimentInfo,TimeInfo,DateInfo "+
                "where DateInfo.DateIndex ="+_dateindex+" and DateInfo.ExperimentID = ExperimentInfo.ExperimentID "+
                "and DateInfo.TimeSpanID = TimeInfo.TimeSpanID";
        }
    }
}
