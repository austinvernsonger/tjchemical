using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.LabUtility.XmlBase;

namespace LabCenter.Reservation
{   
    public struct MyTimeSpan:ICloneable
    {
        public MyTimeSpan(string begintime,string endtime,int endday)
        {
            begin = begintime;
            end = endtime;
            enddayofweek = endday;
        }
        public MyTimeSpan(string begintime, string endtime)
        {
            begin = begintime;
            end = endtime;
            enddayofweek = -1;
        } 
        /// <summary>
        /// example: 7:00
        /// </summary>
        public string begin;
        public string end;
        /// <summary>
        /// 结束日，如周一用1表示，-1表示当日结束
        /// </summary>
        public int enddayofweek;

        public object Clone()
        {
            MyTimeSpan ret = new MyTimeSpan(begin, end, enddayofweek);
            return ret;
        }
    };
    public class TimeTable:XmlParseBase,ICloneable
    {
        public TimeTable(){}
        public TimeTable(string path):base(path){}

        private List<MyTimeSpan> m_monday=new List<MyTimeSpan>();
        /// <summary>
        /// 礼拜一
        /// </summary>
        public List<MyTimeSpan> Monday
        {
            get { return m_monday; }
            set { m_monday = value; }
        }

        private List<MyTimeSpan> m_tuesday=new List<MyTimeSpan>();
        /// <summary>
        /// 礼拜二
        /// </summary>
        public List<MyTimeSpan> Tuesday
        {
            get { return m_tuesday; }
            set { m_tuesday = value; }
        }

        private List<MyTimeSpan> m_wednesday = new List<MyTimeSpan>();
        /// <summary>
        /// 礼拜三
        /// </summary>
        public List<MyTimeSpan> Wednesday
        {
            get { return m_wednesday; }
            set { m_wednesday = value; }
        }

        private List<MyTimeSpan> m_thursday=new List<MyTimeSpan>();
        /// <summary>
        /// 礼拜四
        /// </summary>
        public List<MyTimeSpan> Thursday
        {
            get { return m_thursday; }
            set { m_thursday = value; }
        }

        private List<MyTimeSpan> m_friday=new List<MyTimeSpan>();
        /// <summary>
        /// 礼拜五
        /// </summary>
        public List<MyTimeSpan> Friday
        {
            get { return m_friday; }
            set { m_friday = value; }
        }

        private List<MyTimeSpan> m_saturday=new List<MyTimeSpan>();
        /// <summary>
        /// 礼拜六
        /// </summary>
        public List<MyTimeSpan> Saturday
        {
            get { return m_saturday; }
            set { m_saturday = value; }
        }

        /// <summary>
        /// 将无效项去除
        /// </summary>
        public void CleanUp()
        {
            _Help_CleanUp(m_monday,1);
            _Help_CleanUp(m_tuesday,2);
            _Help_CleanUp(m_wednesday,3);
            _Help_CleanUp(m_thursday,4);
            _Help_CleanUp(m_friday,5);
            _Help_CleanUp(m_saturday,6);
        }
        private void _Help_CleanUp(List<MyTimeSpan> day,int dayofweek)
        {
            for (int i = 0; i != day.Count;++i )
            {
                MyTimeSpan mts = day[i];
                if (null == mts.begin || mts.begin.Equals(""))
                {
                    day.RemoveAt(i);
                    --i;
                }
                else if (null == mts.end || mts.end.Equals(""))
                {
                    day.RemoveAt(i);
                    --i;
                }
                else if(dayofweek<=0 || dayofweek>=7)
                {
                    day.RemoveAt(i);
                    --i;
                }
                else
                {
                    mts.begin = mts.begin.Trim();
                    mts.end = mts.end.Trim();
                }
            }
        }
        public object Clone()
        {
            TimeTable ret = new TimeTable();
            foreach (MyTimeSpan mts in Monday)
            {
                ret.Monday.Add(mts);
            }
            foreach(MyTimeSpan mts in Tuesday)
            {
                ret.Tuesday.Add(mts);
            }
            foreach (MyTimeSpan mts in Wednesday)
            {
                ret.Wednesday.Add(mts);
            }
            foreach (MyTimeSpan mts in Thursday)
            {
                ret.Thursday.Add(mts);
            }
            foreach (MyTimeSpan mts in Friday)
            {
                ret.Friday.Add(mts);
            }
            foreach (MyTimeSpan mts in Saturday)
            {
                ret.Saturday.Add(mts);
            }
            return ret;
        }
    }
}
