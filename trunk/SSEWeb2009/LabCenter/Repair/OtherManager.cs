using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Repair.Ops;
using LabCenter.Repair.Sql;

namespace LabCenter.Repair
{
    public class OtherManager
    {
        string m_DbName = "LabCenter";
        public String ErrorMsg = "";

        private Boolean _CheckOrder(string reporter_id, string devname, string location, string description)
        {
            Boolean pass = true;
            if (null == reporter_id || reporter_id.Equals(""))
            {
                ErrorMsg += "��������ID����Ϊ�ա�";
                pass = false;
            }
            if (null == devname || devname.Equals(""))
            {
                ErrorMsg += "���豸����û�";
                pass = false;
            }
            if (null == location || location.Equals(""))
            {
                ErrorMsg += "����ȥ�������㣿��";
                pass = false;
            }
            if (null == description || description.Equals(""))
            {
                ErrorMsg += "��д����������ɡ�";
                pass = false;
            }
            return pass;
        }

        public Boolean NewOrder(string reporter_id,string devname,string location,string description)
        {
            if (!_CheckOrder(reporter_id,devname,location,description))
            {
                return false;
            }
            OpRepairExecute i = new OpRepairExecute(m_DbName,
                new SqlAddOtherOrder(reporter_id, devname, location, description));
            if (!i.Do())
            {
                //ErrorMsg = i.GetLastError();
                ErrorMsg = "�ύʧ��";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ʱ��β�ѯά�޼�¼
        /// </summary>
        /// <param name="begintime">��ʼʱ��</param>
        /// <param name="endtime">����ʱ��</param>
        public DataSet GetRecords(DateTime begintime, DateTime endtime)
        {
            DateTime dt = new DateTime();
            SqlGetOtherRecords ii = null;
            bool beginnotset = begintime.Equals(dt);
            bool endnotset = endtime.Equals(dt);
            if (beginnotset && endnotset)
            {
                ii = new SqlGetOtherRecords();
            }
            else if (beginnotset && !endnotset)
            {
                ii = new SqlGetOtherRecords(true, endtime.AddDays(1));
            }
            else if (!beginnotset && endnotset)
            {
                ii = new SqlGetOtherRecords(false, begintime);
            }
            else
            {
                ii = new SqlGetOtherRecords(begintime, endtime.AddDays(1));
            }
            OpRepairQuery i = new OpRepairQuery(m_DbName, ii);
            if (i.Do() && i.Ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtable = i.Ds.Tables[0];
                dtable.Columns[0].ColumnName = "���ޱ��";
                dtable.Columns[1].ColumnName = "�豸����";
                dtable.Columns[2].ColumnName = "λ����Ϣ";
                dtable.Columns[3].ColumnName = "��������";
                dtable.Columns[4].ColumnName = "����ʱ��";
                dtable.Columns[5].ColumnName = "������";
                dtable.Columns[6].ColumnName = "����״̬";
                dtable.Columns[7].ColumnName = "ȷ�ϻ�ȡ��ʱ��";
            }
            return i.Ds;
        }

        /// <summary>
        /// ���ڱ��޵ı��޵��б�
        /// </summary>
        public DataSet GetOrderUnhandledList()
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlOtherOrderUnhandledList());
            if(!i.Do())
            {
                ErrorMsg = "ϵͳæ���Ժ�����";
                return null;
            }
            if (i.Ds.Tables.Count > 0)
            {
                i.Ds.Tables[0].Columns[0].ColumnName = "���ޱ��";
                i.Ds.Tables[0].Columns[1].ColumnName = "�豸����";
                i.Ds.Tables[0].Columns[2].ColumnName = "�ص�";
                i.Ds.Tables[0].Columns[3].ColumnName = "����ʱ��";
            }
            return i.Ds;
        }
        /// <summary>
        /// ���ڱ��޵ļ�¼����ϸ��Ϣ
        /// </summary>
        public OtherRecord GetOrderUnhandledDetail(string recordid)
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlOtherOrderUnhandledDetail(recordid));
            if(!i.Do())
            {
                ErrorMsg = "ϵͳ�ڲ��������Ժ����ԡ�";
                return null;
            }
            if(0==i.Ds.Tables[0].Rows.Count)
            {
                ErrorMsg = "û�����������ڱ��޵ļ�¼";
                return null;
            }
            OtherRecord ord=new OtherRecord();
            DataRow dr=i.Ds.Tables[0].Rows[0];
            ord.RecordID=long.Parse(dr[0].ToString());
            ord.DevName=dr[1].ToString();
            ord.Location = dr[2].ToString();
            ord.Discription = dr[3].ToString();
            ord.Update_Time = DateTime.Parse(dr[4].ToString());
            ord.Reporter_ID = dr[5].ToString();
            return ord;
        }

        /// <summary>
        /// ȷ�ϱ���
        /// </summary>
        /// <param name="recordid">���ޱ��</param>
        /// <returns>�ɹ����</returns>
        public Boolean Confirm(string recordid)
        {
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlOtherConfirm(recordid));
            if (!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "���豸�����ѱ�ȷ�ϻ�ȡ��!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="recordid">���ޱ��</param>
        /// <returns>�ɹ����</returns>
        public Boolean Cancel(string recordid)
        {
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlOtherCancel(recordid));
            if (!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "���豸�����ѱ�ȷ�ϻ�ȡ��!";
                return false;
            }
            return true;
        }

        public static string ParseDate(string date)
        {
            return ComputerManager.ParseDate(date);
        }
    }
}
