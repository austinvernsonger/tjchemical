using System;
using System.Collections.Generic;
using System.Text;


namespace LabCenter.Reservation
{
    /// <summary>
    /// ��׼��ʱ��Σ���һ��TimeSpan����TimeTableֱ����ϵ�ģ������TimeTableû�����
    /// ����Ǵ���һ����9�㵽�ܶ�����13���Ļ�
    /// id=���ݿ���id
    /// beginday=1 beginhour=9 beginminute=0
    /// endday=2 endhour=13 endminute=30
    /// </summary>
    public struct TimeSpanStd:IComparable
    {
        public TimeSpanStd(Int32 tsid,Int32 tsbeginday,String tsbegintime,
            Int32 tsendday,String tsendtime,Int32 tsremaincount)
        {
            id = tsid;
            beginday = tsbeginday;
            string[] begin=tsbegintime.Split(new char[] { ':' });
            beginhour = Int32.Parse(begin[0]);
            beginminute = Int32.Parse(begin[1]);
            endday = tsendday;
            string[] end = tsendtime.Split(new char[] { ':' });
            endhour = Int32.Parse(end[0]);
            endminute = Int32.Parse(end[1]);
            remaincount = tsremaincount;
        }
        public TimeSpanStd(Int32 tsid,Int32 tsbeginday,DateTime tsbegintime,
            Int32 tsendday,DateTime tsendtime,Int32 tsremaincount)
        {
            id = tsid;
            beginday = tsbeginday;
            beginhour = tsbegintime.Hour;
            beginminute = tsbegintime.Minute;
            endday = tsendday;
            endhour = tsendtime.Hour;
            endminute = tsendtime.Minute;
            remaincount = tsremaincount;
        }
        public TimeSpanStd(Int32 tsid,Int32 tsbeginday,Int32 tsbeginhour,Int32 tsbeginminute,
            Int32 tsendday,Int32 tsendhour,Int32 tsendminute,Int32 tsremaincount)
        {
            id = tsid;
            beginday = tsbeginday;
            beginhour = tsbeginhour;
            beginminute = tsbeginminute;
            endday = tsendday;
            endhour = tsendhour;
            endminute = tsendminute;
            remaincount=tsremaincount;
        }
        public Int32 id;
        public Int32 beginday;
        public Int32 beginhour;
        public Int32 beginminute;
        public Int32 endday;
        public Int32 endhour;
        public Int32 endminute;
        public Int32 remaincount;
        public String GetBeginTime()
        {
            return String.Format("{0:00}:{1:00}", beginhour, beginminute);
        }
        public String GetEndTime()
        {
            return String.Format("{0:00}:{1:00}",endhour,endminute);
        }
        public override string ToString()
        {
            return String.Format("���{0}��{1} {2}����{3} {4}", id, beginday, GetBeginTime(), endday, GetEndTime());
        }
        public int CompareTo(Object obj)
        {
            TimeSpanStd tss = (TimeSpanStd)obj;
            if(this.beginhour==tss.beginhour)
            {
                return this.beginminute.CompareTo(tss.beginminute);
            }
            else
            {
                return this.beginhour.CompareTo(tss.beginhour);
            }
        }
    }
}
