using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class CourseManage
    {
        #region SomeVariants

        public DataSet ds = null;
        public QueryInfo qInfo;
        private CourseInfo _cInfo;
        private List<string> _teacher;
        private List<int> _courID;
        private int _courseID;
        private string _studentID;
        private int _agendaID;
        private int _teaMagID;

        #endregion

        #region Constructor

        public CourseManage()
        { }

        #endregion

        #region OtherFunctions

        /// <summary>
        /// 将Dataset中存储的课程信息添加到数据库中
        /// 每次能添加多门课程
        /// </summary>
        /// <returns></returns>
        public bool ToCourseDatabase(DataSet ds, QueryInfo qInfo)
        {
                CourseInfo cInfo = new CourseInfo();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cInfo = GetCourseInfo(dr);
                    //判断该年级该教学点该学期该课程是否已经存在
                    if (GetCourseInfoByCourseInfo(cInfo) == true)
                    {
                        //该课程已存在
                        continue;
                    }
                    AddNewCourse(cInfo);
                }
                return true;
        }

        public bool UpdateNetChooseCourseToNotChooseCourse()
        {
            TeachingAgendaManage taMag = new TeachingAgendaManage();
            for (int i = 0; i < _courID.Count; i++)
            {
                int courseID = _courID[i];
                //为该年级该教学点的所有学生都添加这门课程
                AddCourseIntoStudentCourseTable(qInfo, courseID);
                //将这门课程的状态设置为开设状态
                updateCourseOpened(courseID);
            }
            //删除选课日程信息
            taMag.DeleteTeachingAgendaByTeaMagID(_teaMagID);
            return true;
        }

        public bool AddCourseIntoStudentCourseTable(QueryInfo qInfo, int courseID)
        {
            StudentManage sMag = new StudentManage();
            CourseManage cMag = new CourseManage();
            DataSet dsStu = null;
            dsStu = sMag.GetStusInfo(qInfo);
            int count = dsStu.Tables[0].Rows.Count;
            if (count > 0)
            { 
                for(int i=0; i<count; i++)
                {
                    AddCoursesForStudent(courseID, dsStu.Tables[0].Rows[i]["StudentID"].ToString().Trim());
                }
            }
            //更新选课人数
            cMag.UpdateCourseStudentNum(courseID, count);
            return true;
        }

        public bool AddCourseInfomationAndArrangement()
        {
            ToCourseDatabase(ds, qInfo);
            AddCourseTimeAnge(qInfo);
            return true;
        }

        public bool AddCourseAndUpdateStuNum()
        {
            AddCoursesForStudent(_courseID, _studentID);
            UpdateCourseStudentNum(_courseID);
            return true;
        }

        public bool DeleteCourseForStuAndSubStuNum()
        {
            DelCoursesForStudent(_courseID, _studentID);
            UpdateSubStuNum(_courseID);
            return true;
        }

        
        public bool UpdateCourseTeacher()
        {
            UpdateCourseInfo(_cInfo);
            if (GetCourseTeacherByCourse(_cInfo.CourseID) == true)
            {
                DeleteCourseTeacher(_cInfo.CourseID);
            }
            for (int i = 0; i < _teacher.Count; i++)
            {
                AddCourseTeacher(_teacher[i], _cInfo.CourseID);
            }
            return true;
        }

        public bool DeleteCourseTran()
        {
            DelCoursesForStudent(_courseID);
            DelCoursesRelatedToExamArrange(_courseID);
            DeleteCourseTeacher(_courseID);
            DeleteCourse(_courseID);
            return true;
        }

        public bool updateCourseAgenAndOpened()
        {
            UpdateTeachingAgendaConfirmStatus(_agendaID);
            if (_courID.Count > 0)
            {
                for (int i = 0; i < _courID.Count; i++)
                {
                    updateCourseOpened(_courID[i]);
                }
            }
            return true;
        }



        #endregion

        #region GetFunctions

        /// <summary>
        /// 根据课程号，返回该课程的详细信息
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public CourseInfo GetCourseInfo(int courseID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseInfoByCourseID(courseID));
            op.Do();
            DataSet ds = op.Ds;
            CourseInfo cInfo = new CourseInfo();
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                cInfo.CourseID = courseID;
                cInfo.CourseName = ds.Tables[0].Rows[0]["CourseName"].ToString();
                cInfo.Target = 1;
                if (ds.Tables[0].Rows[0]["CourseTime"] != System.DBNull.Value)
                {
                    cInfo.CourseTime = ds.Tables[0].Rows[0]["CourseTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Diglossia"] != System.DBNull.Value)
                {
                    cInfo.Diglossia = Convert.ToInt32(ds.Tables[0].Rows[0]["Diglossia"]);
                }
                if (ds.Tables[0].Rows[0]["ExternalOrNot"] != System.DBNull.Value)
                {
                    cInfo.ExternalOrNot = Convert.ToInt32(ds.Tables[0].Rows[0]["ExternalOrNot"]);
                }
                if (ds.Tables[0].Rows[0]["TextBook"] != System.DBNull.Value)
                {
                    cInfo.TextBook = ds.Tables[0].Rows[0]["TextBook"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ExamMode"] != System.DBNull.Value)
                {
                    cInfo.ExamMode = ds.Tables[0].Rows[0]["ExamMode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StudentNumber"] != System.DBNull.Value)
                {
                    cInfo.StudentNum = Convert.ToInt32(ds.Tables[0].Rows[0]["StudentNumber"]);
                }
                if (ds.Tables[0].Rows[0]["ForeignTextbook"] != System.DBNull.Value)
                {
                    cInfo.ForeignTextBook = Convert.ToInt32(ds.Tables[0].Rows[0]["ForeignTextbook"]);
                }
                if (ds.Tables[0].Rows[0]["ForeignPPT"] != System.DBNull.Value)
                {
                    cInfo.ForeignPPT = Convert.ToInt32(ds.Tables[0].Rows[0]["ForeignPPT"]);
                }
                if (ds.Tables[0].Rows[0]["LanguageClass"] != System.DBNull.Value)
                {
                    cInfo.LanguageClass = ds.Tables[0].Rows[0]["LanguageClass"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ForeignPercent"] != System.DBNull.Value)
                {
                    cInfo.ForeignPercent = Convert.ToSingle(ds.Tables[0].Rows[0]["ForeignPercent"]);
                }
                if (ds.Tables[0].Rows[0]["Property"] != System.DBNull.Value)
                {
                    cInfo.Property = Convert.ToInt32(ds.Tables[0].Rows[0]["Property"]);
                }
                if (ds.Tables[0].Rows[0]["Category"] != System.DBNull.Value)
                {
                    cInfo.Category = Convert.ToInt32(ds.Tables[0].Rows[0]["Category"]);
                }
                if (ds.Tables[0].Rows[0]["Credit"] != System.DBNull.Value)
                {
                    cInfo.Credit = Convert.ToInt32(ds.Tables[0].Rows[0]["Credit"]);
                }
                if (ds.Tables[0].Rows[0]["CreditHour"] != System.DBNull.Value)
                {
                    cInfo.CreditHour = Convert.ToInt32(ds.Tables[0].Rows[0]["CreditHour"]);
                }
                if (ds.Tables[0].Rows[0]["Place"] != System.DBNull.Value)
                {
                    cInfo.Place = ds.Tables[0].Rows[0]["Place"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassPeriod"] != System.DBNull.Value)
                {
                    cInfo.ClassPeriod = ds.Tables[0].Rows[0]["ClassPeriod"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InstruMode"] != System.DBNull.Value)
                {
                    cInfo.InstruMode = ds.Tables[0].Rows[0]["InstruMode"].ToString();
                }
                if (count == 1)
                {
                    if (ds.Tables[0].Rows[0]["Name"] != System.DBNull.Value)
                    {
                        cInfo.Teacher = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                }
                if (count == 2)
                {
                    cInfo.Teacher = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[1]["Name"].ToString(); ;
                }
                if (ds.Tables[0].Rows[0]["Grade"] != System.DBNull.Value)
                {
                    cInfo.Grade = ds.Tables[0].Rows[0]["Grade"].ToString();
                }
                return cInfo;
            }

            return null;
        }

         /// <summary>
        /// 返回课程信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public CourseInfo GetCourseInfo(DataRow dr)
        {
            CourseInfo cInfo = new CourseInfo();
            cInfo.CourseName = dr["courseName"].ToString().Trim();
            cInfo.Credit = Convert.ToInt32(dr["credit"]);
            cInfo.CreditHour = Convert.ToInt32(dr["creditHour"]);
            if (dr["property"].ToString().Contains("学位") && !dr["property"].ToString().Contains("非"))
            {
                cInfo.Property = 0;
            }
            else if (dr["property"].ToString().Contains("非学位"))
            {
                cInfo.Property = 1;
            }
            else if (dr["property"].ToString().Contains("必修环节"))
            {
                cInfo.Property = 2;
            }
            else
            {
                 //防止出错
                cInfo.Property = 3;
            }
            if (dr["category"].ToString().Contains("必修"))
            {
                cInfo.Category = 0;
            }
            else if (dr["category"].ToString().Contains("选修"))
            {
                cInfo.Category = 1;
            }
            else
            {
                //防止出错
                cInfo.Category = 2;
            }
            cInfo.ExamMode = dr["examMode"].ToString().Trim();
            cInfo.InstruMode = dr["instruMode"].ToString().Trim();
            cInfo.ClassPeriod = dr["classPeriod"].ToString().Trim();
            cInfo.Place = dr["place"].ToString();
            cInfo.Target = 1;
            cInfo.CourseTime = qInfo.Time;
            cInfo.Grade = qInfo.Grade;
            cInfo.TeaSchoolID = qInfo.TSchoolID;
            return cInfo;
        }

        /// <summary>
        /// 根据课程号，返回该课程的信息集 
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public DataSet GetCourseInformation(int courseID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseInfoByCourseID(courseID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，获取学生所选预开课课程信息（这些课程不一定全开，由管理员来决定）
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public DataSet GetChoosingCourseByStudent(string stuId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetChoosingCourseByStudent(stuId));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据课程号，返回教授这门课程的教师信息
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public DataSet GetCourseTeacherInfo(int courseID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseTeacherInfo(courseID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号和课程号，判定该生是否选择与课程号相对应的课程
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentid"></param>
        /// <returns></returns>
        public static bool GetCourseFromExamRes(int courseId, string studentid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseFromExam(courseId, studentid));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据学号和学期，返回该生该学期所选修的课程
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public DataSet GetAllCourseInfo(string stuid, string term)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseInfoByStuAndCourseTime(stuid, term));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该生最新的课程信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataSet GetMyLastestCourse(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetMyCourse(studentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该生各个学期所选课程的开课时间
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public List<string> GetCourseTimeByStuID(string stuId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseTimeBystuId(stuId));
            op.Do();
            DataSet ds = op.Ds;
            List<string> schoolYear = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    schoolYear.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            return schoolYear;
        }

        /// <summary>
        /// 根据查询条件（queryInfo）获得相关课程的信息
        /// </summary>
        /// <param name="qInfo">查询条件集</param>
        /// <returns></returns>
        public DataSet GetCourseInfo(QueryInfo qInfo)
        {
            SqlGetCourseInfo gCourseInfo = new SqlGetCourseInfo(qInfo);
            gCourseInfo.CurOp = SqlGetCourseInfo.CurrentOp.opQuery;
            OpEngineerQuery op = new OpEngineerQuery("Engineering", gCourseInfo);
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据CourseInfo判断相关课程的信息是否存在
        /// </summary>
        /// <param name="cInfo"></param>
        /// <returns></returns>
        public bool GetCourseInfoByCourseInfo(CourseInfo cInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseInfoByCourseInfo(cInfo));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据课程ID，返回选这门课程的人数
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public DataSet GetCourseChoosingNum(int courseID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseChoosingNum(courseID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回该生所选该课程的成绩信息
        /// </summary>
        /// <param name="stuid"></param>
        /// <param name="courseid"></param>
        /// <returns></returns>
        public DataSet GetRecordFromExamResult(string stuid, int courseid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetFromExamResult(stuid, courseid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据学号，返回该生所选修的所有课程信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataSet GetAllMyCourseInfo(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseInfoByStudentID(studentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回该生所属年级教学点的所有在该学期所选修的课程
        /// </summary>
        /// <param name="term"></param>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        public DataSet GetCourseInfo(string term, string StudentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseInfoByTermAndStuID(term, StudentID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 重载函数
        /// 通过StuQueryInfo对象获得相关课程的信息
        /// </summary>
        /// <param name="sQueryInfo"></param>
        /// <returns></returns>
        public DataSet GetCourseInfo(StuQueryInfo sQueryInfo)
        {
            SqlGetCourseInfo gCourseInfo = new SqlGetCourseInfo(sQueryInfo);
            gCourseInfo.CurOp = SqlGetCourseInfo.CurrentOp.opSQuery;
            OpEngineerQuery op = new OpEngineerQuery("Engineering", gCourseInfo);
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 重载函数，获取所有课程的信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCourseInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllCourseInfo());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据查询条件（ queryInfo）,查询年级选课情况
        /// </summary>
        /// <returns></returns>
        public DataSet GetCourseOfGradeInfo(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseOfGradeInfo(qInfo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 重载函数，返回所有年级选课信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCourseOfGradeInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseOfGradeInfoWithNoneParam());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取评教课程信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCourseEvaluationInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseEvaluationInfo());
            op.Do();
            return op.Ds;
        }

        public DataSet GetCourseEvaluationInfo(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseEvaluationInfoWithQuery(qInfo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据查询条件（queryInfo），返回课程成绩信息
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public DataSet GetCourseScoreInfo(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseFromExamByqInfo(qInfo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 重载函数，返回所有已开课程的成绩信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCourseScoreInfo()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseScoreInfoWithNull());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据查询条件，返回该课程已选人数
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public DataView GetCourseNum(QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseNum(qInfo));
            op.Do();
            DataSet ds = op.Ds;
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "num > 0";
            return dv;
        }

        /// <summary>
        /// 返回该门课程的评教人数
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public DataSet GetTeachingFeedBackStuNum(int courseID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeachingFeedBackStuNum(courseID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据课程ID返回选择该课程的相关信息
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public DataSet GetChoosingCourseInfoByCourID(int courseID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetChoosingCourseByCourID(courseID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据选课日程编号，获取相应的课程信息
        /// </summary>
        /// <param name="agendaID"></param>
        /// <returns></returns>
        public DataSet GetAllCourseInfoByAgendaID(int agendaID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseAgendaByID(agendaID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据课程号，返回该门课程的授课教师信息
        /// </summary>
        /// <param name="courseid"></param>
        /// <returns></returns>
        public bool GetCourseTeacherByCourse(int courseid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCourseTeacherByCourseID(courseid));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 管理员为该生添加该门课程
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public bool AddCoursesForStudentByAdmin(int courseId, string stuId)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddCoursesForStudentByAdm(courseId, stuId));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加新课程
        /// 每次只能添加一门课程
        /// </summary>
        /// <param name="cInfo"></param>
        /// <returns>添加成功，返回true</returns>
        public bool AddNewCourse(CourseInfo cInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddCourse(cInfo));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加新课程，并返回新课程的课程号
        /// </summary>
        /// <param name="cInfo"></param>
        /// <returns></returns>
        public int AddNewCourseWithReturnValue(CourseInfo cInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlAddNewCourseWithReturnValue(cInfo));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["num"]);
            }
            return -1;
        }

        /// <summary>
        /// 添加非选课课程的课程信息
        /// </summary>
        /// <returns></returns>
        public bool AddCourseInfomationWithoutNetChoose()
        {
            CourseInfo cInfo = new CourseInfo();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cInfo = GetCourseInfo(dr);
                //判断该年级该教学点该学期该课程是否已经存在
                if (GetCourseInfoByCourseInfo(cInfo) == true)
                { 
                    //该课程已存在
                    continue;
                }
                //添加一门课程并返回相应的课程号
                int courseID = AddNewCourseWithReturnValue(cInfo);
                if (courseID != -1)
                {
                    //为该年级该教学点的所有学生都添加这门课程
                    AddCourseIntoStudentCourseTable(qInfo, courseID);
                    //将这门课程的状态设置为开设状态
                    updateCourseOpened(courseID);
                }
            }
            return true;
        }

        /// <summary>
        /// 添加选课的时间安排
        /// </summary>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public bool AddCourseTimeAnge(QueryInfo qInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddCourTimeAnge(qInfo));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加学生的选课信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public bool AddCoursesForStudent(int courseId, string stuId)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddCourForStud(courseId, stuId));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///为课程添加相应的授课教师
        /// </summary>
        /// <param name="teacherid"></param>
        /// <param name="courseid"></param>
        /// <returns></returns>
        public bool AddCourseTeacher(string teacherid, int courseid)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddCourseTeacher(courseid, teacherid));
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
        /// 更新该课程的选课人数
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool UpdateCourseStudentNum(int courseID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateCourseStudentNum(courseID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  重载函数，更新该课程的选课人数
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool UpdateCourseStudentNum(int courseID, int num)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateCourseStudentNumWithNum(courseID, num));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新该课程的选课人数
        /// </summary>
        /// <param name="courseid"></param>
        /// <returns></returns>
        public bool UpdateSubStuNum(int courseid)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlSubStuNum(courseid));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

       

        /// <summary>
        /// 更新课程信息
        /// </summary>
        /// <param name="cInfo"></param>
        public void UpdateCourseInfo(CourseInfo cInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateCourseInfoByCourseInfo(cInfo));
            op.Do();
        }

        /// <summary>
        /// 更新选课确认信息
        /// </summary>
        /// <param name="agendaID"></param>
        /// <returns></returns>
        public bool UpdateTeachingAgendaConfirmStatus(int agendaID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateAgendaConfirmStatus(agendaID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 跟新该门课程的开设状态（开设OR不开设）
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool updateCourseOpened(int courseID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlupdateCourseOpened(courseID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新成绩状态信息（管理员确认成绩OR管理员尚未确认成绩）
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="studentID"></param>
        public bool updateCourseConfirmStatus(int courseID, string studentID, int status)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateCourseConfirmStatus(courseID, studentID, status));
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
        /// 删除学生所选课程
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public bool DelCoursesForStudent(int courseId, string stuId)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDelCourseForStud(courseId, stuId));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 重载函数，删除学生所选课程中的该课程信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool DelCoursesForStudent(int courseId)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDelCourseForStudByCourseID(courseId));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除与考试安排相关的课程信息
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool DelCoursesRelatedToExamArrange(int courseID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDelCoursesRelatedToExamArrange(courseID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除相关课程信息
        /// </summary>
        /// <param name="courseID">课程编号</param>
        public bool DeleteCourse(int courseID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteCourse(courseID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据课程号，删除该课程的授课教师信息
        /// </summary>
        /// <param name="courseid"></param>
        public bool DeleteCourseTeacher(int courseid)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteCourseTeacherByCourseID(courseid));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region TransationFunctions

        /// <summary>
        /// 添加学生所选课程的事务处理方法
        /// </summary>
        /// <param name="courseid"></param>
        /// <param name="studentid"></param>
        /// <returns></returns>
        public bool AddCoursesForStudentTran(int courseid, string studentid)
        {
            _courseID = courseid;
            _studentID = studentid;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddCourseAndUpdateStuNum));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除学生所选课程的事务处理方法
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool DelCoursesForStudentTran(int courseID, string studentID)
        {
            _courseID = courseID;
            _studentID = studentID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(DeleteCourseForStuAndSubStuNum));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过事务处理添加非网上选课的课程信息
        /// </summary>
        /// <returns></returns>
        public bool AddCourseInfoWithoutNetChoosingByTran(DataSet tmpDs, QueryInfo queryInfo)
        {
            ds = tmpDs;
            qInfo = queryInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddCourseInfomationWithoutNetChoose));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过事务处理添加需要进行网上选课的课程信息
        /// </summary>
        /// <param name="tmpDs"></param>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        public bool AddCourseInformationByTran(DataSet tmpDs, QueryInfo queryInfo)
        {
            ds = tmpDs;
            qInfo = queryInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddCourseInfomationAndArrangement));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过事务处理删除与该课程号相对应的课程信息
        /// </summary>
        /// <param name="courseid"></param>
        /// <returns></returns>
        public bool TransactionDeleteAllCourses(int courseid)
        {
            _courseID = courseid;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(DeleteCourseTran));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过事务处理更新选课确认信息
        /// </summary>
        /// <param name="agendar"></param>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool updateCourseAgenAndOpenedTran(int agendar, List<int> courseID)
        {
            _agendaID = agendar;
            _courID = courseID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(updateCourseAgenAndOpened));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过事务处理更新教师及其授课课程信息
        /// </summary>
        /// <param name="cInfo"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public bool UpdateCourseTeacherTran(CourseInfo cInfo, List<string> teacher)
        {
            _cInfo = cInfo;
            _teacher = teacher;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(UpdateCourseTeacher));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 将需要网上选课的课程改为非网上选课的课程
        /// </summary>
        /// <returns></returns>
        public bool UpdateNetChooseCourseToNotChooseCourseByTran(QueryInfo queryInfo, List<int> courseID, int teaMagID)
        {
            _courID = courseID;
            qInfo = queryInfo;
            _teaMagID = teaMagID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(UpdateNetChooseCourseToNotChooseCourse));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        ///// <summary>
        ///// 添加新课程（每次只添加一门课程）
        ///// </summary>
        ///// <param name="tmpDs"></param>
        ///// <param name="queryInfo"></param>
        ///// <returns></returns>
        //public bool AddOneNewCourseEachTime(CourseInfo cInfo, List<string> teacher)
        //{
        //    _cInfo = cInfo;
        //    _teacher = teacher;
        //    OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction());
        //    op.Do();
        //    if (op.Result == true)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        #endregion
    }
}
