using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using System.Data;

namespace Department.Engineering
{
    public class TeachingAgendaManage
    {
        int _teaMagID ;

        #region Constructor

        public TeachingAgendaManage()
        { }

        #endregion

        #region OtherFunctions

        public bool DeleteTutorChoosingAgendaWithAllStuChosingInfo()
        {
            DeleteStuChoosingTutorRelateToAgenda(_teaMagID);
            DeleteTeachingAgendaByTeaMagID(_teaMagID);
            return true;
        }

        #endregion

        #region GetFunctions

        /// <summary>
        /// 根据学号，返回该学生所属年级教学点的课程安排信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCourTimeArrangedByStuID(string stuId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourTimeForChosing(stuId));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该生的测评日程
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataSet GetStuEvaluationAgenda(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStuEvaluationAgendaByStuID(studentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        ///  判断该学生是否正处于测评时间段内
        /// </summary>
        /// <param name="studentid"></param>
        /// <returns></returns>
        public static bool GetEvaluationAgendaByStuID(string studentid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStuEvaluationAgendaByStuID(studentid));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //处于测评时段
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据学号，返回选导师日程信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataSet GetTeaChooseAgenda(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaChooseTimeByStu(studentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取导师选学生日程信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetChoosingStuAgenda()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetChoosingStuAgenda());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 判断该生当前是否在选导师日程内
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public static bool GetTeaChooseTimeByStu(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaChooseTimeByStu(studentID));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //在选导师日程内
                return true;
            }
            return false;
        }

        /// <summary>
        /// 返回所有尚未处理的选课日程信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnhandleChoosingCourseArragement()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllCourseArrange());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回所有的选课日程信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllChoosingCourseAgenda()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllChoosingCourseAgenda());
            op.Do();
            return op.Ds;
        }

        //根据查询条件（queryInfo），返回评教日程
        public DataSet GetTeachingEvaluationAgendaByQuery(QueryInfo qinfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeachingEvaluationAgendaByQuery(qinfo));
            op.Do();
            return op.Ds;
        }
        
        /// <summary>
        /// 返回日程信息
        /// </summary>
        /// <param name="teaMagID"></param>
        /// <returns></returns>
        public DataSet GetAgendaByTeaMagID(int teaMagID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAgendaByTeaMagID(teaMagID));
            op.Do();
            return op.Ds;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 添加评教日程
        /// </summary>
        /// <param name="qinfo"></param>
        /// <returns></returns>
        public bool AddTeachingEvaluationAgenda(QueryInfo qinfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddTeachingEvaluationAgenda(qinfo));
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
        /// 更新评教日程
        /// </summary>
        /// <param name="qinfo"></param>
        /// <returns></returns>
        public bool UpdateTeachingEvaluationAgenda(QueryInfo qinfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTeachingEvaluationAgenda(qinfo));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新选课日程
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="teaMagID"></param>
        /// <returns></returns>
        public bool UpdateChoosingCourseAgenda(string startTime, string endTime, int teaMagID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateChoosingCourseAgenda(startTime,endTime,teaMagID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region DeleteFunctions

        public bool DeleteTeachingAgendaByTeaMagID(int teaMagID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteTeachingAgendaByTeaMagID(teaMagID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除选导师日程中相关年级教学点学生的选导师信息
        /// </summary>
        /// <param name="teaMagID"></param>
        /// <returns></returns>
        public bool DeleteStuChoosingTutorRelateToAgenda(int teaMagID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStuChoosingTutorRelateToAgenda(teaMagID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Transaction

        public bool DeleteTutorChoosingAgendaByTran(int teaMagID)
        {
            _teaMagID = teaMagID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(DeleteTutorChoosingAgendaWithAllStuChosingInfo));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
