using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetDateInfoDetails:ISql
    {
        int _dateindex;

        public SqlgetDateInfoDetails(){}

        public SqlgetDateInfoDetails(int dateindex)
        {
            _dateindex = dateindex;
        }

        public string GetSql()
        {
            return "select TimeSpanID,ExperimentID from DateInfo " +
                "where DateIndex = " + _dateindex;
        }
    }
}
