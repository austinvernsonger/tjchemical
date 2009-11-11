using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using LabCenter.LabUtility.XmlBase;
using LabCenter.LabUtility.TimeUtility;

namespace LabCenter.Reservation
{
    public class BasicConfig:XmlParseBase
    {
        public BasicConfig(){}
        public BasicConfig(String path)
            : base(path) { }
        ////
        [XmlIgnore]
        public static BasicConfig uniquebc;
        static BasicConfig()
        {
            string basicconfigpath = AppDomain.CurrentDomain.BaseDirectory +
                               @"LabCenter\XmlConfig\basicConfig.xml";
            BasicConfig bc = new BasicConfig(basicconfigpath);
            uniquebc = (BasicConfig)bc.Deserialize();
            //uniquebc.m_beginday = ((BasicConfig)bc.Deserialize()).m_beginday;
            //uniquebc.m_currentterm = ((BasicConfig)bc.Deserialize()).m_currentterm;
        }
        ////
        [XmlElement(ElementName="CurrentTerm")]
        public int m_currentterm;

        /// <summary>
        /// ��ǰ��ѧ��ѧ��
        /// </summary>
        [XmlIgnore]
        public static int CurrentTerm
        {
            get { return uniquebc.m_currentterm; }
            set { uniquebc.m_currentterm = value; }
        }

        /// <summary>
        /// ��ǰ����
        /// </summary>
        [XmlIgnore]
        public static int CurrentWeek
        {
            get
            {
                if (uniquebc.m_beginday != null && !uniquebc.m_beginday.Equals(""))
                {
                    return TermWeekTeller.CurWeek(DateTime.Parse(uniquebc.m_beginday));
                }
                else
                {
                    return 0;
                }
            }
        }
        [XmlElement(ElementName = "BeginDay")]
        public String m_beginday;
        /// <summary>
        /// ѧ�ڿ�ʼ�ĵ�һ��
        /// </summary>
        [XmlIgnore]
        public static String BeginDay
        {
            get { return uniquebc.m_beginday; }
            set { uniquebc.m_beginday = value; }
        }

        [XmlElement(ElementName = "RemainCount")]
        public int m_remaincount;
        /// <summary>
        /// ʣ���豸����
        /// </summary>
        [XmlIgnore]
        public static int RemainCount
        {
            get { return uniquebc.m_remaincount; }
            set { uniquebc.m_remaincount = value; }
        }

        [XmlElement(ElementName = "TimeConstraint1")]
        public int m_timeconstraint1;
        /// <summary>
        /// ʵ�鿪ʼǰ�೤ʱ��ֹͣԤԼ(��intֵ��ʾ����)
        /// </summary>
        [XmlIgnore]
        public static int TimeConstraint1
        {
            get { return uniquebc.m_timeconstraint1; }
            set { uniquebc.m_timeconstraint1 = value; }
        }

        [XmlElement(ElementName = "TimeConstraint2")]
        public int m_timeconstraint2;
        /// <summary>
        /// ��ԤԼ��ѧ����ʵ�鿪ʼ�೤ʱ���Ժ�Ǽ�,����������¼(��intֵ��ʾ����)
        /// </summary>
        [XmlIgnore]
        public static int TimeConstraint2
        {
            get { return uniquebc.m_timeconstraint2; }
            set { uniquebc.m_timeconstraint2 = value; }
        }

        [XmlElement(ElementName = "TimeConstraint3")]
        public int m_timeconstraint3;
        /// <summary>
        /// ʵ������೤ʱ���Ժ�δ�ǳ�,����������¼(��intֵ��ʾ����)
        /// </summary>
        [XmlIgnore]
        public static int TimeConstraint3
        {
            get { return uniquebc.m_timeconstraint3; }
            set { uniquebc.m_timeconstraint3 = value; }
        }

        [XmlElement(ElementName = "TimeConstraint4")]
        public int m_timeconstraint4;
        /// <summary>
        /// δԤԼ��ѧ���ڱ�ʵ��ʱ��ο�ʼ����Ժ�,���Ҫ�ڱ�ʱ��μ�����ʵ��,��Ҫ������һʱ��ε�ԤԼ���(��intֵ��ʾ����)
        /// </summary>
        [XmlIgnore]
        public static int TimeConstraint4
        {
            get { return uniquebc.m_timeconstraint4; }
            set { uniquebc.m_timeconstraint4 = value; }
        }

        [XmlElement(ElementName = "ReservationState")]
        public bool m_reservationstate;
        /// <summary>
        /// ԤԼ�Ŀ�����ر�״̬,false��ʾ�ر�״̬
        /// </summary>
        [XmlIgnore]
        public static bool ReservationState
        {
            get { return uniquebc.m_reservationstate; }
            set { uniquebc.m_reservationstate = value; }
        }

        [XmlElement(ElementName="IPCheckRegex")]
        public string m_ipcheckregex;
        /// <summary>
        /// ԤԼ�Ǽ�����IP����������ʽ
        /// </summary>
        [XmlIgnore]
        public static string IPCheckRegex
        {
            get { return uniquebc.m_ipcheckregex; }
            set { uniquebc.m_ipcheckregex = value; }
        }
    }
}
