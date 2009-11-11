using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetReportCount:ISql
    {
        int _term;
        public SqlgetReportCount(){}

        public SqlgetReportCount(int term)
        {
            _term = term;
        }

        public string GetSql()
        {
            return "select count(*) from StuLabInfo where TermNumber=" + _term;
        }
    }
}
