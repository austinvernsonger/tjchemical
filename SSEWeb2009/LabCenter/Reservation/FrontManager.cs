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
        /// 返回能被预约的星期号
        /// </summary>
        /// <returns></returns>
        public DataSet GetValidDayofWeek(int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetbegDayofweek(term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 返回可选时间段
        /// </summary>
        /// <param name="dayofweek">选中的那天对应的星期号</param>
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
        /// 返回可选实验的名称
        /// </summary>
        /// <param name="spannumber">选中的那个时间段对应编号</param>
        /// <returns></returns>
        public DataSet GetValidExperiment(int spannumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetDateInfo(spannumber));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 返回对应时间段的设备剩余数量
        /// </summary>
        /// <param name="spannumber">指定时间段的编号</param>
        /// <returns></returns>
        public DataSet GetRemainDevice(int spannumber)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetRemainCount(spannumber));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 增加一条预约记录
        /// </summary>
        /// <param name="stuID">预约学生的账号</param>
        /// <param name="ExpID">实验编号</param>
        /// <param name="spanNum">预约的时间段编号</param>
        /// <returns>true表示预约成功</returns>
        public Boolean NewReservation(string stuID, int ExpID, int spanNum)
        {
            //先检查是否已预约此实验
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
                            ErrorMsg = "已预约此实验,不可重复预约!";
                            return false;
                        }
                        if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["TimeSpanID"].ToString()) == spanNum)
                        {
                            ErrorMsg = "此时间段已有预约!";
                            return false;
                        }
                    }
                }
            }

            //之后检查当前可否预约,距实验开始还剩的时间是否在限定的时间之外
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
                ErrorMsg = "预约失败,请稍后再试!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 临时预约实验
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
            
            //先检查是否已预约此实验
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
                            ErrorMsg = "已预约此实验,不可重复预约!";
                            return false;
                        }
                        if (Convert.ToInt32(i.Ds.Tables[0].Rows[j]["TimeSpanID"].ToString()) == Convert.ToInt32(o.Ds.Tables[0].Rows[0]["TimeSpanID"].ToString()))
                        {
                            ErrorMsg = "此时间段已有预约!";
                            return false;
                        }
                    }
                }
            }

            OpReservationExecute k = new OpReservationExecute(m_DbName, new SqladdReservation(stuid, Convert.ToInt32(o.Ds.Tables[0].Rows[0]["ExperimentID"].ToString()), Convert.ToInt32(o.Ds.Tables[0].Rows[0]["TimeSpanID"].ToString())));
            if (!k.Do())
            {
                ErrorMsg = "预约失败,请稍后再试!";
                return false;
            }
            //设备减一
            if (!UpdateRemainDevice(Convert.ToInt32(o.Ds.Tables[0].Rows[0]["TimeSpanID"].ToString()),-1))
            {
                ErrorMsg = "预约失败,请稍后再试";
                return false;
            }
            return true;
        }
        /// <summary>
        /// 返回指定的ID对应的时间段
        /// </summary>
        /// <param name="spanID">指定的时间段ID</param>
        /// <returns></returns>
        public DataSet GetTimeSpanByID(int spanID)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetTimeSpanByID(spanID));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 更新剩余设备数量
        /// </summary>
        /// <param name="spanNum">对应的时间段</param>
        /// <param name="newCount">数量变化,-1表示减少一</param>
        /// <returns></returns>
        public Boolean UpdateRemainDevice(int spanNum, int newCount)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqlupdateRemainCount(spanNum,newCount));
            if(!i.Do())
            {
                ErrorMsg = "预约失败,请稍后再试";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 返回某学生当前的预约记录
        /// </summary>
        /// <param name="Stuid">学生账号</param>
        /// <returns>空则表示未预约任何实验</returns>
        public DataSet GetReservationByStuid(string Stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetReservationByStuid(Stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取消预约
        /// </summary>
        /// <param name="stuid">学生账号</param>
        /// <param name="labid">要取消的实验编号</param>
        public Boolean CancelReservation(string stuid, int dateIndex)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName, new SqlcancelReservation(stuid, dateIndex));
            if(!i.Do())
            {
                ErrorMsg = "取消预约失败,请稍后再试";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取出某学生的实验报告提交记录
        /// </summary>
        /// <param name="Stuid">学生账号</param>
        /// <returns></returns>
        public DataSet GetReportByStuid(string Stuid)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetReport(Stuid));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 判断学生预约的时间段里是否有与当前时刻相匹配的
        /// </summary>
        /// <param name="stuid">学号</param>
        /// <param name="term">学期</param>
        /// <param name="week">周号</param>
        /// <returns></returns>
        public DataSet GetCurrentReservation(string stuid,int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetCurrentReservation(stuid,term,week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取得某一预约的详细信息
        /// </summary>
        /// <param name="dateindex">预约标识符</param>
        /// <returns></returns>
        public DataSet GetReservationDetails(int dateindex)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName,new SqlgetReservationDetails(dateindex));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 增加一条登记记录
        /// </summary>
        /// <param name="stuid">学号</param>
        /// <param name="dateindex">预约标识符</param>
        /// <param name="logintime">登入时间</param>
        /// <param name="devicenum">设备号</param>
        /// <returns></returns>
        public Boolean AddRegInfo(string stuid,int dateindex,string logintime,int devicenum)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqladdRegInfo(stuid,dateindex,logintime,devicenum));
            if (!i.Do())
            {
                ErrorMsg = "添加登记记录失败!";
                return false;
            }
            DataSet ds = GetReservationDetails(dateindex);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ErrorMsg = "添加登记记录失败!";
                return false;
            }
            else
            {
                if (!CompareTwoTime(ds.Tables[0].Rows[0]["BeginTime"].ToString(),2))//迟到,记不良记录
                {
                    string BadRecord = "";
                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            "周" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
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
        /// 更新登记记录(登出时间)
        /// </summary>
        /// <param name="stuid">学号</param>
        /// <param name="dateindex">预约标识符</param>
        /// <returns></returns>
        public Boolean UpdateRegInfo(string stuid,int dateindex)
        {
            OpReservationExecute i = new OpReservationExecute(m_DbName,new SqlupdateRegInfo(stuid,dateindex));
            if (!i.Do())
            {
                ErrorMsg = "更新登记记录(登出时间)失败";
                return false;
            }
            DataSet ds = GetReservationDetails(dateindex);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ErrorMsg = "更新登记记录(登出时间)失败";
                return false;
            }
            else
            {
                if (!CompareTwoTime(ds.Tables[0].Rows[0]["EndTime"].ToString(), 3))//产生不良记录
                {
                    string BadRecord = "";
                    if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == "")
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            "周" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
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

            //更新或添加StuLabInfo记录
            int curterm = (int)BasicConfig.CurrentTerm;
            OpReservationQuery j = new OpReservationQuery(m_DbName,new SqlgetExistStuLabInfo(stuid,Convert.ToInt32(ds.Tables[0].Rows[0]["ExperimentID"].ToString()),curterm));
            j.Do();
            if (j.Ds == null ||j.Ds.Tables.Count == 0 || j.Ds.Tables[0].Rows.Count == 0)
            {
                ErrorMsg = "更新学生实验信息失败1!";
                return false;
            }
            else
            {
                OpReservationQuery k = new OpReservationQuery(m_DbName,new SqlgetLogTime(stuid,dateindex));
                k.Do();
                if (k.Ds == null ||k.Ds.Tables.Count == 0 || k.Ds.Tables[0].Rows.Count == 0)
                {
                    ErrorMsg = "更新学生实验信息失败2!";
                    return false;
                }
                if (Convert.ToInt32(j.Ds.Tables[0].Rows[0][0].ToString()) == 0)//第一次做该实验
                {
                    i = new OpReservationExecute(m_DbName, new SqladdStuLabInfo(stuid, Convert.ToInt32(ds.Tables[0].Rows[0]["ExperimentID"].ToString()),Convert.ToInt32(k.Ds.Tables[0].Rows[0]["minutes"].ToString()),curterm));
                }
                else//已经做过该实验
                {
                    i = new OpReservationExecute(m_DbName, new SqlupdateStuLabInfo(stuid, Convert.ToInt32(ds.Tables[0].Rows[0]["ExperimentID"].ToString()), curterm, Convert.ToInt32(k.Ds.Tables[0].Rows[0]["minutes"].ToString())));
                }
                if (!i.Do())
                {
                    ErrorMsg = "更新学生实验信息失败3!";///////<---2009/10/27待改
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 比较当前时刻是否超过某一时间限制
        /// </summary>
        /// <param name="TimeString"></param>
        /// <param name="TimeConstraintKind">时间限制类型</param>
        /// <returns></returns>
        public Boolean CompareTwoTime(string TimeString,int TimeConstraintKind)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = Convert.ToDateTime(dt1.ToLongDateString() + " " + TimeString);
            int minute;
            if (TimeConstraintKind == 1)//实验开始前多长时间停止预约
            {
                minute = (int)BasicConfig.TimeConstraint1;
                dt1 = dt1.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "实验开始前" + minute.ToString() + "分钟,停止预约此实验!";
                    return false;
                }
            }
            else if (TimeConstraintKind == 2)//已预约的学生在实验开始多长时间以后登记,算作不良记录
            {
                minute = (int)BasicConfig.TimeConstraint2;
                dt2 = dt2.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "距实验开始超过" + minute.ToString() + "分钟登入,记一次迟到记录!";
                    return false;
                }
            }
            else if (TimeConstraintKind == 3)//实验结束多长时间以后未登出,算作不良记录
            {
                minute = (int)BasicConfig.TimeConstraint3;
                dt2 = dt2.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "距实验结束超过" + minute.ToString() + "分钟登出,记一次不良记录!";
                    return false;
                }
            }
            else if (TimeConstraintKind == 4)//未预约的学生在本实验时间段开始多久以后,如果要在本时间段继续做实验,需要考虑下一时间段的预约情况
            {
                minute = (int)BasicConfig.TimeConstraint4;
                dt2 = dt2.Add(new TimeSpan(0, minute, 0));
                if (dt1.CompareTo(dt2) > 0)
                {
                    ErrorMsg = "当前时刻已经超过临时预约的时间限制(距本时间段开始时刻" + minute.ToString() + "分钟内),无法继续预约本时间段!";
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 更新预约记录
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="dateindex"></param>
        /// <param name="state"></param>
        /// <param name="ifpenalty">是否为不良记录</param>
        /// <param name="penaltyrecord">不良记录备注</param>
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
                ErrorMsg = "更新预约记录失败!";
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
        /// 取出某学生未登出的RegInfo记录
        /// </summary>
        /// <param name="stuid">学号</param>
        /// <returns></returns>
        public DataSet GetIncompleteRegInfo(string stuid,int term,int week)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetIncompleteRegInfo(stuid, term, week));
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 取出当前时刻所在的时间段相关信息
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
        /// 取出当前时刻相应的下一时间段相关信息
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
        /// 检查某学生在当天是否有"未应约"或"未登出"的不良记录
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
                        BadRecord = "在"+ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "在" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            "周" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "未应约!";
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
                        BadRecord = "在" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "在" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            "周" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "规定时间内未登出!";

                    StudentNo sn = GetStudentNo(stuid, path);
                    if (sn!= null)//多人实验
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
        /// 检查所有学生在当前是否有"未应约"或"未登出"的不良记录
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
                        BadRecord = "在" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "在" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            "周" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "未应约!";
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
                        BadRecord = "在" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    else
                    {
                        BadRecord = "在" + ds.Tables[0].Rows[0]["TermNumber"].ToString() +
                            "学期，预约了第" + ds.Tables[0].Rows[0]["WeekNumber"].ToString() +
                            "周 周" + ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString() + " " +
                            ds.Tables[0].Rows[0]["BeginTime"].ToString() + "到" +
                            "周" + ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() +
                            ds.Tables[0].Rows[0]["EndTime"].ToString() + "的实验(" +
                            ds.Tables[0].Rows[0]["ExperimentName"].ToString() + ");";
                    }
                    BadRecord += "规定时间内未登出!";

                    StudentNo sn = GetStudentNo(stuid, path);
                    if (sn != null)//多人实验
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
        /// 获得多人实验学号列表
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
        /// 设置多人实验学号列表
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
        /// 更新多人实验学号列表
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
                            ErrorMsg = "学号为" + stuid + "的学生当前有一个多人实验未登出!";
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
                    ErrorMsg = "多人实验的学号列表中不含给定学号:" + stuid;
                    return false;
                }
            }

            if (!SetMultiStudentLab(oldmsl, path))
            {
                ErrorMsg = "更新多人实验的学号列表时发生错误！";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 返回与某学生关联的多人实验的所有参与者学号
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
