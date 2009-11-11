using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqladdTimeinfo:ISql
    {
        int BeginDayOfWeek=-1;
        string BeginTime="";
        int EndDayOfWeek=-1;
        string EndTime="";
        int RemainCount=-1;
        int TermNumber=-1;
        int WeekNumber=-1;

        public SqladdTimeinfo()
        {

        }

        public SqladdTimeinfo(int bdow,string bt,int edow,string et,int rc,int tn,int wn)
        {
            BeginDayOfWeek = bdow;
            BeginTime = bt;
            EndDayOfWeek = edow;
            EndTime = et;
            RemainCount = rc;
            TermNumber = tn;
            WeekNumber = wn;
        }

        public string GetSql()
        {
            if(BeginDayOfWeek == EndDayOfWeek)
            {
                return "insert into TimeInfo(BeginDayOfWeek,BeginTime,EndTime,RemainCount,TermNumber,WeekNumber) " +
                "values('" + BeginDayOfWeek + "','" + BeginTime + "','" + EndTime + "','" + RemainCount + "','" + TermNumber + "','" + WeekNumber + "')";
            }
            else
            {
                return "insert into TimeInfo(BeginDayOfWeek,BeginTime,EndDayOfWeek,EndTime,RemainCount,TermNumber,WeekNumber) " +
                "values('" + BeginDayOfWeek + "','" + BeginTime + "','" + EndDayOfWeek + "','" + EndTime + "','" + RemainCount + "','" + TermNumber + "','" + WeekNumber + "')";
            
            }
        }
    }
}
