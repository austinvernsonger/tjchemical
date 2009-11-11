using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetValidExperiment:ISql
    {
        public SqlgetValidExperiment()
        { }

        public string GetSql()
        {
            return "select ExperimentID,ExperimentName from ExperimentInfo where IfValid = '1' order by ExperimentID ";
        }
    }
}
