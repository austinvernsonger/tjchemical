using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class StudentManage
    {
        public string errorMsg = "";
        private DataSet ds = null;
        private StudentInfo _stuInfo;
        private Willing _will;
        private QueryInfo _qInfo;
        private Dictionary<string, string> _stuTea;
        private string _studentID;

        public DataSet DS
        {
            set { ds = value; }
        }

        public StudentManage() { }

        public bool UpdateStudentMSEByStu(StudentInfo stuInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateStudentMSE(stuInfo));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        public bool UpdateStudentInfoIncludeExtension()
        {
            //更新Student表中学生信息
            UpdateStudentInfoByStu(_stuInfo);
            //更新MSE表中学生信息
            UpdateStudentMSEByStu(_stuInfo);
            //
            return true;
        }

        public bool UpdateStudentInfo()
        {
            UpdateStudentInfoByStu(_stuInfo);
            UpdateStudentMSEByStu(_stuInfo);
            updateStudentPassword(_stuInfo.StuID, _stuInfo.Password);
            RoleManage rMag = new RoleManage();
            rMag.UpdateUser(_stuInfo.StuID, _stuInfo.StuName);
            return true;
        }

        public bool AddNewStudent()
        {
            RoleManage rMag = new RoleManage();
            //添加学生账号
            AddAccountInfo(_stuInfo);
            //添加学生基本信息
            AddStuBasicInfo(_stuInfo);
            //添加部门用户
            AddUsers(_stuInfo);
            //添加用户角色， 4表示学生角色
            rMag.AddUserRole(_stuInfo.StuID, 4);
            //添加MSE的信息
            AddStuMSEInfo(_stuInfo);
            return true;
        }

        public bool DeleteInformationsRelatedToStudent()
        {
            RoleManage rMag = new RoleManage();
            rMag.DeleteRolesAoutUserID(_studentID);
            rMag.DeleteUser(_studentID);
            DeleteStudentChooseTutorInfo(_studentID);
            DeleteStudentTuitionInfo(_studentID);
            DeleteStudentThesisJudgeInfo(_studentID);
            DeleteStuStatusChangInfo(_studentID);
            DeleteStudentExamInfo(_studentID);
            DeleteStuDefenceApplyInfo(_studentID);
            DeleteStudentDisscussion(_studentID);
            DeleteStudentAttachment(_studentID);
            DeleteStudentMSE(_studentID);
            DeleteStudentInfo(_studentID);
            DeleteAccountInfo(_studentID);
            return true;
        }

         /// <summary>
         /// 将学生信息添加进数据库
         /// </summary>
         /// <returns></returns>
         public bool ToStuInfoDatabase()
        {
            StudentInfo stuInfo = new StudentInfo();
            TeachingSchool ts = new TeachingSchool();
            int tID = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                stuInfo.StuID = dr["sStuid"].ToString().Trim();
                stuInfo.StuName = dr["sName"].ToString().Trim();
                stuInfo.Password = dr["sPassword"].ToString().Trim();
                if (dr["sGender"].ToString().Contains("男") == true)
                {
                    stuInfo.Gender = 0;
                }
                else
                {
                    stuInfo.Gender = 1;
                }
                //学制
                stuInfo.Schooling = dr["sSchooling"].ToString().Trim();
                //学位类别
                if (dr["sDegree"].ToString().Contains("单证") == true)
                {
                    stuInfo.Degree = "单证硕士";
                }
                else
                {
                    stuInfo.Degree = "双证硕士";
                }
                stuInfo.Major = "软件工程";
                stuInfo.Grade = _qInfo.Grade;
                stuInfo.TeaSchoolID = _qInfo.TSchoolID;
                //判断当前账号是否存在，如果存在则不添加这个账号
                if (GetAccountByStuID(stuInfo.StuID) == true)
                { 
                    //该账号存在
                    continue;
                }
                //添加新学生
                _stuInfo = stuInfo;
                AddNewStudent();
            }
            return true;
        }

        /// <summary>
        /// 添加新账号
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <returns></returns>
         public bool AddAccountInfo(StudentInfo stuInfo)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddAccount(stuInfo));
             op.Do();
             if (op.ExecuteResult == true)
             {
                 return true;
             }
             return false;
         }

        /// <summary>
        /// 添加MSE扩展信息
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <param name="tID"></param>
        /// <returns></returns>
         public bool AddStuMSEInfo(StudentInfo stuInfo)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddStuMSEInfo(stuInfo));
             op.Do();
             if (op.ExecuteResult == true)
             {
                 return true;
             }
             return false;
         }

        /// <summary>
        /// 添加学生的基本信息
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <returns></returns>
         public bool AddStuBasicInfo(StudentInfo stuInfo)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddStuBasicInfo(stuInfo));
             op.Do();
             if (op.ExecuteResult == true)
             {
                 return true;
             }
             return false;
         }

        /// <summary>
        /// 添加部门用户
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <returns></returns>
         public bool AddUsers(StudentInfo stuInfo)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddUsers(stuInfo));
             op.Do();
             if (op.ExecuteResult == true)
             {
                 return true;
             }
             return false;
         }

        /// <summary>
        /// 返回年级的数据集
        /// </summary>
        /// <returns></returns>
         public DataSet GetGrade()
         {
             OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetGrade());
             op.Do();
             DataSet ds = op.Ds;
             if (ds.Tables[0].Rows.Count > 0)
             {  
                 DataRow dr = ds.Tables[0].NewRow();
                 dr[0] = "--请选择年级--";
                 ds.Tables[0].Rows.InsertAt(dr, 0);
                 return ds;
             }
             return null;
         }

        /// <summary>
        /// 返回导师选学生的基本信息
        /// </summary>
        /// <returns></returns>
         public DataSet GetChoosingStuInfo(string teacherID)
         {
             OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetChoosingStuTime(teacherID));
             op.Do();
             return op.Ds;
         }

         public DataSet GetChoosedNumByStu(string teacherID)
         {
             OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetChoosedNumByStu(teacherID));
             op.Do();
             return op.Ds;
         }

       

 

         public DataSet GetChoosingTutorByStuID(string stuID)
         {
             OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTutorChoosingByStuId(stuID));
             op.Do();
             return op.Ds;
         }

         public DataSet GetTutorChoosingDetails(string stuid)
         {
             OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTutorChoosingDetails(stuid));
             op.Do();
             return op.Ds;
         }

         public bool AddTutorChoosingInfoByAdm(Willing will)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddTutorChoosingByStu(will));
             op.Do();
             if (op.ExecuteResult == true)
             {
                 return true;
             }
             return false;
         }

         public void UpdateTutorChoosingInfoByAdm(string stuid, string teacherID, string will, int teaWill)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTutorChoosingInfoByAdm(stuid,teacherID, will, teaWill));
             op.Do();
         }

         public void DeleteExistTutorChoosingInfo(string stuid)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteTutorChoosing(stuid));
             op.Do();
         }

         public bool ChangeTutorChoosingInfo()
         {
             DeleteExistTutorChoosingInfo(_will.StuID);
             AddTutorChoosingInfoByAdm(_will);
             return true;
         }

         public bool UpdateTutorChoosingTran(Willing will)
         {
             _will = will;
             OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(ChangeTutorChoosingInfo));
             op.Do();
             if (op.Result == true)
             {
                 return true;
             }
             return false;
         }

         public void UpdateStusTutor(string stuid, string teacherid)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateStuTutorID(stuid, teacherid));
             op.Do(); 
         }

         public void UpdateTutorAgendaStatus(QueryInfo qInfo)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTutorAgendaMagStatus(qInfo));
             op.Do();
         }

         public bool UpdateStusAttachToTutorID()
         {
             foreach (KeyValuePair<string, string> kvp in _stuTea)
             {
                 if (kvp.Value != "NULL")
                 {
                     UpdateStusTutor(kvp.Key, kvp.Value);
                 }
             }
             UpdateTutorAgendaStatus(_qInfo);
             return true;
         }

         public bool UpdateStusTutorTrans(QueryInfo qInfo, Dictionary<string,string> stuTea)
         {
             _qInfo = qInfo;
             _stuTea = stuTea;
             OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(UpdateStusAttachToTutorID));
             op.Do();
             if (op.Result == true)
             {
                 return true;
             }
             return false;
         }

         public bool updateStudentPassword(string studentID, string newPassword)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdatePassword(studentID, newPassword));
             op.Do();
             if (op.ExecuteResult == true)
             {
                 return true;
             }
             return false;
         }

         public bool updateStuRegisterStatus(string studentID)
         {
             OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlupdateStuRegisterStatus(studentID));
             op.Do();
             if (op.ExecuteResult == true)
             {
                 return true;
             }
             return false;
         }

        public bool updateStudentBasicInfo()
        {
            UpdateStudentInfoByStu(_stuInfo);
            UpdateStudentMSEByStu(_stuInfo);
            updateStudentPassword(_stuInfo.StuID, _stuInfo.Password);
            updateStuRegisterStatus(_stuInfo.StuID);
            return true;
        }

        public bool AddBindReviewNoForStu(string studentID, string num)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateBindReviewNoForStu(studentID, num));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #region GetFunctions

        /// <summary>
        /// 判断该账号是否存在
        /// </summary>
        /// <param name="stuID"></param>
        /// <returns></returns>
        public bool GetAccountByStuID(string stuID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAccountByID(stuID));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //该账号存在
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取自定义年级信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetGradeWithOtherForm()
        {
            Dictionary<string, string> gradeList = new Dictionary<string, string>();
            System.DateTime theDate = System.DateTime.Now;
            gradeList.Add("--请选择年级--", "--请选择年级--");
            for (int i = theDate.Year - 4; i < theDate.Year + 2; i++)
            {
                string gradeString = i.ToString() + "级";
                gradeList.Add(gradeString, gradeString);
            }
            return gradeList;
        }

        /// <summary>
        /// 根据学号，返回某个学生的基本信息
        /// </summary>
        /// <param name="studentId">学号</param>
        /// <returns></returns>
        public StudentInfo GetStudentInfo(string studentId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlStudentInfo(studentId));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            StudentInfo stuInfo = new StudentInfo();
            stuInfo.StuID = dr["StudentID"].ToString();
            stuInfo.StuName = dr["Name"].ToString();
            if (dr["Gender"] != System.DBNull.Value)
                stuInfo.Gender = Convert.ToInt32(dr["Gender"]);

            if (dr["NativeProvince"] != System.DBNull.Value)
                stuInfo.NativePro = dr["NativeProvince"].ToString();

            if (dr["Grade"] != System.DBNull.Value)
                stuInfo.Grade = dr["Grade"].ToString();

            if (dr["PoliticalStatus"] != System.DBNull.Value)
                stuInfo.PolStatus = dr["PoliticalStatus"].ToString();

            if (dr["MobilePhone"] != System.DBNull.Value)
                stuInfo.MobPhone = dr["MobilePhone"].ToString();

            if (dr["FixedPhone"] != System.DBNull.Value)
                stuInfo.FixedPhone = dr["FixedPhone"].ToString();

            if (dr["HomeAddress"] != System.DBNull.Value)
                stuInfo.HomeAddress = dr["HomeAddress"].ToString();

            if (dr["Birthday"] != System.DBNull.Value)
                stuInfo.Birthday = Convert.ToString(dr["Birthday"]);

            if (dr["Nation"] != System.DBNull.Value)
                stuInfo.Nation = dr["Nation"].ToString();

            if (dr["IDNumber"] != System.DBNull.Value)
                stuInfo.StuIDNumber = dr["IDNumber"].ToString();

            if (dr["Degree"] != System.DBNull.Value)
                stuInfo.Degree = dr["Degree"].ToString();

            if (dr["Address"] != System.DBNull.Value)
                stuInfo.Address = dr["Address"].ToString();

            if (dr["PostalCode"] != System.DBNull.Value)
                stuInfo.PostalCode = dr["PostalCode"].ToString();

            if (dr["EmailAddress"] != System.DBNull.Value)
                stuInfo.EmailAddress = dr["EmailAddress"].ToString();

            if (dr["MaritalStatus"] != System.DBNull.Value)
                stuInfo.MarStatus = Convert.ToInt32(dr["MaritalStatus"]);

            if (dr["OrigDegree"] != System.DBNull.Value)
                stuInfo.OrigDegree = dr["OrigDegree"].ToString();

            if (dr["Major"] != System.DBNull.Value)
                stuInfo.Major = dr["Major"].ToString();

            if (dr["LengthOfSchooling"] != System.DBNull.Value)
                stuInfo.Schooling = dr["LengthOfSchooling"].ToString();

            if (dr["Company"] != System.DBNull.Value)
                stuInfo.WorkPlace = dr["Company"].ToString();

            if (dr["CompanyAddress"] != System.DBNull.Value)
                stuInfo.WorkPlaceAdd = dr["CompanyAddress"].ToString();

            if (dr["tName"] != System.DBNull.Value)
                stuInfo.TeacherName = dr["tName"].ToString();

            if (dr["TeaSchoolID"] != System.DBNull.Value)
                stuInfo.TeaSchoolID = dr["TeaSchoolID"].ToString();

            if (dr["TeaSchoolName"] != System.DBNull.Value)
                stuInfo.TeaSchoolName = dr["TeaSchoolName"].ToString();

            if (dr["GraduateTime"] != System.DBNull.Value)
                stuInfo.GraduateTime = Convert.ToString(dr["GraduateTime"]);

            return stuInfo;
        }

        /// <summary>
        /// 根据学号，返回学生的照片信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataSet GetStudentPicture(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStudentPicture(studentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该学生所属导师的信息
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public DataSet GetTeacherInfoByStuID(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeacherInfo(stuid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该生所属年级教学点最新预开课课程信息
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public DataSet GetLatestCourseInfoByStuid(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetLatestCourseInfo(stuid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该生的详细信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataSet GetStusInfo(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStudentsInfoByStuID(studentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，通过该生的成绩
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public DataSet GetExamResultByStuID(string stuId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetExamResByStuID(stuId));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号和课程号，返回该生的评教信息
        /// </summary>
        /// <param name="courseid"></param>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public DataSet GetStuEvaluation(int courseid, string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStuEvaluationInfo(courseid, stuid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该生临时所选导师的信息
        /// </summary>
        /// <param name="stuID"></param>
        /// <returns></returns>
        public DataSet GetStuChooseTeacherInfo(string stuID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeacherStudentInfo(stuID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取该生所选导师已被其他多少学生所选
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public int GetStuChooseTeacherNum(string teacherID, string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStuChooseTeacherNum(studentID, teacherID));
            op.Do();
            DataSet ds = op.Ds;
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 获取该生该志愿所选的导师已被其他学生所选的次数
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="studentID"></param>
        /// <param name="will"></param>
        /// <returns></returns>
        public int GetStuChooseTeacherNumByWill(string teacherID, string studentID, string will)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStuChooseTeacherNumByWill(studentID, teacherID, will));
            op.Do();
            DataSet ds = op.Ds;
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 根据学号，判断该生是否提交了答辩申请
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public DataSet GetStuApplyStatus(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStuApplyStatus(stuid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，获取该生答辩申请的条件（即开题报告，中期考核表，校外导师信息，论文初稿是否都已提交）
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public DataSet GetStuDefenceApplyCondition(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStuDefenceCondition(stuid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回该生的论文评审结果
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public DataSet GetPaperJudgeRes(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPaperJudgeRes(stuid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据导师工号及相关条件，返回该导师所带学生
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetStudentsInfoByteaId(string teacherID, QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStudentsByTeaID(teacherID, qInfo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据导师工号，返回该导师所带学生
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetStudentsInfoByteaIdWithNoneQuery(string teacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStudentsByteaIdWithNoneQuery(teacherID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回导师选学生功能中,选该导师的学生基本信息
        /// </summary>
        /// <param name="tMagId">选导师日程编号</param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetTeaChooseStuInfo(int tMagId, string teacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaChooseStuInfo(tMagId, teacherID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回该学生的论文评审结果
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataSet GetPaperJudgeResultByStuID(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPaperJudgeResultByStuID(studentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据查询条件(qInfo)获取相对应的学生信息
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public DataSet GetStusInfo(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStusInfo(qInfo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回所有学生及其相关信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetStusInfoWithNull()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStusInfoWithNull());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 通过学号返回该生所属年级
        /// </summary>
        /// <param name="stuID"></param>
        /// <returns></returns>
        public string GetGradebyStuID(string stuID)
        {
            string grade = null;
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetGradeByStuId(stuID));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                string tmpGrade = ds.Tables[0].Rows[0][0].ToString().Trim();
                grade = tmpGrade.Substring(0, 4);
            }
            return grade;
        }

        /// <summary>
        ///  判断该账号是否已经注册，如果注册返回TRUE，否则返回FALSE
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public static bool IsStudentRegistered(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStudentRegisterStatus(studentID));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //该生已注册
                return true;
            }
            return false;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 添加学生照片
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="path">保存在服务器中的照片的虚拟路径</param>
        /// <param name="imageName">照片的名称（以学号来命名，避免重复）</param>
        /// <returns></returns>
        public bool AddStudentPicture(string studentID, string path, string imageName)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddStudentPicture(studentID, path, imageName));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据学号，为该生添加答辩申请信息
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public bool AddDefenceApplyStatus(string stuid)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddDefenceApplication(stuid));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region updateFunctions

        /// <summary>
        /// 修改学生登陆密码
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool RevisePassword(string studentId, string oldPassword, string newPassword)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetOldPassword(studentId));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count == 0)
            {
                errorMsg = "修改密码失败";
                return false;  //该用户不存在，发生异常
            }
            if (string.Compare(oldPassword, ds.Tables[0].Rows[0]["Password"].ToString()) != 0)
            {
                errorMsg = "原密码不正确";
                return false; //原密码不正确
            }
            OpEngineerExecute ope = new OpEngineerExecute("Engineering", new SqlUpdatePassword(studentId, newPassword));
            ope.Do();
            if (ope.ExecuteResult == false)
            {
                errorMsg = "修改密码失败";
                return false; //更新失败
            }
            return true;
        }

        /// <summary>
        /// 更新学生的基本信息
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <returns></returns>
        public bool UpdateStudentInfoByStu(StudentInfo stuInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateStuInfo(stuInfo));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新学生的照片
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="path">照片在服务器中的虚拟路径</param>
        /// <returns></returns>
        public bool UpdateStudentPicture(string studentID, string path)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateStudentPicture(studentID, path));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新答辩申请信息（管理员是否批准答辩）
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="reasult"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool UpdateDefenceApply(string studentID, int reasult, string reason)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateDefenceApply(studentID, reasult, reason));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新学生的成绩
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="courseid"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool UpdateStudentResult(string stuid, int courseid, string result)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateStudentResult(stuid, courseid, result));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新学生评教信息（即该生是否评教）
        /// </summary>
        /// <param name="courseid"></param>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public bool UpdateStuEvaluation(int courseid, string stuid)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateEvaluationInfo(courseid, stuid));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新答辩申请信息（导师是否批准答辩）
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="status"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool UpdateApplyStatus(string stuid, int status, string reason)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateApplyStatus(stuid, status, reason));
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
        /// 删除学生的答辩申请信息
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public bool DeleteStuDefenceApply(string stuid)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteDefenceApply(stuid));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除学生选导师的相关信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteStudentChooseTutorInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentChooseTutorInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除该生的学费信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStudentTuitionInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentTuitionInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除该生论文评审信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStudentThesisJudgeInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentThesisJudgeInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除该生学籍变动信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStuStatusChangInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStuStatusChangInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///  删除该生所选课程信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStudentExamInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentExamInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除该生答辩申请信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStuDefenceApplyInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStuDefenceApplyInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除该生的谈论信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStudentDisscussion(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentDisscussion(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除该生的附件信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStudentAttachment(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentAttachment(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除该生的扩展信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteStudentMSE(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentMSE(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        public bool DeleteStudentInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteStudentInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除学生账号信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DeleteAccountInfo(string studentID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteAccountInfo(studentID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region TransactionFuncions

        /// <summary>
        /// 通过事务处理更新学生信息和MSE信息
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <returns></returns>
        public bool UpdateStudentInfobyTransaction(StudentInfo stuInfo)
        {
            _stuInfo = stuInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(UpdateStudentInfoIncludeExtension));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 事务处理更新工硕学生的所有基本信息（包括个人信息，联系方式，密码等）
        /// </summary>
        /// <param name="sInfo"></param>
        /// <returns></returns>
        public bool updateStudentBasicInfoByTran(StudentInfo sInfo)
        {
            _stuInfo = sInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(updateStudentBasicInfo));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 事务处理添加学生的基本信息
        /// </summary>
        /// <returns></returns>
        public bool TranStuInfoDatabase(QueryInfo qInfo)
        {
            _qInfo = qInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(ToStuInfoDatabase));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        public bool AddNewStudentByTran(StudentInfo sInfo)
        {
            _stuInfo = sInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddNewStudent));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        public bool UpdateStudentInfoByTran(StudentInfo sInfo)
        {
            _stuInfo = sInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(UpdateStudentInfo));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除所有与该生相关的信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteInformationsRelatedToStudentByTran(string studentID)
        {
            _studentID = studentID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(DeleteInformationsRelatedToStudent));
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
