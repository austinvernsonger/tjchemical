using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlcancelReservation:ISql
    {
        string _stuid = "";
        int _dateIndex = -1;

        public SqlcancelReservation(){}

        public SqlcancelReservation(string stuid, int dateIndex)
        {
            _stuid = stuid;
            _dateIndex = dateIndex;
        }

        public string GetSql()
        {
            return "delete from StuReservationInfo where StuID = '" + _stuid + "' and DateIndex = " + _dateIndex;
        }
    }
}
