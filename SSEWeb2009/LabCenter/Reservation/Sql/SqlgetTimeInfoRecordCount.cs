using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetTimeInfoRecordCount:ISql
    {
        int _termnumber = -1;
        int _weeknumber = -1;
        public SqlgetTimeInfoRecordCount()
        {

        }

        public SqlgetTimeInfoRecordCount(int termnumber,int weeknumber)
        {
            _termnumber = termnumber;
            _weeknumber = weeknumber;
        }

        public string GetSql()
        {
            return "select count(*) from TimeInfo where TermNumber='" + _termnumber + "' and WeekNumber='"+_weeknumber+"'";
        }
    }
}
