using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Reservation
{
    public class TimeSpanTableAdapter
    {
        /// <summary>
        /// ��TimeSpanStd��TimeTable������ת��
        /// </summary>
        /// <param name="tsslist"></param>
        /// <returns></returns>
        public static TimeTable ToTimeTable(List<TimeSpanStd> tsslist)
        {
            //��¼6���ʱ��Σ���һ������
            List<TimeSpanStd>[] sevenlist = new List<TimeSpanStd>[7];
            //��ʼ��
            for (int i = 0; i!=7; ++i)
            {
                sevenlist[i] = new List<TimeSpanStd>();
            }
            //��ԭʼʱ��η����ڷ���6���ʱ����б���
            foreach (TimeSpanStd tss in tsslist)
            {
                if (tss.beginday >= 1 && tss.beginday <= 6)
                {
                    sevenlist[tss.beginday].Add(tss);
                }
            }
            //Sortһ��
            for (int i = 0; i != sevenlist.Length; ++i)
            {
                sevenlist[i].Sort();
            }
            //��Ҫ������
            TimeTable tt = new TimeTable();
            //
            tt.Monday = ToTimeSpanList(sevenlist[1]);
            tt.Tuesday = ToTimeSpanList(sevenlist[2]);
            tt.Wednesday = ToTimeSpanList(sevenlist[3]);
            tt.Thursday = ToTimeSpanList(sevenlist[4]);
            tt.Friday = ToTimeSpanList(sevenlist[5]);
            tt.Saturday = ToTimeSpanList(sevenlist[6]);
            return tt;
        }
        /// <summary>
        /// ��TimeTable��TimeSpanStdList������ת��
        /// </summary>
        /// <param name="tt"></param>
        /// <returns></returns>
        public static List<TimeSpanStd> ToTimeSpanStdList(TimeTable tt)
        {
            return null;
        }

        /// <summary>
        /// ��TimeSpanStdList��TimeSpanList������ת��
        /// </summary>
        /// <param name="tsslist"></param>
        /// <returns></returns>
        public static List<MyTimeSpan> ToTimeSpanList(List<TimeSpanStd> tsslist)
        {
            List<MyTimeSpan> tslist = new List<MyTimeSpan>();
            foreach(TimeSpanStd tss in tsslist)
            {
                tslist.Add(new MyTimeSpan(tss.GetBeginTime(), tss.GetEndTime(), tss.endday));
            }
            return tslist;
        }

        /// <summary>
        /// ��TimeSpanStdList��TimeSpanList������ת������Ϊ�и��ӵ�����Ϣ
        /// </summary>
        /// <param name="tsslist"></param>
        /// <returns></returns>
        public static List<TimeSpanStd> ToTimeSpanStdList(List<MyTimeSpan> tslist,int beginday)
        {
            List<TimeSpanStd> tsslist = new List<TimeSpanStd>();
            foreach (MyTimeSpan ts in tslist)
            {
                //tsslist.Add(new TimeSpanStd(,tss.GetBeginTime(), tss.GetEndTime(), tss.endday));
            }
            return tsslist;
        }
    }
}
