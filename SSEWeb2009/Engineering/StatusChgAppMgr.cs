using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Department.Engineering;

namespace Department.Engineering
{
   public class StatusChgAppMgr
   {
       #region Constructor

       public StatusChgAppMgr()
        { }

       #endregion

       #region GetFunctions

       /// <summary>
       /// 通过学号获取该生的学籍变动信息
       /// </summary>
       /// <param name="stuID"></param>
       /// <returns></returns>
       public DataSet GetStudentAppInfo(string stuID)
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStatusAppInfo(stuID));
           op.Do();
           return op.Ds;
       }

       /// <summary>
       /// 根据学籍变动的编号获取尚未处理的学籍变动申请
       /// </summary>
       /// <param name="applyId">学籍变动信息编号</param>
       /// <returns></returns>
       public DataSet GetUnhandleAppInfoByAppID(int applyId)
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStatusAppInfoByAppID(applyId));
           op.Do();
           return op.Ds;
       }

       public static DataSet GetApplyInfoByAppID(int applyId)
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStatusAppInfoByAppID(applyId));
           op.Do();
           return op.Ds;
       }

       /// <summary>
       /// 根据查询条件返回学籍变动的相关信息
       /// </summary>
       /// <param name="qInfo"></param>
       /// <returns></returns>
       public DataSet GetStatusChgRecord(QueryInfo qInfo)
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStatusChgRecord(qInfo));
           op.Do();
           return op.Ds;
       }

       /// <summary>
       /// 返回所有的学籍变动申请信息
       /// </summary>
       /// <returns></returns>
       public DataSet GetStatusChgRecord()
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStatusChgRecordWithoutBackSchool());
           op.Do();
           return op.Ds;
       }

       /// <summary>
       /// 返回所有待处理的学籍变动申请
       /// </summary>
       /// <returns></returns>
       public DataSet GetUnhandleStatusApp()
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetUnhandleStaApp());
           op.Do();
           return op.Ds;
       }

       /// <summary>
       /// 返回该年级该教学点的学籍变动申请信息
       /// </summary>
       /// <param name="teaSchoolID"></param>
       /// <param name="grade"></param>
       /// <returns></returns>
       public DataSet GetTSchoolStatusList(int teaSchoolID, string grade)
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTSchoolStatusList(teaSchoolID, grade));
           op.Do();
           return op.Ds;
       }

       /// <summary>
       /// 返回该教学点该申请类别的学籍申请变动信息
       /// </summary>
       /// <param name="teaSchoolID"></param>
       /// <param name="applyCategory"></param>
       /// <returns></returns>
       public DataSet GetStatusChangeInTSchool(int teaSchoolID, string applyCategory)
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStatusChangeInTSchool(teaSchoolID, applyCategory));
           op.Do();
           return op.Ds;
       }

       public static bool GetStudentsApplyStatus(string studentID)
       {
           OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStatusAppInfo(studentID));
           op.Do();
           DataSet ds = null;
           ds = op.Ds;
           if (ds.Tables[0].Rows[0][0] == System.DBNull.Value)
           {
               //该生没有申请记录
               return true;
           }
           else
           { 
               //该生有申请记录
               int stuStatusID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
               ds = GetApplyInfoByAppID(stuStatusID);
               int applyResult = Convert.ToInt32(ds.Tables[0].Rows[0]["ApplyResult"]);
               int activity = Convert.ToInt32(ds.Tables[0].Rows[0]["Activiy"]);
               if (applyResult == 1 && activity == 0)
               {
                   //该申请记录正处于活动中
                   return false;
               }
               //申请记录已成为历史
               return true;
           }
       }

       #endregion

       #region AddFunctions

       /// <summary>
       /// 添加新的学籍变动申请信息
       /// </summary>
       /// <param name="studID"></param>
       /// <param name="applyCategory">学籍变动类型</param>
       /// <param name="applyReason">学籍变动原因</param>
       /// <returns></returns>
       public Boolean AddNewApply(string studID, string applyCategory, string applyReason)
       {
           OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddStatusChgApp(studID, applyCategory, applyReason));
           op.Do();
           if (op.ExecuteResult == false)
           {
               return false;
           }
           return true;
       }

        #endregion

        #region UpdateFunctions

       /// <summary>
       /// 更新学籍申请的状态信息
       /// </summary>
       /// <param name="applyID"></param>
       /// <returns></returns>
       public bool UpdateAppStatusActivity(int applyID)
       {
           OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateAppStatusActivity(applyID));
           op.Do();
           if (op.ExecuteResult == true)
           {
               return true;
           }
           return false;
       }

       /// <summary>
       /// 更新学期申请的状态信息和返校时间（当学生返校时）
       /// </summary>
       /// <param name="applyID"></param>
       /// <returns></returns>
       public bool UpdateAppStatusActivityAndBackTime(int applyID)
       {
           OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateAppStatusActivityAndBackTime(applyID));
           op.Do();
           if (op.ExecuteResult == true)
           {
               return true;
           }
           return false;
       }

       /// <summary>
       /// 更新申请信息
       /// </summary>
       /// <param name="applyID"></param>
       /// <param name="appReslut"></param>
       /// <param name="appRemark"></param>
       /// <returns></returns>
       public Boolean HandleStatusChgApp(int applyID, int appReslut, string appRemark)
       {
           OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateStaChgApp(applyID, appReslut, appRemark));
           op.Do();
           if (op.ExecuteResult == false)
           {
               //ErrorMsg = "由于系统原因，提交失败，请稍后再试。";
               return false;
           }

           return true;
       }

        #endregion
    }
}
