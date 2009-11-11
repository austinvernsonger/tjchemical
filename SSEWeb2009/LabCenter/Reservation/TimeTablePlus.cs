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
        /// ѧ��ѧ��
        /// </summary>
        public int TermNumber
        {
            get { return m_termnumber; }
            set { m_termnumber = value; }
        }

        
        private int m_weeknumber;
        /// <summary>
        /// ��
        /// </summary>
        public int WeekNumber
        {
            get { return m_weeknumber; }
            set { m_weeknumber = value; }
        }

        
        private int m_remaincount;
        /// <summary>
        /// �豸ʣ����
        /// </summary>
        public int RemainCount
        {
            get { return m_remaincount; }
            set { m_remaincount = value; }
        }

        
        private TimeTable m_timetable;
        /// <summary>
        /// ʱ���
        /// </summary>
        public TimeTable TTable
        {
            get { return m_timetable; }
            set { m_timetable = value; }
        }
    }
}
