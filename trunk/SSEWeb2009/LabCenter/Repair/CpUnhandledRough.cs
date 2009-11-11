using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Repair
{
    public class CpUnhandledRough
    {
        string m_cp_number;
        public string Computer_Num
        {
            get { return m_cp_number; }
            set { m_cp_number = value; }
        }

        int m_order_count;
        public int Order_Count
        {
            get { return m_order_count; }
            set { m_order_count = value; }
        }

        DateTime m_earliest_time;
        public DateTime Earliest_Time
        {
            get { return m_earliest_time; }
            set { m_earliest_time = value; }
        }
    }
}
