using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlGetCpRecords:ISql
    {
        int mode=0;
        DateTime m_begin;
        DateTime m_end;
        public SqlGetCpRecords(DateTime begin,DateTime end)
        {
            m_begin = begin;
            m_end = end;
            mode = 1;
        }
        public SqlGetCpRecords()
        {
        }
        public SqlGetCpRecords(Boolean lessthen,DateTime time)
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
                    return "select * from ComputerRepair where UpdateTime between " +
                                "'" + m_begin.ToShortDateString() + "' and '" +
                                m_end.ToShortDateString() + "' order by UpdateTime desc";
                case 2:
                    return "select * from ComputerRepair where UpdateTime < '"+
                        m_end.ToShortDateString()+"'order by UpdateTime desc";
                case 3:
                    return "select * from ComputerRepair where UpdateTime > '" +
                        m_begin.ToShortDateString() + "'order by UpdateTime asc";
                default:
                    return "select * from ComputerRepair order by UpdateTime desc";
            }
        }

        #endregion
    }
}
