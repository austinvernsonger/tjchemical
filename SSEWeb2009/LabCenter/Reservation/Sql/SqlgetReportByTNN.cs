using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportByTNN:ISql
    {
        int _term, _name;
        string _number;

        public SqlgetReportByTNN(){}

        public SqlgetReportByTNN(int term,int name,string number)
        {
            _term = term;
            _name = name;
            _number = number;
        }

        public string GetSql()
        {
            return "select StuID,ExperimentName,ReportState from StuLabInfo,ExperimentInfo where StuLabInfo.ExperimentID = ExperimentInfo.ExperimentID and StuLabInfo.TermNumber = '" + _term + "' and StuLabInfo.StuID = '" 
                + _number + "' and StuLabInfo.ExperimentID = '" + _name + "'";
        }
    }
}
