using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetDateInfo:ISql
    {
        int spannumber = -1;
        public SqlgetDateInfo()
        {

        }

        public SqlgetDateInfo(int spnum)
        {
            spannumber = spnum;
        }

        public string GetSql()
        {
            return "SELECT ExperimentInfo.ExperimentID, ExperimentInfo.ExperimentName "+
                " FROM ExperimentInfo WHERE"+
                " (ExperimentInfo.ExperimentID IN (SELECT ExperimentID FROM DateInfo WHERE (TimeSpanID = '" + spannumber + "')))";
        }
    }
}
