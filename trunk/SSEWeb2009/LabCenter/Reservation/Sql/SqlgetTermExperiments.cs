using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetTermExperiments:ISql
    {
        int m_term;
        public SqlgetTermExperiments(int Term)
        {
            m_term = Term;
        }

        public string GetSql()
        {
            return "select A.ExperimentID,ExperimentName from (select distinct ExperimentID from StuLabInfo where TermNumber = " + m_term.ToString() + " ) A " +
                    "left join ExperimentInfo as B on B.ExperimentID=A.ExperimentID order by A.ExperimentID";
        }
    }
}
