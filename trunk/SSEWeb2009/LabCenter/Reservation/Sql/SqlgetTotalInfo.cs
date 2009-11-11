using System;
using System.Collections.Generic;
using System.Text;

using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    public class SqlgetTotalInfo:ISql
    {
        string m_termnumber;
        List<int> m_experimentID;
        public SqlgetTotalInfo(string termnumber,List<int> experimentID)
        {
            m_termnumber = termnumber;
            m_experimentID = experimentID;
        }
        public string GetSql()
        {
            StringBuilder sql=new StringBuilder(1600);
            sql.Append("select A.*,isnull(PenaltyCount,0)'违规次数' from (select StuID ");
            foreach(int i in m_experimentID)
            {
                sql.Append(" ,Round(Convert(float(8),isnull(sum(case ExperimentID when " + i.ToString() + " then TimeForExp end),0))/60,1)' " + i.ToString() + " ' ");
            }
            sql.Append(" ,Round(Convert(float(8),isnull(sum(TimeForExp),0))/60,1) '实验时间累计', " +
                            " isnull(sum(CAST(ReportState as int)),0) '已交报告份数' " +
                            " from StuLabInfo where TermNumber = " + m_termnumber +
                            " group by StuID ) as A left join " +
                    " (select StuID,isnull(sum(CAST(IfPenalty as int)),0)'PenaltyCount' " +
	                        " from StuReservationInfo where DateIndex in " +
		                        " (select DateIndex from DateInfo inner join TimeInfo " +
		                        " on DateInfo.TimeSpanID = TimeInfo.TimeSpanID " + 
		                        " where TimeInfo.TermNumber = " + m_termnumber +
                                ") group by StuID ) as B " +
                    " on A.StuID = B.StuID ");
            return sql.ToString();
        }
    }
}
