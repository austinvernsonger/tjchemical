using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LabCenter.Reservation.Ops;
using LabCenter.Reservation.Sql;

namespace LabCenter.Reservation
{
    public class TimeTableManager
    {
        private static string m_DbName = "LabCenter";
        public String ErrorMsg = "";

        public List<TimeSpanStd> GetTimeSpanStdList(string term,string week)
        {
            OpReservationQuery q=new OpReservationQuery(m_DbName,
                new SqlgetTimeSpanByYearWeek(term,week));
            q.Do();
            DataRowCollection drc = q.Ds.Tables[0].Rows;
            List<TimeSpanStd> tsslist = new List<TimeSpanStd>(70);
            foreach(DataRow dr in drc)
            {
                TimeSpanStd tss = new TimeSpanStd((Int32)dr[0], (Int32)dr[1], (DateTime)dr[2],
                    (Int32)dr[3], (DateTime)dr[4], (Int32)dr[5]);
                tsslist.Add(tss);
            }
            return tsslist;
        }
        public TimeTable GetTimeTable(string term,string week)
        {
            List<TimeSpanStd> tsslist = GetTimeSpanStdList(term, week);
            TimeTable tt = TimeSpanTableAdapter.ToTimeTable(tsslist);
            return tt;
        }
    }
}
