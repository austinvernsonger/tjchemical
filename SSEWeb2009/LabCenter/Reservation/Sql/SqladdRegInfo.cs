using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqladdRegInfo:ISql
    {
        string _stuid;
        int _dateindex;
        string _logintime;
        int _devicenum;

        public SqladdRegInfo(){}

        public SqladdRegInfo(string stuid,int dateindex,string logintime,int devicenum)
        {
            _stuid = stuid;
            _dateindex = dateindex;
            _logintime = logintime;
            _devicenum = devicenum;
        }

        public string GetSql()
        {
            return "insert into RegInfo(StuID,DateIndex,LoginTime,DeviceID) values('" + _stuid + "'," + _dateindex + ",'" + _logintime + "'," + _devicenum + ")";
        }
    }
}
