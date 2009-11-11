using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetLogTime:ISql
    {
        string _stuid;
        int _dateindex;

        public SqlgetLogTime(){}

        public SqlgetLogTime(string stuid,int dateindex)
        {
            _stuid = stuid;
            _dateindex = dateindex;
        }

        public string GetSql()
        {
            return "select DATEDIFF(minute,LoginTime,LogoutTime) as minutes from RegInfo where StuID = '" + _stuid + "' and DateIndex = " + _dateindex;
        }
    }
}
