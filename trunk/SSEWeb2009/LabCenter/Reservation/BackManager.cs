using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Reservation.Ops;
using LabCenter.Reservation.Sql;

namespace LabCenter.Reservation
{
    public class BackManager
    {
        static string m_DbName = "LabCenter";
        public static String ErrorMsg = "";
        static string timetablepath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\TimeTable.xml";
        //static string basicconfigpath = AppDomain.CurrentDomain.BaseDirectory +
        //                   @"LabCenter\XmlConfig\basicConfig.xml";
        
        /// <summary>
        /// �õ�ѧ��ѧ���б�
        /// </summary>
        /// <param name="path">xml�ļ�·��</param>
        /// <returns>TermList����</returns>
        public static TermList GetTermList(string path)
        {
            TermList tl = new TermList(path);
            TermList ret = (TermList)tl.Deserialize();
            //ResLog.Write(tl.Terms.ToString());
            return ret;
        }

        /// <summary>
        /// �õ��ܺ��б�
        /// </summary>
        /// <param name="path">xml�ļ�·��</param>
        /// <returns>WeekList����</returns>
        public static WeekList GetWeekList(string path)
        {
            WeekList tl = new WeekList(path);
            WeekList ret = (WeekList)tl.Deserialize();
            return ret;
        }

        /// <summary>
        /// �õ���ǰ�Ļ�������
        /// </summary>
        /// <param name="path">xml�ļ�·��</param>
        /// <returns>BasicConfig����</returns>
        public static BasicConfig GetBasicConfig(string path)
        {
            BasicConfig bc = new BasicConfig(path);
            BasicConfig ret = (BasicConfig)bc.Deserialize();
            return ret;
        }

        /// <summary>
        /// ���õ�ǰ�Ļ�������
        /// </summary>
        /// <param name="path">xml�ļ�·��</param>
        /// <returns>�ɹ����</returns>
        public static bool SetBasicConfig(BasicConfig bc,string path)
        {
            if (bc != null)
            {
                bc.FilePath = path;
                bc.Serialize();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// �õ�Ĭ��ʱ���
        /// </summary>
        /// <param name="path">xml�ļ�·��</param>
        /// <returns>ʱ������</returns>
        public static TimeTable GetDefaultTimeTable(string path)
        {
            TimeTable tt = new TimeTable(path);
            TimeTable ret = (TimeTable)tt.Deserialize();
            return ret;
        }

        /// <summary>
        /// ����Ĭ��ʱ���
        /// </summary>
        /// <param name="path">xml�ļ�·��</param>
        /// <returns>�ɹ����</returns>
        public static Boolean SetDefaultTimeTable(TimeTable tt,string path)
        {
            if(tt!=null)
            {
                tt.FilePath = path;
                tt.Serialize();
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// ����ʱ���
        /// </summary>
        /// <param name="ttp">xx</param>
        /// <returns>�ɹ����</returns>
        public static Boolean SetTimeTablePlus(TimeTablePlus ttp)
        {
            //...
            OpReservationExecute k;
            foreach(MyTimeSpan myts in ttp.TTable.Monday)
            {
                k = new OpReservationExecute(m_DbName,new SqladdTimeinfo
                    (1,"1900-12-30"+" "+myts.begin,myts.enddayofweek,"1900-12-30"+" "+myts.end,
                    ttp.RemainCount,ttp.TermNumber,ttp.WeekNumber));
                if (!k.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�ΪMonday����µ�timeinfo��¼)!";
                    return false;
                }
            }
            foreach (MyTimeSpan myts in ttp.TTable.Tuesday)
            {
                k = new OpReservationExecute(m_DbName, new SqladdTimeinfo
                    (2, "1900-12-30" + " " + myts.begin, myts.enddayofweek, "1900-12-30" + " " + myts.end,
                    ttp.RemainCount, ttp.TermNumber, ttp.WeekNumber));
                if (!k.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�ΪTuesday����µ�timeinfo��¼)!";
                    return false;
                }
            }
            foreach (MyTimeSpan myts in ttp.TTable.Wednesday)
            {
                k = new OpReservationExecute(m_DbName, new SqladdTimeinfo
                    (3, "1900-12-30" + " " + myts.begin, myts.enddayofweek, "1900-12-30" + " " + myts.end,
                    ttp.RemainCount, ttp.TermNumber, ttp.WeekNumber));
                if (!k.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�ΪWednesday����µ�timeinfo��¼)!";
                    return false;
                }
            }
            foreach (MyTimeSpan myts in ttp.TTable.Thursday)
            {
                k = new OpReservationExecute(m_DbName, new SqladdTimeinfo
                    (4, "1900-12-30" + " " + myts.begin, myts.enddayofweek, "1900-12-30" + " " + myts.end,
                    ttp.RemainCount, ttp.TermNumber, ttp.WeekNumber));
                if (!k.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�ΪThursday����µ�timeinfo��¼)!";
                    return false;
                }
            }
            foreach (MyTimeSpan myts in ttp.TTable.Friday)
            {
                k = new OpReservationExecute(m_DbName, new SqladdTimeinfo
                    (5, "1900-12-30" + " " + myts.begin, myts.enddayofweek, "1900-12-30" + " " + myts.end,
                    ttp.RemainCount, ttp.TermNumber, ttp.WeekNumber));
                if (!k.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�ΪFriday����µ�timeinfo��¼)!";
                    return false;
                }
            }
            foreach (MyTimeSpan myts in ttp.TTable.Saturday)
            {
                k = new OpReservationExecute(m_DbName, new SqladdTimeinfo
                    (6, "1900-12-30" + " " + myts.begin, myts.enddayofweek, "1900-12-30" + " " + myts.end,
                    ttp.RemainCount, ttp.TermNumber, ttp.WeekNumber));
                if (!k.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�ΪSaturday����µ�timeinfo��¼)!";
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// ����ʵ��
        /// </summary>
        /// <param name="termnumber">ѧ��ѧ��</param>
        /// <param name="week">��</param>
        /// <param name="experimentids">���ŵ�ʵ��id�б�</param>
        /// <returns></returns>
        public static Boolean ArrangeExperiment(int termnumber,int week,List<int> experimentids,TimeTable tt)
        {
            //���TimeInfo��
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetTimeInfoRecordCount(termnumber,week));
            i.Do();
            if(i.Ds.Tables[0].Rows[0][0].ToString() != "0")
            {
                OpReservationExecute j = new OpReservationExecute(m_DbName,new SqldeleteTimeInfo(termnumber,week));
                if(!j.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�ɾ���ɵ�timeinfo��¼)!";
                    return false;
                }
            }
            TimeTablePlus ttp;
            if(tt == null)
            {
                ttp = new TimeTablePlus(termnumber, week, BasicConfig.RemainCount,
                    GetDefaultTimeTable(timetablepath));
            }
            else
            {
                ttp = new TimeTablePlus(termnumber, week, BasicConfig.RemainCount, tt);
            }
            if(!SetTimeTablePlus(ttp))
            {
                return false;
            }

