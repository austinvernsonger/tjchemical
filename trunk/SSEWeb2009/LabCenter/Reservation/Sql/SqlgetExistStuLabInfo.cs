using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetExistStuLabInfo:ISql
    {
        string _stuid;
        int _experimentid;
        int _currentterm;

        public SqlgetExistStuLabInfo(){}

        public SqlgetExistStuLabInfo(string stuid,int expid,int curterm)
        {
            _stuid = stuid;
            _experimentid = expid;
            _currentterm = curterm;
        }

        public string GetSql()
        {
            return "select count(*) from StuLabInfo where StuID = '" + _stuid + 
                "' and ExperimentID = " + _experimentid + " and TermNumber = " + _currentterm;
        }
    }
}
