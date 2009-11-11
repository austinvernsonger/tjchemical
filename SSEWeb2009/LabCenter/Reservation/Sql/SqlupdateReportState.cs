using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlupdateReportState:ISql
    {
        string _stuid;
        string _expname;
        Boolean _state;

        public SqlupdateReportState(){}

        public SqlupdateReportState(string stuid,string expname,Boolean state)
        {
            _stuid = stuid;
            _expname = expname;
            _state = state;
        }

        public string GetSql()
        {
            if (_state)
                return "update StuLabInfo set ReportState = 1 where StuID= '" + _stuid + "' and ExperimentID = (select ExperimentID from ExperimentInfo where ExperimentName = '" + _expname + "')";
            else
                return "update StuLabInfo set ReportState = 0 where StuID= '" + _stuid + "' and ExperimentID = (select ExperimentID from ExperimentInfo where ExperimentName = '" + _expname + "')";
        }
    }
}
