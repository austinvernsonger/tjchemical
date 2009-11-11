using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqladdStuLabInfo:ISql
    {
        string _stuid;
        int _experimentid;
        int _labtime;
        int _currentterm;

        public SqladdStuLabInfo(){}

        public SqladdStuLabInfo(string stuid,int expid,int labtime,int curterm)
        {
            _stuid = stuid;
            _experimentid = expid;
            _labtime = labtime;
            _currentterm = curterm;
        }

        public string GetSql()
        {
            return "insert into StuLabInfo values(" + _currentterm + ",'" + _stuid + "'," + _experimentid + ",0," + _labtime + ")";
        }
    }
}
