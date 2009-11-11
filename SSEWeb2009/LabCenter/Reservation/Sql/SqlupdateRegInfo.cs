using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlupdateRegInfo:ISql
    {
        string _stuid;
        int _dateindex;

        public SqlupdateRegInfo(){}

        public SqlupdateRegInfo(string stuid,int dateindex)
        {
            _stuid = stuid;
            _dateindex = dateindex;
        }

        public string GetSql()
        {
            return "update RegInfo set LogoutTime = GETDATE() where StuID = '" + _stuid + "' and DateIndex = " + _dateindex;
        }
    }
}
