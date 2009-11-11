using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Repair
{
    public class OtherRecord
    {
        Int64 m_recordid;
        public Int64 RecordID
        {
            get { return m_recordid; }
            set { m_recordid = value; }
        }

        string m_devname;
        public string DevName
        {
            get { return m_devname; }
            set { m_devname = value; }
        }

        string m_location;
        public string Location
        {
            get { return m_location; }
            set { m_location = value; }
        }

        string m_discription;
        public string Discription
        {
            get { return m_discription; }
            set { m_discription = value; }
        }

        DateTime m_update_time;
        public DateTime Update_Time
        {
            get { return m_update_time; }
            set { m_update_time = value; }
        }

        string m_reporter_id;
        public string Reporter_ID
        {
            get { return m_reporter_id; }
            set { m_reporter_id = value; }
        }

        string m_reporter_name;
        public string Reporter_Name
        {
            get { return m_reporter_name; }
            set { m_reporter_name = value; }
        }

        int m_state;
        public int State
        {
            get { return m_state; }
            set { m_state = value; }
        }

        DateTime m_confirm_time;
        public DateTime Comfirm_Time
        {
            get { return m_confirm_time; }
            set { m_confirm_time = value; }
        }
    }
}
