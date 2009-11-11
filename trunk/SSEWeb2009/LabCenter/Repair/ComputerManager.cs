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
                ErrorMsg += "(报修者ID不能为空)";
                pass=false;
            }
            if(!_CheckCpNum(computer_number))
            {
                ErrorMsg += "[机位编号不完整]";
                pass = false;
            }
            if(null==description || description.Equals(""))
            {
                ErrorMsg += "<写点故障描述吧>";
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
                ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
                return false;
            }
            return true; 
        }

        /// <summary>
        /// 时间段查询电脑维修记录
        /// </summary>
        /// <param name="begintime">开始时间</param>
        /// <param name="endtime">结束时间</param>
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
                dtable.Columns[0].ColumnName = "报修编号";
                dtable.Columns[1].ColumnName = "机位编号";
                dtable.Columns[2].ColumnName = "故障描述";
                dtable.Columns[3].ColumnName = "报修时间";
                dtable.Columns[4].ColumnName = "报修者";
                dtable.Columns[5].ColumnName = "报修状态";
                dtable.Columns[6].ColumnName = "确认或取消时间";
            }
            return i.Ds;
        }
        
        /// <summary>
        /// 正在报修的电脑报修的列表
        /// </summary>
        public DataSet GetOrderUnhandledList()
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlCpOrderUnhandledList());
            i.Do();
            if (i.Ds.Tables.Count>0)
            {
                i.Ds.Tables[0].Columns[0].ColumnName = "机位编号";
                i.Ds.Tables[0].Columns[1].ColumnName = "报修次数";
                i.Ds.Tables[0].Columns[2].ColumnName = "最早报修时间";
            }
            return i.Ds;
        }
        /// <summary>
        /// 正在报修的电脑报修的详细信息
        /// </summary>
        public DataSet GetOrderUnhandledDetail(string computer_num)
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlCpOrderUnhandledDetail(computer_num));
            i.Do();
            if (i.Ds.Tables.Count > 0)
            {
                i.Ds.Tables[0].Columns[0].ColumnName = "报修者";
                i.Ds.Tables[0].Columns[1].ColumnName = "故障描述";
                i.Ds.Tables[0].Columns[2].ColumnName = "报修时间";
            }
            return i.Ds;
        }

        /// <summary>
        /// 确认电脑报修
        /// </summary>
        /// <param name="computer_num">机位编号</param>
        /// <returns>成功与否</returns>
        public Boolean Confirm(string computer_num)
        {
            if(!_CheckCpNum(computer_num))
            {
                ErrorMsg = "机位编号\""+computer_num+"\"不合法";
                return false;
            }
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlComputerConfirm(computer_num));
            if(!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "该电脑的报修已被确认或取消!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取消电脑报修
        /// </summary>
        /// <param name="computer_num">机位编号</param>
        /// <returns>成功与否</returns>
        public Boolean Cancel(string computer_num)
        {
            if (!_CheckCpNum(computer_num))
            {
                ErrorMsg = "机位编号\"" + computer_num + "\"不合法";
                return false;
            }
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlComputerCancel(computer_num));
            if (!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "该电脑的报修已被确认或取消!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 时间段查询电脑报修统计
        /// </summary>
        /// <param name="begintime">开始时间</param>
        /// <param name="endtime">结束时间</param>
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
                dtable.Columns[0].ColumnName = "报修编号";
                dtable.Columns[1].ColumnName = "报修人数";
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
