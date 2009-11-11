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
        /// 当前的学年学期
        /// </summary>
        [XmlIgnore]
        public static int CurrentTerm
        {
            get { return uniquebc.m_currentterm; }
            set { uniquebc.m_currentterm = value; }
        }

        /// <summary>
        /// 当前的周
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
        /// 学期开始的第一天
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
        /// 剩余设备数量
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
        /// 实验开始前多长时间停止预约(用int值表示分钟)
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
        /// 已预约的学生在实验开始多长时间以后登记,算作不良记录(用int值表示分钟)
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
        /// 实验结束多长时间以后未登出,算作不良记录(用int值表示分钟)
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
        /// 未预约的学生在本实验时间段开始多久以后,如果要在本时间段继续做实验,需要考虑下一时间段的预约情况(用int值表示分钟)
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
        /// 预约的开启或关闭状态,false表示关闭状态
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
        /// 预约登记用于IP检查的正则表达式
        /// </summary>
        [XmlIgnore]
        public static string IPCheckRegex
        {
            get { return uniquebc.m_ipcheckregex; }
            set { uniquebc.m_ipcheckregex = value; }
        }
    }
}
