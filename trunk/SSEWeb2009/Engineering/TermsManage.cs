using System;
using System.Collections.Generic;
using System.Text;

namespace Department.Engineering
{
    public class TermsManage
    {
        public TermsManage()
        { }

        public Dictionary<string, string> GetTerms()
        {
            Dictionary<string, string> term = new Dictionary<string, string>();
            DateTime date = DateTime.Now;
            term.Add("--请选择学期--", "0");
            for (int i = 0; i < 2; i++)
            {
                term.Add((date.Year + i).ToString() + "年 春", (date.Year + i).ToString() + "1");
                term.Add((date.Year + i).ToString() + "年 秋", (date.Year + i).ToString() + "0");
            }
            return term;
        }

        /// <summary>
        /// 返回当前年份向前推5年，向后推2年的年份
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetOtherTerms()
        {
            Dictionary<string, string> term = new Dictionary<string, string>();
            DateTime date = DateTime.Now;
            int therFirstYear = date.Year - 5;
            term.Add("--请选择学期--", "0");
            for (int i = 0; i < 8; i++)
            {
                term.Add((therFirstYear + i).ToString() + "年 春", (therFirstYear + i).ToString() + "1");
                term.Add((therFirstYear + i).ToString() + "年 秋", (therFirstYear + i).ToString() + "0");
            }
            return term;
        }

        public Dictionary<string, string> GetTermsWithStartYear()
        {
            Dictionary<string, string> term = new Dictionary<string, string>();
            int year = DateTime.Now.Year;
            int endYear = year + 1;
            term.Add("--请选择学期--", "0");
            for (int i = 2007; i <= endYear; i++)
            {
                term.Add(i.ToString() + "年 春", i.ToString() + "1");
                term.Add(i.ToString() + "年 秋", i.ToString() + "0");
            }
            return term;
        }
    }
}
