using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlgetCurrentStudentDS:ISql
    {
        int _term;
        int _week;

        public SqlgetCurrentStudentDS(){}

        public SqlgetCurrentStudentDS(int term,int week)
        {
            _term = term;
            _week = week;
        }

        public string GetSql()
        {
            return "select distinct ExperimentName as 实验名称,(select count(*) from RegInfo where LogoutTime IS NULL and RegInfo.DateIndex = D.DateIndex) as 当前实验人数 "+
                "from DateInfo as D,ExperimentInfo "+
                "where D.ExperimentID = ExperimentInfo.ExperimentID and TimeSpanID in "+
                "(select TimeSpanID from TimeInfo where TermNumber="+_term+" and WeekNumber= "+_week+
                " and BeginDayOfWeek=DATEPART(weekday, GETDATE())-1 " +
                "and convert(nvarchar(5),GETDATE(),8)>convert(nvarchar(5),BeginTime,8) "+
                "and convert(nvarchar(5),GETDATE(),8)<convert(nvarchar(5),EndTime,8))";
        }
    }
}
