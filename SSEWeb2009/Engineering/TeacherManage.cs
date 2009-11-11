using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class TeacherManage
    {
        private string _studentID;
        private Willing _stuWill;
        private int _attachid;
        private string[] _teacher;
        private string _blindReviewNo;
        public string errorMessage = "";

        public TeacherManage()
        { }

      
        public bool AddTeaStuInfoAfterDelete()
        {
            StudentManage sMag = new StudentManage();
            sMag.DeleteExistTutorChoosingInfo(_studentID);
            AddTeaStuInfo();
            return true;
        }

        public DataSet GetTeacherFromUsers()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeacherFromUsers());
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--请选择--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            return ds;
        }

        public bool AddTeaStuInfoEach(string teacherID, string will)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddTutorChooseInfo(_studentID, teacherID, will));
            op.Do();
            if(op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        public bool AddTeaStuInfo()
        {
            AddTeaStuInfoEach(_stuWill.FirstTeaID, "1");
            AddTeaStuInfoEach(_stuWill.SecondTeaID, "2");
            AddTeaStuInfoEach(_stuWill.ThirdTeaID, "3");
            return true;
        }

        /// <summary>
        /// 判断当前的选导师日程是否存在
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns>存在返回false，否则返回true</returns>
        public bool IsExistTeaChooseTimeByQInfo(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaChooseTimeByQInfo(qInfo));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 添加选导师日程安排
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public bool AddTeacherChooseTime(QueryInfo qInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddTeaChooseTime(qInfo));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过qInfo获取选导师日程
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public DataSet GetTeaChooseTimeByQInfo(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaChooseTimeByQInfo(qInfo));
            op.Do();
            return op.Ds;
        }

        public DataSet GetTeaChooseTimeByQInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaChooseTimeByQInfoWithNull());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 更新选择导师的日程
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public bool UpdateChooseTime(QueryInfo qInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTeaChooseTime(qInfo));
            op.Do();
            if (op.ExecuteResult == true)

            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 删除选择导师的日程
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="teaSchoolID"></param>
        /// <returns></returns>
        public bool DeleteTeaChooseTime(string grade, int teaSchoolID)
        {

            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDelTeaChooseTime(grade, teaSchoolID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 返回所有可带学生的导师列表
        /// (只能返回teacherordinary表中信息)
        /// </summary>
        /// <returns></returns>
        public DataSet GetTutorsList()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTutorsList());
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "---请选择导师---";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            return ds;
        }

        /// <summary>
        /// 返回一个导师所带的所有学生的列表，以学生学号降序
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <returns></returns>
        public DataSet GetStudentsOfTutor(string TeacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStdsOfTutor(TeacherID));
            op.Do();
            return op.Ds;
        }

        public DataSet GetCompleteTutorTime()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCompleteTutorTime());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 查询学生所选择的导师
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public DataSet GetTutorOfStds(ChosenTutor ct)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTutorOfStds(ct));
            op.Do();
            return op.Ds;
        }
      


        /// <summary>
        /// 建立教师姓名和教工号的对应关系
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> TeacherInfo()
        {
            Dictionary<string, string> teaInfo = new Dictionary<string, string>();
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllTeacherInfo());
            op.Do();
            DataSet ds = op.Ds;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                teaInfo.Add(dr["Name"].ToString(), dr["TeacherID"].ToString());
            }
            return teaInfo;
        }

        public DataSet GetTutorChoosingStatus(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTutorChoosingStatus(qInfo));
            op.Do();
            return op.Ds;
        }

        public void UpdateDefenceApplyIsQualify(string stuid)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateDefenceApplyIsQualify(stuid));
            op.Do();
        }

        

        public void AddThesisJudgeInfo(string teacherid, int isleader, string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddThesisJudgeInfo(teacherid, isleader, studentID));
            op.Do();
        }

        public bool DisposeThesisJudgeInfo()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    AddThesisJudgeInfo(_teacher[i], 1, _studentID);
                }
                else
                {
                    AddThesisJudgeInfo(_teacher[i], 0, _studentID);
                }
            }
            StudentManage sMag = new StudentManage();
            sMag.AddBindReviewNoForStu(_studentID, _blindReviewNo);
            UpdateDefenceApplyIsQualify(_studentID);
            return true;
        }

        public bool TranThesisJudgeInfo(string stuid, string[] teacher, string BlindReviewNo)
        {
            _teacher = teacher;
            _blindReviewNo = BlindReviewNo;
            _studentID = stuid;

            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(DisposeThesisJudgeInfo));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        public DataSet GetAllPaperJudgeResult()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllPaperJudgeResult());
            op.Do();
            return op.Ds;
        }

        

        public DataSet GetOtherPaperJudgeMembers(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetOtherPaperJudgeMembers(studentID));
            op.Do();
            return op.Ds;
        }

        public DataSet GetPaperJudgeResultByQueryInfo(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPaperJudgeResultByQueryInfo(qInfo));
            op.Do();
            return op.Ds;
        }

        #region GetFunctions

        /// <summary>
        /// 返回所有教师的编号和姓名
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllTeacherInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllTeacherInfo());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 对返回所有教师的编号和姓名进行扩展（用于dropdownlist）
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllTeacherInfoList()
        {
            DataSet ds = GetAllTeacherInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--请选择--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            return ds;
        }

        /// <summary>
        /// 返回所有可带研究生的导师信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTutorsInfoList()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTutorsInfoList());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据教师工号，返回该教师的详细信息
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetTeacherInfoByTeacherID(string teacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeacherInfoByteacherID(teacherID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据教师工号，返回该教师的姓名
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public string GetTeacherName(string teacherID)
        {
            DataSet ds = GetTeacherInfoByTeacherID(teacherID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["Name"].ToString();
            }
            return null;
        }

        /// <summary>
        /// 获取所有导师的信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllTutorInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllTutorInfo());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 对导师信息进行操作扩展
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllTutorInfoList()
        {
            DataSet ds = null;
            ds = GetAllTutorInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--请选择--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            return ds;
        }

        /// <summary>
        /// 通过教师工号获取教师要教授的课程
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetTeacherCourseInfo(string teacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeacherClassByTeaID(teacherID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回该导师所带学生的答辩申请信息
        /// </summary>
        /// <param name="teacherid"></param>
        /// <returns></returns>
        public DataSet GetDefenceApplyByTeaID(string teacherid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetDefenceApplyByTeaID(teacherid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取该教师所有的预评审论文信息
        /// </summary>
        /// <param name="teacherid"></param>
        /// <returns></returns>
        public DataSet GetAllPrePaper(string teacherid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllPrePaper(teacherid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据盲审号，获取与其对应的预审论文信息
        /// </summary>
        /// <param name="bNo"></param>
        /// <returns></returns>
        public DataSet GetAllPrePaperBybNo(string bNo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllPrePaperByBNo(bNo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回成员的评审信息
        /// </summary>
        /// <param name="bNo"></param>
        /// <returns></returns>
        public DataSet GetNoLeaderPaperJudge(string bNo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetNoLeaderPaperJudge(bNo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据教师工号和论文盲审号，返回论文评审信息
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="bNo">论文盲审号</param>
        /// <returns></returns>
        public DataSet GetPaperJudgeByteaidAndbNo(string teacherID, string bNo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPaperJudgeByteaIDandbNo(teacherID, bNo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回非MSE部门的教师
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeachersNotInMSE()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeachersNotInMSE());
            op.Do();
            return op.Ds;
        }

        #endregion 

        #region AddFunctions

        /// <summary>
        /// 添加学生选导师的志愿
        /// </summary>
        /// <param name="stuID"></param>
        /// <param name="stuWill"></param>
        /// <returns></returns>
        public bool AddTeacherStudentInfo(string stuID, Willing stuWill)
        {
            _studentID = stuID;
            _stuWill = stuWill;

            if (AddTeaStuInfo() == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region UpdateFunctions

        /// <summary>
        /// 更新导师选学生意向
        /// </summary>
        /// <param name="stuID"></param>
        /// <param name="teaID"></param>
        public void UpdateTeaChooseStu(int status, string stuID, string teaID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTeaChooseStu(status, stuID, teaID));
            op.Do();
        }

        /// <summary>
        /// 更新论文评审状态
        /// </summary>
        /// <param name="pj"></param>
        /// <returns></returns>
        public bool UpdatePaperJudgeStatus(PaperJudge pj)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdatePaperJudageStatus(pj));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region TransactionFunctions

        /// <summary>
        /// 通过事务处理添加学生选导师的志愿
        /// </summary>
        /// <param name="stuID"></param>
        /// <param name="stuWill"></param>
        /// <returns></returns>
        public bool AddTeacherStudentInfoByTran(string stuID, Willing stuWill)
        {
            _studentID = stuID;
            _stuWill = stuWill;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddTeaStuInfoAfterDelete));
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
