using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseInfo:ISql
    {
        private QueryInfo qInfo;
        private StuQueryInfo sQueryInfo;
        private CurrentOp curop;
        private int courseID;
        private string studentID;

        /// <summary>
        /// 当前正在执行的操作
        /// opQuery表示当前执行参数为queryInfo这个构造函数，opSQuery表示当前执行参数
        /// 为squeryInfo这个构造函数
        /// </summary>
        public enum CurrentOp { opQuery, opSQuery, sId, cId }

        public CurrentOp CurOp
        {
            set { curop = value; }
            get { return curop; }
        }

        #region 构造函数重载

        public SqlGetCourseInfo(QueryInfo queryInfo)
        {
            qInfo = queryInfo;
        }

        public SqlGetCourseInfo(StuQueryInfo squeryInfo)
        {
            sQueryInfo = squeryInfo;
        }

        public SqlGetCourseInfo(int courseid)
        {
            courseID = courseid;
        }

        public SqlGetCourseInfo(string stuId)
        {
            studentID = stuId;
        }

        #endregion

        #region ISql 成员

        public string GetSql()
        {
            string sql = "";
            switch (curop)
            {
                case CurrentOp.opQuery:
                    sql = "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID=ts.TeaSchoolID where 1=1 ";
                    if (qInfo.Grade != null)
                    {
                        sql = sql + " and Grade ='" + qInfo.Grade + "'";
                    }
                    if (qInfo.TSchoolID != null)
                    {
                        sql = sql + " and c.TeaSchoolID='"+qInfo.TSchoolID+"'";
                    }
                    if (qInfo.Time != null)
                    {
                        sql = sql + " and CourseTime='"+Convert.ToInt32(qInfo.Time)+"'";
                    }
                    break;
                case CurrentOp.opSQuery:
                    sql = "select distinct c.* from Course as c inner join Student as s on c.grade = s.grade " +
                            "inner join StudentMSE as se on c.TeaSchoolID=se.TeaSchoolID where s.StudentID ='" + sQueryInfo.AccountID + "'"+
                            "and c.CourseTime = (select max(CourseTime) from Course)";
                    if (sQueryInfo.CourseProperty != -1)
                    {
                        sql = sql + " and c.Property='" + sQueryInfo.CourseProperty + "'";
                    }
                    if (sQueryInfo.CourseCategory != -1)
                    {
                        sql = sql + " and c.Category='" + sQueryInfo.CourseCategory + "'";
                    }
                    if (sQueryInfo.CourseName != null)
                    {
                        sql = sql + " and c.CourseName='" + sQueryInfo.CourseCategory + "'";
                    }
                    break;
                case CurrentOp.cId:
                    sql = "select * from Course as c inner join TeachingSchoolInfo as ts on c.TeaSchoolID = ts.TeaSchoolID left join Teacher_Course as tc on tc.CourseID=c.CourseID left join Teacher as t on t.TeacherID=tc.TeacherID where c.CourseID='" + courseID + "'";
                    break;
                case CurrentOp.sId:
                    sql = "select * from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID where e.StuID = '" + studentID + "' and c.CourseTime = (select max(CourseTime) from Course)";
                    break;
            }
            return sql;

        }

        #endregion
    }
}
