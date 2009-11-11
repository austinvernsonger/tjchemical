using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Reservation.Ops;
using LabCenter.Reservation.Sql;

namespace LabCenter.Reservation
{
    public class FrontManager
    {
        static string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        //static string basicConfigpath = AppDomain.CurrentDomain.BaseDirectory +
        //                   @"LabCenter\XmlConfig\basicConfig.xml";
        /// <summary>
        /// �����ܱ�ԤԼ�����ں�
        /// </summary>
        /// <returns></returns>
        public DataSet GetValidDayofWeek(int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetbegDayofweek(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ���ؿ�ѡʱ���
        /// </summary>
        /// <param name="dayofweek">ѡ�е������Ӧ�����ں�</param>
        /// <returns></returns>
        public DataSet GetValidTimeSpan(int dayofweek)
        {
            int term = BasicConfig.CurrentTerm;
            int week = BasicConfig.CurrentWeek;

            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetTimeSpanByDay(dayofweek,term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ���ؿ�ѡʵ�������
        /// </summary>
        /// <param name="spannumber">ѡ�е��Ǹ�ʱ��ζ�Ӧ���</param>
        /// <returns></returns>
        public DataSet GetValidExperiment(int spannumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetDateInfo(spannumber));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ���ض�Ӧʱ��ε��豸ʣ������
        /// </summary>
        /// <param name="spannumber">ָ��ʱ��εı��</param>
        /// <returns></returns>
        public DataSet GetRemainDevice(int spannumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetRemainCount(spannumber));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ����һ��ԤԼ��¼
        /// </summary>
        /// <param name="stuID">ԤԼѧ�����˺�</param>
        /// <param name="ExpID">ʵ����</param>
        /// <param name="spanNum">ԤԼ��ʱ��α��</param>
        /// <returns>true��ʾԤԼ�ɹ�</returns>
        public Boolean NewReservation(string stuID, int ExpID, int spanNum)
        {
            //�ȼ���Ƿ���ԤԼ��ʵ��
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetReservation(stuID));
            i.Do();
            if(i.Ds.Tables.Count != 0 && i.Ds.Tables[0].Rows.Count != 0)
            {
                for(int j = 0; j < i.Ds.Tables[0].Rows.Count; j++)
                {
                    if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["ExperimentID"].ToString()) != ExpID
                        && Convert.ToInt32(i.Ds.Tables[0].Rows[j]["TimeSpanID"].ToString()) != spanNum)
                    { continue; }
                    else
                    {
                        if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["ExperimentID"].ToString()) == ExpID)
                        {
                            ErrorMsg = "��ԤԼ��ʵ��,�����ظ�ԤԼ!";
                            return false;
                        }
                        if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["TimeSpanID"].ToString()) == spanNum)
                        {
                            ErrorMsg = "��ʱ�������ԤԼ!";
                            return false;
                        }
                    }
                }
            }

            //֮���鵱ǰ�ɷ�ԤԼ,��ʵ�鿪ʼ��ʣ��ʱ���Ƿ����޶���ʱ��֮��
            DataSet ds = GetTimeSpanByID(spanNum);

            if (Convert.ToInt32(DateTime.Now.DayOfWeek) == Convert.ToInt32(ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString()))
            {
                if (!CompareTwoTime(ds.Tables[0].Rows[0]["beginTime"].ToString(), 1))
                {
                    return false;
                }
            }            

            OpReservationExecute k = new OpReservationExecute(m_DbName,new SqladdReservation(stuID,ExpID,spanNum));
            if(!k.Do())
            {
                ErrorMsg = "ԤԼʧ��,���Ժ�����!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ��ʱԤԼʵ��
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="dateindex"></param>
        /// <returns></returns>
        public Boolean NewTempReservation(string stuid,int dateindex)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReservation(stuid));
            i.Do();
            //
            OpReservationQuery o = new OpReservationQuery(m_DbName, new SqlgetDateInfoDetails(dateindex));
            o.Do();
            
            //�ȼ���Ƿ���ԤԼ��ʵ��
            if ((i.Ds.Tables.Count != 0 && i.Ds.Tables[0].Rows.Count != 0) 
                && (o.Ds.Tables.Count != 0 && o.Ds.Tables[0].Rows.Count != 0))
            {
                for (int j = 0; j < i.Ds.Tables[0].Rows.Count; j++)
                {
                    if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["ExperimentID"].ToString()) != Convert.ToInt32(o.Ds.Tables[0].Rows[0]["ExperimentID"].ToString()))
                    { continue; }
                    else
                    {
                        if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["ExperimentID"].ToString()) == Convert.ToInt32(o.Ds.Tables[0].Rows[0]["ExperimentID"].ToString()))
                        {
                            ErrorMsg = "��ԤԼ��ʵ��,�����ظ�ԤԼ!";
                            return false;
                        }
                        if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["TimeSpanID"].ToString()) == Convert.ToInt32(o.Ds.Tables[0].Rows[0]["TimeSpanID"].ToString()))
                        {
                            ErrorMsg = "��ʱ�������ԤԼ!";
                            return false;
                        }
                    }
                }
            }

            OpReservationExecute k = new OpReservationExecute(m_DbName, new SqladdReservation(stuid, Convert.ToInt32(o.Ds.Tables[0].Rows[0]["ExperimentID"].ToString()), Convert.ToInt32(o.Ds.Tables[0].Rows[0]["TimeSpanID"].ToString())));
            if (!k.Do())
            {
                ErrorMsg = "ԤԼʧ��,���Ժ�����!";
                return false;
            }
            //�豸��һ
            if (!UpdateRemainDevice(Convert.ToInt32(o.Ds.Tables[0].Rows[0]["TimeSpanID"].ToString()),-1))
            {
                ErrorMsg = "ԤԼʧ��,���Ժ�����";
                return false;
            }
            return true;
        }
        /// <summary>
        /// ����ָ����ID��Ӧ��ʱ���
        /// </summary>
        /// <param name="spanID">ָ����ʱ���ID</param>
        /// <returns></returns>
        public DataSet GetTimeSpanByID(int spanID)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetTimeSpanByID(spanID));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ����ʣ���豸����
        /// </summary>
        /// <param name="spanNum">��Ӧ��ʱ���</param>
        /// <param name="newCount">�����仯,-1��ʾ����һ</param>
        /// <returns></returns>
        public Boolean UpdateRemainDevice(int spanNum, int newCount)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqlupdateRemainCount(spanNum,newCount));
            if(!i.Do())
            {
                ErrorMsg = "ԤԼʧ��,���Ժ�����";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ����ĳѧ����ǰ��ԤԼ��¼
        /// </summary>
        /// <param name="Stuid">ѧ���˺�</param>
        /// <returns>�����ʾδԤԼ�κ�ʵ��</returns>
        public DataSet GetReservationByStuid(string Stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReservationByStuid(Stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ԤԼ
        /// </summary>
        /// <param name="stuid">ѧ���˺�</param>
        /// <param name="labid">Ҫȡ����ʵ����</param>
        public Boolean CancelReservation(string stuid, int dateIndex)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName, new SqlcancelReservation(stuid, dateIndex));
            if(!i.Do())
            {
                ErrorMsg = "ȡ��ԤԼʧ��,���Ժ�����";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ȡ��ĳѧ����ʵ�鱨���ύ��¼
        /// </summary>
        /// <param name="Stuid">ѧ���˺�</param>
        /// <returns></returns>
        public DataSet GetReportByStuid(string Stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetReport(Stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// �ж�ѧ��ԤԼ��ʱ������Ƿ����뵱ǰʱ����ƥ���
        /// </summary>
        /// <param name="stuid">ѧ��</param>
        /// <param name="term">ѧ��</param>
        /// <param name="week">�ܺ�</param>
        /// <returns></returns>
        public DataSet GetCurrentReservation(string stuid,int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetCurrentReservation(stuid,term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ��ĳһԤԼ����ϸ��Ϣ
        /// </summary>
        /// <param name="dateindex">ԤԼ��ʶ��</param>
        /// <returns></returns>
        public DataSet GetReservationDetails(int dateindex)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetReservationDetails(dateindex));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ����һ���ǼǼ�¼
        /// </summary>
        /// <param name="stuid">ѧ��</param>
        /// <param name="dateindex">ԤԼ��ʶ��</param>
        /// <param name="logintime">����ʱ��</param>
        /// <param name="devicenum">�豸��</param>
        /// <returns></returns>
        public Boolean AddRegInfo(string stuid,int dateindex,string logintime,int devicenum)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqladdRegInfo(stuid,dateindex,logintime,devicenum));
            if (!i.Do())
            {
                ErrorMsg = "��ӵǼǼ�¼ʧ��!";
                return false;
            }
            DataSet ds = GetReservationDetails(dateindex);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ErrorMsg = "��ӵǼǼ�¼ʧ��!";
                return false;
            }
            else
            {
                if (!CompareTwoTime(ds.Tables[0].Rows[0]["BeginTime"].ToString(),2))//�ٵ�,�ǲ�����¼
                {
                    string BadRecord = "";
                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            "��" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }

                    BadRecord += ErrorMsg;
                    if (!UpdateReservationInfo(stuid, dateindex, 1, true, BadRecord))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!UpdateReservationInfo(stuid, dateindex, 1, false, ""))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ���µǼǼ�¼(�ǳ�ʱ��)
        /// </summary>
        /// <param name="stuid">ѧ��</param>
        /// <param name="dateindex">ԤԼ��ʶ��</param>
        /// <returns></returns>
        public Boolean UpdateRegInfo(string stuid,int dateindex)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqlupdateRegInfo(stuid,dateindex));
            if (!i.Do())
            {
                ErrorMsg = "���µǼǼ�¼(�ǳ�ʱ��)ʧ��";
                return false;
            }
            DataSet ds = GetReservationDetails(dateindex);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ErrorMsg = "���µǼǼ�¼(�ǳ�ʱ��)ʧ��";
                return false;
            }
            else
            {
                if (!CompareTwoTime(ds.Tables[0].Rows[0]["EndTime"].ToString(), 3))//����������¼
                {
                    string BadRecord = "";
                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            "��" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }

                    BadRecord += ErrorMsg;
                    if (!UpdateReservationInfo(stuid, dateindex, 1, true, BadRecord))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!UpdateReservationInfo(stuid, dateindex, 1, false, ""))
                    {
                        return false;
                    }
                }
            }

            //���»����StuLabInfo��¼
            int curterm = (int)BasicConfig.CurrentTerm;
            OpReservationQuery j = new OpReservationQuery(m_DbName,new SqlgetExistStuLabInfo(stuid,Convert.ToInt32(ds.Tables[0].Rows[0]["ExperimentID"].ToString()),curterm));
            j.Do();
            if (j.Ds == null ||j.Ds.Tables.Count == 0 || j.Ds.Tables[0].Rows.Count == 0)
            {
                ErrorMsg = "����ѧ��ʵ����Ϣʧ��1!";
                return false;
            }
            else
            {
                OpReservationQuery k = new OpReservationQuery(m_DbName,new SqlgetLogTime(stuid,dateindex));
                k.Do();
                if (k.Ds == null ||k.Ds.Tables.Count == 0 || k.Ds.Tables[0].Rows.Count == 0)
                {
                    ErrorMsg = "����ѧ��ʵ����Ϣʧ��2!";
                    return false;
                }
                if (Convert.ToInt32(j.Ds.Tables[0].Rows[0][0].ToString()) == 0)//��һ������ʵ��
                {
                    i = new OpReservationExecute(m_DbName, new SqladdStuLabInfo(stuid, Convert.ToInt32(ds.Tables[0].Rows[0]["ExperimentID"].ToString()),Convert.ToInt32(k.Ds.Tables[0].Rows[0]["minutes"].ToString()),curterm));
                }
                else//�Ѿ�������ʵ��
                {
                    i = new OpReservationExecute(m_DbName, new SqlupdateStuLabInfo(stuid, Convert.ToInt32(ds.Tables[0].Rows[0]["ExperimentID"].ToString()), curterm, Convert.ToInt32(k.Ds.Tables[0].Rows[0]["minutes"].ToString())));
                }
                if (!i.Do())
                {
                    ErrorMsg = "����ѧ��ʵ����Ϣʧ��3!";///////<---2009/10/27����
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �Ƚϵ�ǰʱ���Ƿ񳬹�ĳһʱ������
        /// </summary>
        /// <param name="TimeString"></param>
        /// <param name="TimeConstraintKind">ʱ����������</param>
        /// <returns></returns>
        public Boolean CompareTwoTime(string TimeString,int TimeConstraintKind)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = Convert.ToDateTime(dt1.ToLongDateString() + " " + TimeString);
            int minute;
            if (TimeConstraintKind == 1)//ʵ�鿪ʼǰ�೤ʱ��ֹͣԤԼ
            {
                minute = (int)BasicConfig.TimeConstraint1;
                dt1 = dt1.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "ʵ�鿪ʼǰ" + minute.ToString() + "����,ֹͣԤԼ��ʵ��!";
                    return false;
                }
            }
            else if (TimeConstraintKind == 2)//��ԤԼ��ѧ����ʵ�鿪ʼ�೤ʱ���Ժ�Ǽ�,����������¼
            {
                minute = (int)BasicConfig.TimeConstraint2;
                dt2 = dt2.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "��ʵ�鿪ʼ����" + minute.ToString() + "���ӵ���,��һ�γٵ���¼!";
                    return false;
                }
            }
            else if (TimeConstraintKind == 3)//ʵ������೤ʱ���Ժ�δ�ǳ�,����������¼
            {
                minute = (int)BasicConfig.TimeConstraint3;
                dt2 = dt2.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "��ʵ���������" + minute.ToString() + "���ӵǳ�,��һ�β�����¼!";
                    return false;
                }
            }
            else if (TimeConstraintKind == 4)//δԤԼ��ѧ���ڱ�ʵ��ʱ��ο�ʼ����Ժ�,���Ҫ�ڱ�ʱ��μ�����ʵ��,��Ҫ������һʱ��ε�ԤԼ���
            {
                minute = (int)BasicConfig.TimeConstraint4;
                dt2 = dt2.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "��ǰʱ���Ѿ�������ʱԤԼ��ʱ������(�౾ʱ��ο�ʼʱ��" + minute.ToString() + "������),�޷�����ԤԼ��ʱ���!";
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// ����ԤԼ��¼
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="dateindex"></param>
        /// <param name="state"></param>
        /// <param name="ifpenalty">�Ƿ�Ϊ������¼</param>
        /// <param name="penaltyrecord">������¼��ע</param>
        /// <returns></returns>
        public Boolean UpdateReservationInfo(string stuid,int dateindex,int state,Boolean ifpenalty,string penaltyrecord)
        {
            OpReservationExecute i;
            if (!ifpenalty)
            {
                i = new OpReservationExecute(m_DbName, new SqlupdateStuReservationInfo(stuid,dateindex,state));
            }
            else
            {
                i = new OpReservationExecute(m_DbName, new SqlupdateStuReservationInfo(stuid, dateindex, state, ifpenalty, penaltyrecord));
            }
            if (!i.Do())
            {
                ErrorMsg = "����ԤԼ��¼ʧ��!";
                return false;
            }
            else
            {
                if (!ifpenalty)
                {
                    return true;
                }
                else
                {
                    ErrorMsg = penaltyrecord;
                    return false;
                }
            }
        }
        /// <summary>
        /// ȡ��ĳѧ��δ�ǳ���RegInfo��¼
        /// </summary>
        /// <param name="stuid">ѧ��</param>
        /// <returns></returns>
        public DataSet GetIncompleteRegInfo(string stuid,int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetIncompleteRegInfo(stuid, term, week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ����ǰʱ�����ڵ�ʱ��������Ϣ
        /// </summary>
        /// <param name="term"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public DataSet GetCurrentInfo(int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetCurrentInfo(week, term));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ȡ����ǰʱ����Ӧ����һʱ��������Ϣ
        /// </summary>
        /// <param name="term"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public DataSet GetNextInfo(int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetNextInfo(week, term));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// ���ĳѧ���ڵ����Ƿ���"δӦԼ"��"δ�ǳ�"�Ĳ�����¼
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="term"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public void CheckForPenalty(string stuid,int term,int week,string path)
        {
            int dateindex;
            DataSet ds = null;
            string BadRecord = "";

            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlcheckReservation(stuid,term,week));
            i.Do();

            if (i.Ds != null && i.Ds.Tables.Count != 0 && i.Ds.Tables[0].Rows.Count != 0)
            {
                for (int j = 0; j < i.Ds.Tables[0].Rows.Count;j++ )
                {
                    dateindex = Convert.ToInt32(i.Ds.Tables[0].Rows[j][0].ToString());
                    ds = GetReservationDetails(dateindex);
                    
                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = "��"+ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "��" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            "��" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "δӦԼ!";
                    UpdateReservationInfo(stuid, dateindex, 2, true, BadRecord);
                    ds.Clear();
                }
            }

            int minute = (int)BasicConfig.TimeConstraint3;
            i = new OpReservationQuery(m_DbName,new SqlcheckRegInfo(stuid, term, week, minute));
            i.Do();
            if (i.Ds != null && i.Ds.Tables.Count != 0 && i.Ds.Tables[0].Rows.Count != 0)
            {
                for (int j = 0; j < i.Ds.Tables[0].Rows.Count;j++ )
                {
                    dateindex = Convert.ToInt32(i.Ds.Tables[0].Rows[j][0].ToString());
                    ds = GetReservationDetails(dateindex);

                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = "��" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "��" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            "��" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "�涨ʱ����δ�ǳ�!";

                    StudentNo sn = GetStudentNo(stuid, path);
                    if (sn!= null)//����ʵ��
                    {
                        foreach (string stuNo in sn.ValuesNo)
                        {
                            ResLog.Write(stuNo + BadRecord);
                            UpdateReservationInfo(stuNo, dateindex, 1, true, BadRecord);
                        }
                        UpdateMultiStudentLab(stuid, sn.ValuesNo, path, false);
                    }
                    ////
                    ResLog.Write(stuid + BadRecord);
                    ////
                    UpdateReservationInfo(stuid, dateindex, 1, true, BadRecord);
                    ds.Clear();
                }
            }
        }

        /// <summary>
        /// �������ѧ���ڵ�ǰ�Ƿ���"δӦԼ"��"δ�ǳ�"�Ĳ�����¼
        /// </summary>
        /// <param name="term"></param>
        /// <param name="week"></param>
        public void CheckAllForPenalty(int term, int week, string path)
        {
            int dateindex;
            string stuid = "";
            DataSet ds = null;
            string BadRecord = "";

            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlcheckAllReservation(term, week));
            i.Do();

            if (i.Ds != null && i.Ds.Tables.Count != 0 && i.Ds.Tables[0].Rows.Count != 0)
            {
                for (int j = 0; j < i.Ds.Tables[0].Rows.Count; j++)
                {
                    dateindex = Convert.ToInt32(i.Ds.Tables[0].Rows[j]["dateindex"].ToString());
                    stuid = i.Ds.Tables[0].Rows[j]["StuID"].ToString();
                    ds = GetReservationDetails(dateindex);

                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = "��" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "��" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            "��" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "δӦԼ!";
                    UpdateReservationInfo(stuid, dateindex, 2, true, BadRecord);
                    ds.Clear();
                }
            }

            int minute = (int)BasicConfig.TimeConstraint3;
            i = new OpReservationQuery(m_DbName, new SqlcheckAllRegInfo(term, week, minute));
            i.Do();
            if (i.Ds != null && i.Ds.Tables.Count != 0 && i.Ds.Tables[0].Rows.Count != 0)
            {
                for (int j = 0; j < i.Ds.Tables[0].Rows.Count; j++)
                {
                    dateindex = Convert.ToInt32(i.Ds.Tables[0].Rows[j]["dateindex"].ToString());
                    stuid = i.Ds.Tables[0].Rows[j]["stuid"].ToString();
                    ds = GetReservationDetails(dateindex);

                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = "��" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "��" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "ѧ�ڣ�ԤԼ�˵�" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "�� ��" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "��" +
                            "��" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "��ʵ��(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "�涨ʱ����δ�ǳ�!";

                    StudentNo sn = GetStudentNo(stuid, path);
                    if (sn != null)//����ʵ��
                    {
                        foreach (string stuNo in sn.ValuesNo)
                        {
                            ResLog.Write(stuNo + BadRecord);
                            UpdateReservationInfo(stuNo, dateindex, 1, true, BadRecord);
                        }
                        UpdateMultiStudentLab(stuid, sn.ValuesNo, path, false);
                    }
                    ////
                    ResLog.Write(stuid + BadRecord);
                    ////
                    UpdateReservationInfo(stuid, dateindex, 1, true, BadRecord);
                    ds.Clear();
                }
            }
        }

        /// <summary>
        /// ��ö���ʵ��ѧ���б�
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public MultiStudentLab GetMultiStudentLab(string path)
        {
            MultiStudentLab msl = new MultiStudentLab(path);
            msl = (MultiStudentLab)msl.Deserialize();
            return msl;
        }

        /// <summary>
        /// ���ö���ʵ��ѧ���б�
        /// </summary>
        /// <param name="msl"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SetMultiStudentLab(MultiStudentLab msl,string path)
        {
            if (msl != null)
            {
                msl.FilePath = path;
                msl.Serialize();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// ���¶���ʵ��ѧ���б�
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="otherstuids"></param>
        /// <param name="path"></param>
        /// <param name="addordelete"></param>
        /// <returns></returns>
        public bool UpdateMultiStudentLab(string stuid, List<string> otherstuids,string path,bool addordelete)
        {
            MultiStudentLab oldmsl = GetMultiStudentLab(path);
            StudentNo target = null;

            if (oldmsl != null)
            {
                foreach (StudentNo s in oldmsl.StudentList)
                {
                    if (s.KeyNo.Equals(stuid))
                    {
                        if (addordelete)
                        {
                            ErrorMsg = "ѧ��Ϊ" + stuid + "��ѧ����ǰ��һ������ʵ��δ�ǳ�!";
                            return false;
                        }
                        else
                        {
                            target = s;
                            break;
                        }
                    }
                }
            }

            if (addordelete)
            {
                StudentNo sn = new StudentNo();
                sn.KeyNo = stuid;
                sn.ValuesNo = otherstuids;
                if (oldmsl == null)
                {
                    oldmsl = new MultiStudentLab(path);
                }
                oldmsl.StudentList.Add(sn);
            }
            else
            {
                if (target != null)
                {
                    oldmsl.StudentList.Remove(target);
                }
                else
                {
                    ErrorMsg = "����ʵ���ѧ���б��в�������ѧ��:" + stuid;
                    return false;
                }
            }

            if (!SetMultiStudentLab(oldmsl, path))
            {
                ErrorMsg = "���¶���ʵ���ѧ���б�ʱ��������";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// ������ĳѧ�������Ķ���ʵ������в�����ѧ��
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public StudentNo GetStudentNo(string stuid,string path)
        {
            StudentNo ret = null ;

            MultiStudentLab msl = GetMultiStudentLab(path);

            if (msl != null)
            {
                foreach (StudentNo sn in msl.StudentList)
                {
                    if (sn.KeyNo.Equals(stuid))
                    {
                        ret = sn;
                        return ret;
                    }
                }
            }

            return ret;
        }
    }
}
