using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportsDS:ISql
    {
        int _term;
        public SqlgetReportsDS(){}

        public SqlgetReportsDS(int term)
        {
            _term = term;
        }

        public string GetSql()
        {
            return "select StuID,ExperimentName,ReportState from StuLabInfo,ExperimentInfo where StuLabInfo.ExperimentID = ExperimentInfo.ExperimentID and StuLabInfo.TermNumber = '"+_term+"'";
        }
    }
}
