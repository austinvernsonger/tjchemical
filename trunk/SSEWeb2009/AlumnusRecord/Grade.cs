using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.IO;

/// <summary>
/// Summary description for Grade
/// </summary>
namespace AlumnusRecord
{
    public class Grade
    {
        private string m_GradYear;
        public string GradYear
        {
            get { return m_GradYear; }
            set
            {
                if (value != null)
                    m_GradYear = value;
            }
        }

        private int m_Degree;
        public int Degree
        {
            get { return m_Degree; }
            set { m_Degree = value; }
        }

        private string m_GradImageLocation;
        public string GradImageLocation
        {
            get { return m_GradImageLocation; }
            set { m_GradImageLocation = value; }
        }

        public Grade()
        {

        }


    }
}