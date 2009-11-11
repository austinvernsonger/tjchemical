using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Reservation
{
    public class TimeTablePlus
    {
        public TimeTablePlus(int term,int week,int count,TimeTable tt)
        {
            TermNumber = term;
            WeekNumber = week;
            RemainCount = count;
            TTable = tt;
        }
        private int m_termnumber;
        /// <summary>
        /// 学年学期
        /// </summary>
        public int TermNumber
        {
            get { return m_termnumber; }
            set { m_termnumber = value; }
        }

        
        private int m_weeknumber;
        /// <summary>
        /// 周
        /// </summary>
        public int WeekNumber
        {
            get { return m_weeknumber; }
            set { m_weeknumber = value; }
        }

        
        private int m_remaincount;
        /// <summary>
        /// 设备剩余数
        /// </summary>
        public int RemainCount
        {
            get { return m_remaincount; }
            set { m_remaincount = value; }
        }

        
        private TimeTable m_timetable;
        /// <summary>
        /// 时间表
        /// </summary>
        public TimeTable TTable
        {
            get { return m_timetable; }
            set { m_timetable = value; }
        }
    }
}
