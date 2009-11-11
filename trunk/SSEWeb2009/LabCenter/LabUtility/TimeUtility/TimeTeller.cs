using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.TimeUtility
{
    public class TimeTeller
    {
        public static String Diff(DateTime dt,DateTime dtcompareto)
        {
            return Diff(dt, dtcompareto, 2);
        }

        public static String Diff(DateTime dt,DateTime dtcompareto,int descriptNumber)
        {
            String ret=null;
            long ticks = dt.Ticks - dtcompareto.Ticks;
            //>0 表示dt是之后
            //<0 表示dt是前

            int descriptCount = 0;

            DateTime dif = new DateTime(Math.Abs(ticks));

            if (descriptCount<descriptNumber && dif.Year-1!=0)
            {
                ret += (dif.Year - 1).ToString()+"年";
                ++descriptCount;
            }
            if (descriptCount < descriptNumber && dif.Month - 1 != 0)
            {
                ret += (dif.Month - 1).ToString() + "个月";
                ++descriptCount;
            }
            if (descriptCount < descriptNumber && dif.Day - 1 != 0)
            {
                ret += (dif.Day - 1).ToString() + "天";
                ++descriptCount;
            }
            if (descriptCount < descriptNumber && dif.Hour != 0)
            {
                ret += dif.Hour.ToString() + "小时";
                ++descriptCount;
            }
            if (descriptCount < descriptNumber && dif.Minute != 0)
            {
                ret += dif.Minute.ToString() + "分钟";
                ++descriptCount;
            }
            if (descriptCount < descriptNumber && dif.Second != 0)
            {
                ret += dif.Second.ToString() + "秒";
                ++descriptCount;
            }
            if (ticks>0)
            {
                ret += "后";
            }
            else if (ticks<0)
            {
                ret += "前";
            }
            else
            {
                ret = "现在";
            }
            return ret;
        }

        public static double DiffHour(DateTime dt,DateTime dtcompareto)
        {
            long ticks = dt.Ticks - dtcompareto.Ticks;
            //>0 表示dt是之后
            //<0 表示dt是前
            double ret;
            ret = (double)ticks / 36000000000;
            return ret;
        }
    }
}
