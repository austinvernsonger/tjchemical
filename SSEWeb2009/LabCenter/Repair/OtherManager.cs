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
                ErrorMsg += "【报修者ID不能为空】";
                pass = false;
            }
            if (null == devname || devname.Equals(""))
            {
                ErrorMsg += "【设备名称没填】";
                pass = false;
            }
            if (null == location || location.Equals(""))
            {
                ErrorMsg += "【我去哪里找你？】";
                pass = false;
            }
            if (null == description || description.Equals(""))
            {
                ErrorMsg += "【写点故障描述吧】";
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
                ErrorMsg = "提交失败";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 时间段查询维修记录
        /// </summary>
        /// <param name="begintime">开始时间</param>
        /// <param name="endtime">结束时间</param>
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
                dtable.Columns[0].ColumnName = "报修编号";
                dtable.Columns[1].ColumnName = "设备名称";
                dtable.Columns[2].ColumnName = "位置信息";
                dtable.Columns[3].ColumnName = "故障描述";
                dtable.Columns[4].ColumnName = "报修时间";
                dtable.Columns[5].ColumnName = "报修者";
                dtable.Columns[6].ColumnName = "报修状态";
                dtable.Columns[7].ColumnName = "确认或取消时间";
            }
            return i.Ds;
        }

        /// <summary>
        /// 正在报修的报修的列表
        /// </summary>
        public DataSet GetOrderUnhandledList()
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlOtherOrderUnhandledList());
            if(!i.Do())
            {
                ErrorMsg = "系统忙请稍后再试";
                return null;
            }
            if (i.Ds.Tables.Count > 0)
            {
                i.Ds.Tables[0].Columns[0].ColumnName = "报修编号";
                i.Ds.Tables[0].Columns[1].ColumnName = "设备名称";
                i.Ds.Tables[0].Columns[2].ColumnName = "地点";
                i.Ds.Tables[0].Columns[3].ColumnName = "报修时间";
            }
            return i.Ds;
        }
        /// <summary>
        /// 正在报修的记录的详细信息
        /// </summary>
        public OtherRecord GetOrderUnhandledDetail(string recordid)
        {
            OpRepairQuery i = new OpRepairQuery(m_DbName, new SqlOtherOrderUnhandledDetail(recordid));
            if(!i.Do())
            {
                ErrorMsg = "系统内部错误，请稍后再试。";
                return null;
            }
            if(0==i.Ds.Tables[0].Rows.Count)
            {
                ErrorMsg = "没有这样的正在报修的记录";
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
        /// 确认报修
        /// </summary>
        /// <param name="recordid">报修编号</param>
        /// <returns>成功与否</returns>
        public Boolean Confirm(string recordid)
        {
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlOtherConfirm(recordid));
            if (!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "该设备报修已被确认或取消!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取消报修
        /// </summary>
        /// <param name="recordid">报修编号</param>
        /// <returns>成功与否</returns>
        public Boolean Cancel(string recordid)
        {
            OpRepairExecute i = new OpRepairExecute(m_DbName, new SqlOtherCancel(recordid));
            if (!i.Do() || !i.ExecuteResult)
            {
                ErrorMsg = "该设备报修已被确认或取消!";
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
