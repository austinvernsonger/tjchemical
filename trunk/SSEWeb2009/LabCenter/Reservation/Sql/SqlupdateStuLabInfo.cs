using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlupdateStuLabInfo:ISql
    {
        string _stuid;
        int _experimentid;
        int _currentterm;
        int _labtime;

        public SqlupdateStuLabInfo(){}

        public SqlupdateStuLabInfo(string stuid,int expid,int curterm,int labtime)
        {
            _stuid = stuid;
            _experimentid = expid;
            _labtime = labtime;
            _currentterm = curterm;
        }

        public string GetSql()
        {
            return "update StuLabInfo set TimeForExp = TimeForExp + " + _labtime +
                " where StuID = '" + _stuid + "' and ExperimentID = " + _experimentid + " and TermNumber = " + _currentterm;
        }
    }
}
