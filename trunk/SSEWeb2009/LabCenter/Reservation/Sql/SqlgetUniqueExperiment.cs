using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetUniqueExperiment:ISql
    {
        int _experimentid;
        public SqlgetUniqueExperiment()
        {

        }

        public SqlgetUniqueExperiment(int experimentid)
        {
            _experimentid = experimentid;
        }

        public string GetSql()
        {
            return "select * from ExperimentInfo where ExperimentID ='"+_experimentid+"'";
        }
    }
}
