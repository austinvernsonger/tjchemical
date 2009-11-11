using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetExperiment:ISql
    {
        public SqlgetExperiment()
        {

        }

        public string GetSql()
        {
            return "select ExperimentID,ExperimentName from ExperimentInfo order by ExperimentID";
        }
    }
}
