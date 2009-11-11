using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqladdDateInfo:ISql
    {
        int _experimentid = -1;
        int _termnumber = -1;
        int _weeknumber = -1;

        public SqladdDateInfo(){}

        public SqladdDateInfo(int experimentid,int termnumber, int weeknumber)
        {
            _experimentid = experimentid;
            _termnumber = termnumber;
            _weeknumber = weeknumber;
        }

        public string GetSql()
        {
            return "insert into DateInfo(ExperimentID,TimeSpanID) " +
                "select '" + _experimentid + "',TimeSpanID from TimeInfo where TermNumber='" + _termnumber +
                "' and WeekNumber='" + _weeknumber + "'";
        }
    }
}
