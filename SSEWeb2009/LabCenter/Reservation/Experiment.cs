using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Reservation
{
    public struct Experiment
    {
        public Experiment(int id,string name)
        {
            m_id = id;
            m_name = name;
        }
        private int m_id;
        public int ID
        {
            get{return m_id;}
            set{m_id=value;}
        }

        private string m_name;
        public string Name
        {
            get{return m_name;}
            set{m_name=value;}
        }

    }
}
