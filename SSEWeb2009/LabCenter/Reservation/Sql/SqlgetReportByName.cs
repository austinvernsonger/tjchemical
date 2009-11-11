using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportByName:ISql
    {
        int _name;

        public SqlgetReportByName(){}

        public SqlgetReportByName(int name)
        {
            _name = name;
        }

        public string GetSql()
        {
            return "select StuID,ExperimentName,ReportState from StuLabInfo,ExperimentInfo where StuLabInfo.ExperimentID = ExperimentInfo.ExperimentID and StuLabInfo.ExperimentID = '" + _name + "'";
        }
    }
}