            //DateInfo�Ӽ�¼
            OpReservationExecute k;
            foreach(int experimentid in experimentids)
            {
                k = new OpReservationExecute(m_DbName,new SqladdDateInfo(experimentid,termnumber,week));
                if(!k.Do())
                {
                    ErrorMsg = "����ʵ��ʧ��(�޷�����µ�dateinfo��¼)!";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ���õ�ǰ��
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static Boolean SetCurrentWeek(string week)
        {
            return false;
        }

        /// <summary>
        /// ȡ��ʵ���б�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetExperiment()
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetExperiment());
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ����ǰ��Ч��ʵ���б�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetvalidExperiment()
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetValidExperiment());
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ����ǰĳѧ��ĳ�ܰ��ŵ�ʵ����Ϣ
        /// </summary>
        /// <param name="term">ĳѧ��</param>
        /// <param name="week">ĳ��</param>
        /// <returns></returns>
        public static DataSet GetHistoryExperiment(int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetHistoryExperiment(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ����µ�ʵ��
        /// </summary>
        /// <param name="name">ʵ������</param>
        /// <returns></returns>
        public static Boolean AddExperiment(string name)
        {
            //�ȼ���Ƿ��Ѵ�����ͬʵ����
            DataSet ds = GetExperiment();
            if(ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    if(name == dr["ExperimentName"].ToString())
                    {
                        ErrorMsg = "�Ѵ��ڸ�ʵ��!";
                        return false;
                    }
                }
            }
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqladdExperiment(name));
            if(!i.Do())
            {
                ErrorMsg = "���ʵ��ʧ��!";
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// ȡ��ĳһʵ�����Ϣ
        /// </summary>
        /// <param name="experimentid">ʵ��ID</param>
        /// <returns></returns>
        public static DataSet GetuniqueExperiment(int experimentid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetUniqueExperiment(experimentid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// �޸�ʵ����Ϣ
        /// </summary>
        /// <param name="experimentid">ʵ��ID</param>
        /// <param name="experimentname">�޸ĺ��ʵ������</param>
        /// <param name="ifvalid">ʵ���Ƿ���Ч</param>
        /// <returns>�޸ĳɹ����</returns>
        public static Boolean UpdateuniqueExperiment(int experimentid, string experimentname, int ifvalid)
        {
            //�ȼ���Ƿ��Ѵ�����ͬʵ����
            DataSet ds = GetExperiment();
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (experimentname == dr["ExperimentName"].ToString() && experimentid != Convert.ToInt32(dr["ExperimentID"]))
                    {
                        ErrorMsg = "��ͬ��ʵ�������Ѵ���!";
                        return false;
                    }
                }
            }

            OpReservationExecute i = new OpReservationExecute(m_DbName, new SqlupdateUniqueExperiment(experimentid, experimentname, ifvalid));
            if(!i.Do())
            {
                ErrorMsg = "�����޸�ʧ��!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ȡ����ǰ��StuLabInfo�ļ�¼��
        /// </summary>
        /// <returns>ĳһѧ��</returns>
        public static DataSet GetReportCount(int term)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetReportCount(term));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ����ʵ�鱨���ύ״̬
        /// </summary>
        /// <param name="stuid">ѧ��</param>
        /// <param name="expname">ʵ����</param>
        /// <param name="state">״̬</param>
        /// <returns></returns>
        public static bool UpdateReportState(string stuid, string expname, Boolean state)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName, new SqlupdateReportState(stuid, expname, state));
            if (!i.Do())
            {
                ErrorMsg = "����ʧ��!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ȡ��ʵ�鱨���ύ�����Ϣ�б�
        /// </summary>
        /// <param name="term">ĳһѧ��</param>
        /// <returns></returns>
        public static DataSet GetReportsByTerm(int term)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportsDS(term));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ����ǰ����ʵ�������ͳ��
        /// </summary>
        /// <param name="term">��ǰѧ��ѧ��</param>
        /// <param name="week">��ǰ��</param>
        /// <returns></returns>
        public static DataSet GetCurrentStudentDS(int term, int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetCurrentStudentDS(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// �ж��Ƿ��и��ǵ�ǰʱ�̵�ʱ���
        /// </summary>
        /// <param name="term">��ǰѧ��ѧ��</param>
        /// <param name="week">��ǰ��</param>
        /// <returns></returns>
        public static DataSet GetCurrentTimeSpan(int term, int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetCurrentTimeSpan(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ĳѧ��ĳʵ��ĳѧ����ʵ�鱨���¼
        /// </summary>
        /// <param name="term">ĳѧ��</param>
        /// <param name="experimentNumber">ĳʵ��</param>
        /// <param name="stuid">ĳѧ��</param>
        /// <returns></returns>
        public static DataSet GetReportByTNN(int term, int experimentNumber, string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByTNN(term, experimentNumber, stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ĳʵ��ĳѧ����ʵ�鱨���¼
        /// </summary>
        /// <param name="experimentNumber">ĳʵ��</param>
        /// <param name="stuid">ĳѧ��</param>
        /// <returns></returns>
        public static DataSet GetReportByNN(int experimentNumber, string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByNN(experimentNumber, stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ĳѧ����ʵ�鱨���¼
        /// </summary>
        /// <param name="stuid">ĳѧ��</param>
        /// <returns></returns>
        public static DataSet GetReportByNo(string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByNo(stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ĳѧ��ĳʵ���ʵ�鱨���¼
        /// </summary>
        /// <param name="term">ĳѧ��</param>
        /// <param name="experimentNumber">ĳʵ��</param>
        /// <returns></returns>
        public static DataSet GetReportByTNa(int term, int experimentNumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByTNa(term, experimentNumber));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ĳѧ��ĳѧ����ʵ�鱨���¼
        /// </summary>
        /// <param name="term">ĳѧ��</param>
        /// <param name="stuid">ĳѧ��</param>
        /// <returns></returns>
        public static DataSet GetReportByTNo(int term, string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByTNo(term, stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ĳʵ���ʵ�鱨���¼
        /// </summary>
        /// <param name="experimentNumber">ĳʵ��</param>
        /// <returns></returns>
        public static DataSet GetReportByName(int experimentNumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByName(experimentNumber));
            i.Do();
            return i.Ds;
        }
    }
}
