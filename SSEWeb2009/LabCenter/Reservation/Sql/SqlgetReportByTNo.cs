using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportByTNo:ISql
    {
        int _term;
        string _number;

        public SqlgetReportByTNo(){}

        public SqlgetReportByTNo(int term,string number)
        {
            _term = term;
            _number = number;
        }

        public string GetSql()
        {
            return "select StuID,ExperimentName,ReportState from StuLabInfo,ExperimentInfo where StuLabInfo.ExperimentID = ExperimentInfo.ExperimentID and StuLabInfo.TermNumber = '" 
                + _term + "' and StuLabInfo.StuID = '" + _number + "'";
        }
    }
}
