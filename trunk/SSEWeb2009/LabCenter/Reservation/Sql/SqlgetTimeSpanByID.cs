using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetTimeSpanByID:ISql
    {
        int spanID = -1;

        public SqlgetTimeSpanByID(){}

        public SqlgetTimeSpanByID(int spanid)
        {
            spanID = spanid;
        }

        public string GetSql()
        {
            return "select BeginDayOfWeek,convert(varchar(5),BeginTime,8) as BeginTime,"+
                "EndDayOfWeek,convert(varchar(5),EndTime,8) as EndTime from TimeInfo where TimeSpanID = '" + spanID + "'";
        }
    }
}
