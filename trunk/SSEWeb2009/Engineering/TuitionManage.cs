using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Department.Engineering
{
    public class TuitionManage
    {
        #region SomeVariant

        string DbName = "Engineering";
        public String ResultMsg = "";
        private DataSet ds = null;
        public DataSet DS
        {
            set { ds = value; }
        }

        #endregion

        #region Methods

        public TuitionManage() { }

        public DataSet GetTuitionInfo(int tuitionID)
        {
            OpEngineerQuery op = new OpEngineerQuery(DbName, new SqlGetTuitionInfoByTuitionID(tuitionID));
            op.Do();
            return op.Ds;
        }
       
        #endregion

        #region GetFunctions

        /// <summary>
        /// 根据学号返回该学生的缴费信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTuitionInfo(string stuId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTuitionInfoByStudentID(stuId));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 重载函数返回缴费信息
        /// </summary>
        /// <param name="tInfo"></param>
        /// <returns></returns>
        public DataSet GetTuitionInfo(TuitionInfo tInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTuitionInfoByTuition(tInfo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 重载函数，返回所有学生的学费信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTuitionInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery(DbName, new SqlGetAllTuitionInfo());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 该账号该学期的学费信息是否存在
        /// </summary>
        /// <param name="stuID"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public bool GetTuitionInfobyTermStu(string stuID, string term)
        {
            OpEngineerQuery op = new OpEngineerQuery(DbName, new SqlGetTuitionInfobyTermStu(term, stuID));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //该学期的缴费信息存在
                return true;
            }
            return false;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 将该学期的缴费信息添加进数据库
        /// </summary>
        /// <param name="term">学期</param>
        /// <param name="ds">学费信息数据集</param>
        /// <returns></returns>
        public bool AddNewTuition(string term, DataSet ds)
        {
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TuitionInfo tuInfo = new TuitionInfo();
                    tuInfo.StudID = dr["stuid"].ToString().Trim();
                    tuInfo.ActualMoney = Double.Parse(dr["actualMoney"].ToString().Trim());
                    tuInfo.MustMoney = Double.Parse(dr["mustMoney"].ToString().Trim());
                    tuInfo.Remark = dr["remark"].ToString().Trim();
                    tuInfo.PaymentTerm = term.Trim();
                    //判断该学号该学期的缴费信息是否存在
                    if (GetTuitionInfobyTermStu(tuInfo.StudID, tuInfo.PaymentTerm) == true)
                    {
                        continue;
                    }
                    //将学费信息加入数据库中
                    AddTuitionInfo(tuInfo);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 添加新的缴费信息
        /// </summary>
        /// <param name="tu"></param>
        /// <returns></returns>
        public bool AddTuitionInfo(TuitionInfo tu)
        {
            OpEngineerExecute op = new OpEngineerExecute(DbName, new SqlAddTuitionInfo(tu));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region UpdateFunctions

        /// <summary>
        /// 更新缴费信息
        /// </summary>
        /// <param name="tInfo"></param>
        /// <returns></returns>
        public bool UpdateTuitionInfo(TuitionInfo tInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute(DbName, new SqlUpdateTuitionInfoByTuitionID(tInfo));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region DeleteFunctions

        /// <summary>
        /// 删除相应的学费信息
        /// </summary>
        /// <param name="ID">学费信息编号</param>
        /// <returns></returns>
        public bool DeleteTutionInfoByID(int ID)
        {
            OpEngineerExecute op = new OpEngineerExecute(DbName, new SqlDeleteTuitionInfoByID(ID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
