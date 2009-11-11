using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Reservation
{
    public class TimeSpanTableAdapter
    {
        /// <summary>
        /// 从TimeSpanStd到TimeTable的无损转换
        /// </summary>
        /// <param name="tsslist"></param>
        /// <returns></returns>
        public static TimeTable ToTimeTable(List<TimeSpanStd> tsslist)
        {
            //记录6天的时间段，第一个留空
            List<TimeSpanStd>[] sevenlist = new List<TimeSpanStd>[7];
            //初始化
            for (int i = 0; i!=7; ++i)
            {
                sevenlist[i] = new List<TimeSpanStd>();
            }
            //把原始时间段分星期放入6天的时间段列表中
            foreach (TimeSpanStd tss in tsslist)
            {
                if (tss.beginday >= 1 && tss.beginday <= 6)
                {
                    sevenlist[tss.beginday].Add(tss);
                }
            }
            //Sort一下
            for (int i = 0; i != sevenlist.Length; ++i)
            {
                sevenlist[i].Sort();
            }
            //快要结束啦
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
        /// 从TimeTable到TimeSpanStdList的无损转换
        /// </summary>
        /// <param name="tt"></param>
        /// <returns></returns>
        public static List<TimeSpanStd> ToTimeSpanStdList(TimeTable tt)
        {
            return null;
        }

        /// <summary>
        /// 从TimeSpanStdList到TimeSpanList的有损转换
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
        /// 从TimeSpanStdList到TimeSpanList的无损转换，因为有附加的天信息
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
