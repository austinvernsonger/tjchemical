using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportByNo:ISql
    {
        string _number;

        public SqlgetReportByNo(){}

        public SqlgetReportByNo(string number)
        {
            _number = number;
        }

        public string GetSql()
        {
            return "select StuID,ExperimentName,ReportState from StuLabInfo,ExperimentInfo where StuLabInfo.ExperimentID = ExperimentInfo.ExperimentID and StuLabInfo.StuID = '" + _number + "'";
        }
    }
}
