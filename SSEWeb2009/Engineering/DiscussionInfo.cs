using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using System.Data;

namespace Department.Engineering
{
    public class DiscussionInfo
    {
        #region Member Variables

        private string _title;
        private string _createdDate;
        private string _body;
        private string _displayOrdery;
        private string _communicators;
        private int _category;
        private int _attachID;
        private string _status;

        #endregion

        #region Public Properties

        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        public string CreatedDate
        {
            set { _createdDate = value; }
            get { return _createdDate; }
        }

        public string Body
        {
            set { _body = value; }
            get { return _body; }
        }

        public string DisplayOrdery
        {
            set { _displayOrdery = value; }
            get { return _displayOrdery; }
        }

        public string Communicators
        {
            set { _communicators = value; }
            get { return _communicators;}
        }

        public int Category
        {
            set { _category = value; }
            get { return _category; }
        }

        public int AttachID
        {
            set { _attachID = value; }
            get { return _attachID; }
        }

        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }

        #endregion

        #region GetFunctions

        /// <summary>
        /// 返回最新的评论信息
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public DataSet GetPaperDiscussionLatestTime(int itemID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPaperDiscussionLatestTime(itemID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回该教师所带学生的论文评论信息
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetDiscussionInfoByTeacherID(string teacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetDiscussionInfoByTeacherID(teacherID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据查询条件，返回该教师所带学生的论文评论信息
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="qInfo"></param>
        /// <returns></returns>
        public DataSet GetDiscussionByTeacherIDAndQuery(string teacherID, QueryInfo qInfo)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetDiscussionByTeacherIDAndQuery(teacherID, qInfo));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回相关的评论信息
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public DataSet GetDiscussionByItemID(int itemID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetDiscussionByItemID(itemID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 返回与该教师相关的评论的子评论信息
        /// </summary>
        /// <param name="parentDisplayOrder"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public DataSet GetChildMessageByteacher(string parentDisplayOrder, string teacherID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetChildMessageByTeacherID(parentDisplayOrder, teacherID));
            op.Do();
            return op.Ds;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 添加评论信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="parentDisplayOrder"></param>
        /// <param name="communicators"></param>
        /// <param name="category"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool AddDiscussionInfo()
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddDiscussion(_title, _body, _displayOrdery, _communicators, _category,_attachID, _status));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 返回与该学生相关的留言信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public DataSet GetDiscussionRelatedtoStudent(string studentID, int category)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetDiscussionRelatedtoStudent(studentID, category));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取学生发起的第一条留言
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public DataSet GetFirstDiscussionRelatedtoStudent(string studentID, int category)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetFirstDiscussionRelatedtoStudent(studentID, category));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 添加新的评论信息
        /// </summary>
        /// <returns></returns>
        public bool AddDiscussionByStudent()
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddDiscusstionByStudent(_communicators, _title, _category, _attachID,_body));
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
