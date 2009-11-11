using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class TestManage
    {
        #region Constructor

        public TestManage()
        { }

        #endregion

        #region GetFunctions

        /// <summary>
        /// 根据学号，返回该生所选课课程的考试安排信息
        /// </summary>
        /// <param name="stuid"></param>
        /// <returns></returns>
        public DataSet GetExamArrangementByStu(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetExamArrangeByStu(stuid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据教师工号，返回与该教师相关的考试安排信息
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetExamArrangementByTeacher(string teacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetExamArrangeByTea(teacherID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据课程号，返回该课程的考试安排
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public DataSet GetTestArrangement(int courseID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTestArrangeByCourseID(courseID));
            op.Do();
            return op.Ds;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 添加考试安排
        /// </summary>
        /// <param name="tInfo"></param>
        /// <returns></returns>
        public bool AddTestArrangement(TestInfo tInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddExamArrangement(tInfo));
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
        /// 更新考试安排
        /// </summary>
        /// <param name="tInfo"></param>
        public bool UpdateExamArrangement(TestInfo tInfo)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTestArrangement(tInfo));
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
