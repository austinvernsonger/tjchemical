using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetHistoryExperiment:ISql
    {
        int _termnumber = -1;
        int _weeknumber = -1;
        public SqlgetHistoryExperiment()
        {

        }

        public SqlgetHistoryExperiment(int termnumber,int weeknumber)
        {
            _termnumber = termnumber;
            _weeknumber = weeknumber;
        }

        public string GetSql()
        {
            return "select ExperimentName,ExperimentID from ExperimentInfo where ExperimentID in "+
                "(select distinct ExperimentID from DateInfo where TimeSpanID in "+
                "(select TimeSpanID from TimeInfo where TermNumber = '" + _termnumber + "' and WeekNumber = '" + _weeknumber + "')) order by ExperimentID";
        }
    }
}
