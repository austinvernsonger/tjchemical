using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReport:ISql
    {
        string _stuid = "";

        public SqlgetReport(){}

        public SqlgetReport(string stuid)
        {
            _stuid = stuid;
        }

        public string GetSql()
        {
            return "select (select ExperimentName from ExperimentInfo where ExperimentID = A.ExperimentID) as ExperimentName,ReportState "+
                    "from StuLabInfo A where StuID = '"+_stuid+"'";
        }
    }
}
