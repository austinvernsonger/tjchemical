using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlupdateRemainCount:ISql
    {
        int spanNum = -1;
        int newCount = 0;

        public SqlupdateRemainCount()
        {

        }

        public SqlupdateRemainCount(int spannum, int newcount)
        {
            spanNum = spannum;
            newCount = newcount;
        }

        public string GetSql()
        {
            return "update TimeInfo set RemainCount = RemainCount + " + newCount + " where TimeSpanID = " + spanNum;
        }
    }
}
