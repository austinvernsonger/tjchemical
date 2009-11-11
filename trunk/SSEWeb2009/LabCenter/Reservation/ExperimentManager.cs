using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Reservation.Ops;
using LabCenter.Reservation.Sql;
using System.Data;

namespace LabCenter.Reservation
{
    public class ExperimentManager
    {
        private static string m_DbName = "LabCenter";
        public String ErrorMsg = "";

        public static List<Experiment> GetSelectedExperiment(int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetHistoryExperiment(term, week));
            i.Do();
            List<Experiment> le = new List<Experiment>();
            foreach (DataRow dr in i.Ds.Tables[0].Rows)
            {
                Experiment e = new Experiment();
                e.ID = (int)dr[1];
                e.Name = (String)dr[0];
                le.Add(e);
            }
            return le;
        }
    }
}
