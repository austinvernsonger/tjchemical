using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportByTNa:ISql
    {
        int _term, _name;

        public SqlgetReportByTNa(){}

        public SqlgetReportByTNa(int term,int name)
        {
            _term = term;
            _name = name;
        }

        public string GetSql()
        {
            return "select StuID,ExperimentName,ReportState from StuLabInfo,ExperimentInfo where StuLabInfo.ExperimentID = ExperimentInfo.ExperimentID and StuLabInfo.TermNumber = '" + _term + "' and StuLabInfo.ExperimentID = '" + _name + "'";
        }
    }
}
