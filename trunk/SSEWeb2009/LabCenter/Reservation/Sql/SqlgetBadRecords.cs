using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetBadRecords:ISql
    {
        public SqlgetBadRecords()
        {

        }
        public string GetSql()
        {
            return "SELECT StuID, PenaltySetTime, PenaltyRecord FROM StuReservationInfo WHERE IfPenalty = 1 order by PenaltySetTime desc";
        }
    }
}
