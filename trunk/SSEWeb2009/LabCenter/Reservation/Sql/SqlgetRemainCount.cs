using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetRemainCount:ISql
    {
        int spanNum = -1;

        public SqlgetRemainCount()
        {

        }

        public SqlgetRemainCount(int spannum)
        {
            spanNum = spannum;
        }

        public string GetSql()
        {
            return "select RemainCount from TimeInfo where TimeSpanID = '" + spanNum + "'";
        }
    }
}
