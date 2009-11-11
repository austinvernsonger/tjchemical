using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlCpStatistics:ISql
    {
        int mode=0;
        DateTime m_begin;
        DateTime m_end;
        public SqlCpStatistics(DateTime begin,DateTime end)
        {
            m_begin = begin;
            m_end = end;
            mode = 1;
        }
        public SqlCpStatistics()
        {
        }
        public SqlCpStatistics(Boolean lessthen,DateTime time)
        {
            if (lessthen)
            {
                m_end = time;
                mode = 2;
            }
            else
            {
                m_begin = time;
                mode = 3;
            }
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            switch (mode)
            {
                case 1:
                    return "select ComputerNumber,count(*)'count' from ComputerRepair " +
                                "where UpdateTime between '" +
                                m_begin.ToShortDateString() + "' and '" +
                                m_end.ToShortDateString() + "' " +
                               "group by ComputerNumber order by count desc";
                case 2:
                    return "select ComputerNumber,count(*)'count' from ComputerRepair " +
                                "where UpdateTime < '" +
                                m_end.ToShortDateString() +
                               "' group by ComputerNumber order by count desc";
                case 3:
                    return "select ComputerNumber,count(*)'count' from ComputerRepair " +
                                "where UpdateTime > '" +
                                m_begin.ToShortDateString() +
                               "' group by ComputerNumber order by count desc";
                default:
                    return "select ComputerNumber,count(*)'count' from ComputerRepair " +
                               "group by ComputerNumber order by count desc";
            }
        }

        #endregion
    }
}
