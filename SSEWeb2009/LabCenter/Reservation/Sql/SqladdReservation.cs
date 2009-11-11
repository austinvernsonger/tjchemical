using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqladdReservation:ISql
    {
        string stuID = "";
        int ExpID = -1;
        int spanNum = -1;

        public SqladdReservation()
        {

        }
        
        public SqladdReservation(string stuid,int expid, int spannum)
        {
            stuID = stuid.Trim();
            ExpID = expid;
            spanNum = spannum;
        }

        public string GetSql()
        {
            return "insert into StuReservationInfo select '" + stuID + "',(select DateIndex from DateInfo where ExperimentID = " + ExpID +
                " and TimeSpanID = " + spanNum + "),0,0,null,null";
        }
    }
}
