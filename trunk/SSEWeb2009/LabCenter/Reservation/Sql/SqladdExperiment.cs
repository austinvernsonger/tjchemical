using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqladdExperiment:ISql
    {
        string _experimentname;
        public SqladdExperiment()
        {

        }

        public SqladdExperiment(string experimentname)
        {
            _experimentname = experimentname;
        }

        public string GetSql()
        {
            return "insert into ExperimentInfo(ExperimentName,IfValid) values('" + _experimentname + "',0)";
        }
    }
}
