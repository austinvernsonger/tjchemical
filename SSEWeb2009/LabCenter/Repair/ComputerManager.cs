using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Repair.Sql;
using LabCenter.Repair.Ops;
using System.Data;

namespace LabCenter.Repair
{
    public class ComputerManager
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        public static int RecordPageSize = 10;

        private Boolean _CheckCpNum(string cp_num)
        {
            string[] ss=cp_num.Split(new char[] { '-' });
            if (ss.Length!=2)
            {
                return false;
            }
            else
            {
                if (ss[0].Equals("") || ss[1].Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean _CheckOrder(string reporter_id,string computer_number,string description)
        {
            Boolean pass=true;
            if(null==reporter_id || reporter_id.Equals(""))
            {
                ErrorMsg += "(������ID����Ϊ��)";
                pass=false;
            }
            if(!_CheckCpNum(computer_number))
            {
                ErrorMsg += "[��λ��Ų�����]";
                pass = false;
            }
            if(null==description || description.Equals(""))
            {
                ErrorMsg += "<д�����������>";
                pass = false;
            }
            return pass;
        }

        public Boolean NewOrder(string reporter_id,string cpmputer_number,string discription)
        {
            if (!_CheckOrder(reporter_id,cpmputer_number,discription))
            {
                return false;
            }
            OpRepairExecute i = new OpRepairExecute(m_DbName, 
                new SqlAddComputerOrder(reporter_id,cpmputer_number,discription));
            if (!i.Do())
            {
                //ErrorMsg = i.GetLastError();
                ErrorMsg = "����ϵͳԭ���ύʧ�ܣ����Ժ����ԡ�";
                return false;
            }
            return true; 
        }

        /// <summary>
        /// ʱ��β�ѯ����ά�޼�¼
        /// </summary>
        /// <param name="begintime">��ʼʱ��</param>
        /// <param name="endtime">����ʱ��</param>
        public DataSet GetRecords(DateTime begintime,DateTime endtime)
        {
            DateTime dt = new DateTime();
            SqlGetCpRecords ii=null;
            bool beginnotset=begintime.Equals(dt);
            bool endnotset = endtime.Equals(dt);
            if(beginnotset && endnotset)
            {
                ii = new SqlGetCpRecords();
            }
            else if (beginnotset && !endnotset)
            {
                ii = new SqlGetCpRecords(true, endtime.AddDays(1));
            }
            else if (!beginnotset && endnotset)
            {
                ii = new SqlGetCpRecords(false, begintime);
            }
            else
            {
                ii = new SqlGetCpRecords(begintime, endtime.AddDays(1));
            }
            OpRepairQuery i = new OpRepairQuery(m_DbName, ii);
            if(i.Do() && i.Ds.Tables[0].Rows.Count>0)
            {
                DataTable dtable = i.Ds.Tables[0];
                dtable.Columns[0].ColumnName = "���ޱ��";
                dtable.Columns[1].ColumnName = "��λ���";
                dtable.Columns[2].ColumnName = "��������";
                dtable.Columns[3].ColumnName = "����ʱ��";
                dtable.Columns[4].ColumnName = "������";
                dtable.Columns[5].ColumnName = "����״̬";
                dtable.Columns[6].ColumnName = "ȷ�ϻ�ȡ��ʱ��";
            }
            return i.Ds;
        }
        
        /// <summary>
        /// ���ڱ��޵ĵ��Ա��޵��б�
        /// </summary>
        public DataSet GetOrderUnhandledList()
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlCpOrderUnhandledList());
            i.Do();
            if (i.Ds.Tables.Count>0)
            {
                i.Ds.Tables[0].Columns[0].ColumnName = "��λ���";
                i.Ds.Tables[0].Columns[1].ColumnName = "���޴���";
                i.Ds.Tables[0].Columns[2].ColumnName = "���籨��ʱ��";
            }
            return i.Ds;
        }
        /// <summary>
        /// ���ڱ��޵ĵ��Ա��޵���ϸ��Ϣ
        /// </summary>
        public DataSet GetOrderUnhandledDetail(string computer_num)
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlCpOrderUnhandledDetail(computer_num));
            i.Do();
            if (i.Ds.Tables.Count > 0)
            {
                i.Ds.Tables[0].Columns[0].ColumnName = "������";
                i.Ds.Tables[0].Columns[1].ColumnName = "��������";
                i.Ds.Tables[0].Columns[2].ColumnName = "����ʱ��";
            }
            return i.Ds;
        }

        /// <summary>
        /// ȷ�ϵ��Ա���
        /// </summary>
        /// <param name="computer_num">��λ���</param>
        /// <returns>�ɹ����</returns>
        public Boolean Confirm(string computer_num)
        {
            if(!_CheckCpNum(computer_num))
            {
                ErrorMsg = "��λ���\""+computer_num+"\"���Ϸ�";
                return false;
            }
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlComputerConfirm(computer_num));
            if(!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "�õ��Եı����ѱ�ȷ�ϻ�ȡ��!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ȡ�����Ա���
        /// </summary>
        /// <param name="computer_num">��λ���</param>
        /// <returns>�ɹ����</returns>
        public Boolean Cancel(string computer_num)
        {
            if (!_CheckCpNum(computer_num))
            {
                ErrorMsg = "��λ���\"" + computer_num + "\"���Ϸ�";
                return false;
            }
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlComputerCancel(computer_num));
            if (!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "�õ��Եı����ѱ�ȷ�ϻ�ȡ��!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ʱ��β�ѯ���Ա���ͳ��
        /// </summary>
        /// <param name="begintime">��ʼʱ��</param>
        /// <param name="endtime">����ʱ��</param>
        public DataSet GetStatistics(DateTime begintime, DateTime endtime)
        {
            DateTime dt = new DateTime();
            SqlCpStatistics ii = null;
            bool beginnotset = begintime.Equals(dt);
            bool endnotset = endtime.Equals(dt);
            if (beginnotset && endnotset)
            {
                ii = new SqlCpStatistics();
            }
            else if (beginnotset && !endnotset)
            {
                ii = new SqlCpStatistics(true, endtime.AddDays(1));
            }
            else if (!beginnotset && endnotset)
            {
                ii = new SqlCpStatistics(false, begintime);
            }
            else
            {
                ii = new SqlCpStatistics(begintime, endtime.AddDays(1));
            }
            OpRepairQuery i = new OpRepairQuery(m_DbName, ii);
            if (i.Do() && i.Ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtable = i.Ds.Tables[0];
                dtable.Columns[0].ColumnName = "���ޱ��";
                dtable.Columns[1].ColumnName = "��������";
            }
            return i.Ds;
        }

        public static string ParseDate(string date)
        {
            string ret;
            try
            {
                ret = string.Format("{0:yyyy-MM-dd hh:mm}", DateTime.Parse(date));
                return ret;
            }
            catch
            {
                return "";
            }
        }
    }
}
