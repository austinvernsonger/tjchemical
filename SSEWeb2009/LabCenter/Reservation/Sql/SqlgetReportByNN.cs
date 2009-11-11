using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportByNN:ISql
    {
        int _name;
        string _number;

        public SqlgetReportByNN(){}

        public SqlgetReportByNN(int name,string number)
        {
            _name = name;
            _number = number;
        }

        public string GetSql()
        {
            return "select StuID,ExperimentName,ReportState from StuLabInfo,ExperimentInfo where StuLabInfo.ExperimentID = ExperimentInfo.ExperimentID and StuLabInfo.ExperimentID = '" 
                + _name + "' and StuLabInfo.StuID = '" + _number + "'";
        }
    }
}
