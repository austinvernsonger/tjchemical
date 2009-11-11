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
        /// 得到学年学期列表
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <returns>TermList对象</returns>
        public static TermList GetTermList(string path)
        {
            TermList tl = new TermList(path);
            TermList ret = (TermList)tl.Deserialize();
            //ResLog.Write(tl.Terms.ToString());
            return ret;
        }

        /// <summary>
        /// 得到周号列表
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <returns>WeekList对象</returns>
        public static WeekList GetWeekList(string path)
        {
            WeekList tl = new WeekList(path);
            WeekList ret = (WeekList)tl.Deserialize();
            return ret;
        }

        /// <summary>
        /// 得到当前的基本配置
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <returns>BasicConfig对象</returns>
        public static BasicConfig GetBasicConfig(string path)
        {
            BasicConfig bc = new BasicConfig(path);
            BasicConfig ret = (BasicConfig)bc.Deserialize();
            return ret;
        }

        /// <summary>
        /// 设置当前的基本配置
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <returns>成功与否</returns>
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
        /// 得到默认时间表
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <returns>时间表对象</returns>
        public static TimeTable GetDefaultTimeTable(string path)
        {
            TimeTable tt = new TimeTable(path);
            TimeTable ret = (TimeTable)tt.Deserialize();
            return ret;
        }

        /// <summary>
        /// 设置默认时间表
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <returns>成功与否</returns>
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
        /// 设置时间表
        /// </summary>
        /// <param name="ttp">xx</param>
        /// <returns>成功与否</returns>
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
                    ErrorMsg = "安排实验失败(无法为Monday添加新的timeinfo记录)!";
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
                    ErrorMsg = "安排实验失败(无法为Tuesday添加新的timeinfo记录)!";
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
                    ErrorMsg = "安排实验失败(无法为Wednesday添加新的timeinfo记录)!";
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
                    ErrorMsg = "安排实验失败(无法为Thursday添加新的timeinfo记录)!";
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
                    ErrorMsg = "安排实验失败(无法为Friday添加新的timeinfo记录)!";
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
                    ErrorMsg = "安排实验失败(无法为Saturday添加新的timeinfo记录)!";
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// 安排实验
        /// </summary>
        /// <param name="termnumber">学年学期</param>
        /// <param name="week">周</param>
        /// <param name="experimentids">安排的实验id列表</param>
        /// <returns></returns>
        public static Boolean ArrangeExperiment(int termnumber,int week,List<int> experimentids,TimeTable tt)
        {
            //检查TimeInfo表
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetTimeInfoRecordCount(termnumber,week));
            i.Do();
            if(i.Ds.Tables[0].Rows[0][0].ToString() != "0")
            {
                OpReservationExecute j = new OpReservationExecute(m_DbName,new SqldeleteTimeInfo(termnumber,week));
                if(!j.Do())
                {
                    ErrorMsg = "安排实验失败(无法删除旧的timeinfo记录)!";
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

            //DateInfo加记录
            OpReservationExecute k;
            foreach(int experimentid in experimentids)
            {
                k = new OpReservationExecute(m_DbName,new SqladdDateInfo(experimentid,termnumber,week));
                if(!k.Do())
                {
                    ErrorMsg = "安排实验失败(无法添加新的dateinfo记录)!";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 设置当前周
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static Boolean SetCurrentWeek(string week)
        {
            return false;
        }

        /// <summary>
        /// 取出实验列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetExperiment()
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetExperiment());
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取出当前有效的实验列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetvalidExperiment()
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetValidExperiment());
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取出以前某学期某周安排的实验信息
        /// </summary>
        /// <param name="term">某学期</param>
        /// <param name="week">某周</param>
        /// <returns></returns>
        public static DataSet GetHistoryExperiment(int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetHistoryExperiment(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 添加新的实验
        /// </summary>
        /// <param name="name">实验名称</param>
        /// <returns></returns>
        public static Boolean AddExperiment(string name)
        {
            //先检查是否已存在相同实验名
            DataSet ds = GetExperiment();
            if(ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    if(name == dr["ExperimentName"].ToString())
                    {
                        ErrorMsg = "已存在该实验!";
                        return false;
                    }
                }
            }
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqladdExperiment(name));
            if(!i.Do())
            {
                ErrorMsg = "添加实验失败!";
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// 取得某一实验的信息
        /// </summary>
        /// <param name="experimentid">实验ID</param>
        /// <returns></returns>
        public static DataSet GetuniqueExperiment(int experimentid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetUniqueExperiment(experimentid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 修改实验信息
        /// </summary>
        /// <param name="experimentid">实验ID</param>
        /// <param name="experimentname">修改后的实验名称</param>
        /// <param name="ifvalid">实验是否有效</param>
        /// <returns>修改成功与否</returns>
        public static Boolean UpdateuniqueExperiment(int experimentid, string experimentname, int ifvalid)
        {
            //先检查是否已存在相同实验名
            DataSet ds = GetExperiment();
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (experimentname == dr["ExperimentName"].ToString() && experimentid != Convert.ToInt32(dr["ExperimentID"]))
                    {
                        ErrorMsg = "相同的实验名称已存在!";
                        return false;
                    }
                }
            }

            OpReservationExecute i = new OpReservationExecute(m_DbName, new SqlupdateUniqueExperiment(experimentid, experimentname, ifvalid));
            if(!i.Do())
            {
                ErrorMsg = "保存修改失败!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取出当前的StuLabInfo的记录数
        /// </summary>
        /// <returns>某一学期</returns>
        public static DataSet GetReportCount(int term)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetReportCount(term));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 更新实验报告提交状态
        /// </summary>
        /// <param name="stuid">学号</param>
        /// <param name="expname">实验名</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public static bool UpdateReportState(string stuid, string expname, Boolean state)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName, new SqlupdateReportState(stuid, expname, state));
            if (!i.Do())
            {
                ErrorMsg = "更新失败!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取出实验报告提交情况信息列表
        /// </summary>
        /// <param name="term">某一学期</param>
        /// <returns></returns>
        public static DataSet GetReportsByTerm(int term)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportsDS(term));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取出当前正在实验的人数统计
        /// </summary>
        /// <param name="term">当前学年学期</param>
        /// <param name="week">当前周</param>
        /// <returns></returns>
        public static DataSet GetCurrentStudentDS(int term, int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetCurrentStudentDS(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 判断是否有覆盖当前时刻的时间段
        /// </summary>
        /// <param name="term">当前学年学期</param>
        /// <param name="week">当前周</param>
        /// <returns></returns>
        public static DataSet GetCurrentTimeSpan(int term, int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetCurrentTimeSpan(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取得某学期某实验某学生的实验报告记录
        /// </summary>
        /// <param name="term">某学期</param>
        /// <param name="experimentNumber">某实验</param>
        /// <param name="stuid">某学生</param>
        /// <returns></returns>
        public static DataSet GetReportByTNN(int term, int experimentNumber, string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByTNN(term, experimentNumber, stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取得某实验某学生的实验报告记录
        /// </summary>
        /// <param name="experimentNumber">某实验</param>
        /// <param name="stuid">某学生</param>
        /// <returns></returns>
        public static DataSet GetReportByNN(int experimentNumber, string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByNN(experimentNumber, stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取得某学生的实验报告记录
        /// </summary>
        /// <param name="stuid">某学生</param>
        /// <returns></returns>
        public static DataSet GetReportByNo(string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByNo(stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取得某学期某实验的实验报告记录
        /// </summary>
        /// <param name="term">某学期</param>
        /// <param name="experimentNumber">某实验</param>
        /// <returns></returns>
        public static DataSet GetReportByTNa(int term, int experimentNumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByTNa(term, experimentNumber));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取得某学期某学生的实验报告记录
        /// </summary>
        /// <param name="term">某学期</param>
        /// <param name="stuid">某学生</param>
        /// <returns></returns>
        public static DataSet GetReportByTNo(int term, string stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByTNo(term, stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取得某实验的实验报告记录
        /// </summary>
        /// <param name="experimentNumber">某实验</param>
        /// <returns></returns>
        public static DataSet GetReportByName(int experimentNumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReportByName(experimentNumber));
            i.Do();
            return i.Ds;
        }
    }
}
