using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.TimeUtility
{
    public class TermWeekTeller
    {
        /// <summary>
        /// 计算theday是以beginday为第一周开始计的第几周
        /// 每周都以周一开始，beginday为周日则表示第一周只有1天
        /// </summary>
        /// <param name="beginday">第一周的某天</param>
        /// <param name="theday">要计算的某天</param>
        /// <returns>第几周</returns>
        public static int Week(DateTime beginday, DateTime theday)
        {
            DateTime begindaypro = new DateTime(beginday.Year, beginday.Month, beginday.Day);
            DateTime thedaypro = new DateTime(theday.Year, theday.Month, theday.Day);

            TimeSpan ts = new TimeSpan(thedaypro.Ticks - begindaypro.Ticks);
            int days = ts.Days;
            int dayofweekvalue = (int)begindaypro.DayOfWeek;
            if (begindaypro.DayOfWeek == DayOfWeek.Sunday)
            {
                dayofweekvalue = 7;
            }
            int ret = (days + dayofweekvalue + 6) / 7;
            return ret;
        }

        /// <summary>
        /// 现在是以beginday为第一周开始计的第几周
        /// </summary>
        /// <param name="beginday"></param>
        /// <returns></returns>
        public static int CurWeek(DateTime beginday)
        {
            return Week(beginday, DateTime.Now);
        }
    }
}
