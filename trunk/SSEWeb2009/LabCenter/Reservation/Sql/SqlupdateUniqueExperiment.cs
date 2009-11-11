using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlupdateUniqueExperiment:ISql
    {
        int _experimentid;
        string _experimentname;
        int _ifvalid;

        public SqlupdateUniqueExperiment()
        {

        }

        public SqlupdateUniqueExperiment(int experimentid, string experimentname, int ifvalid)
        {
            _experimentid = experimentid;
            _experimentname = experimentname;
            _ifvalid = ifvalid;
        }

        public string GetSql()
        {
            return "update ExperimentInfo set ExperimentName = '"+_experimentname+"', IfValid = '"
                +_ifvalid+"' where ExperimentID = '"+_experimentid+"'";
        }
    }
}
