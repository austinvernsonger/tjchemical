using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class DocumentManage
    {
        private string _studentID;
        private string _ktPath;
        private string _otPath;
        private string _url;
        private DiscussionInfo _dInfo;

        public DocumentManage()
        { }

        public DataSet GetAttachmentByAttachID(int attachID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAttachmentByAttachID(attachID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据用户的ID返回开题报告结果集
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetOpenSpeechByUserID(string userId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetOpenSpeechByUserId(userId));
            op.Do();
            return op.Ds;
        }
   
        /// <summary>
        /// 添加新开题报告,并返回ID
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="userId"></param>
        /// <param name="url"></param>
        public int AddNewOpenSpeech(string userId, string url, string fileName)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlAddAttachmentbyOS(userId, url, fileName));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// 更新开题报告
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="contentSize"></param>
        /// <param name="lmDateTime"></param>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool updateOpenSpeechByUserID(string userID, string url,string fileName)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateOpeningSpeech(userID, url, fileName));
            op.Do();
            if (true == op.ExecuteResult)
            {
                return true;
            }
            return false;
        }

        public bool updateOpenSpeechByAttachID(int attachID, string url, string fileName)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateOpenSpeechByAttachID(attachID,url,fileName));
            op.Do();
            if (true == op.ExecuteResult)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据用户的ID返回中期考核表结果集
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetMidFormByUserID(string userId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetMidFormByStuID(userId));
            op.Do();
            return op.Ds;
        }
        /// <summary>
        /// 根据用户ID和附件类型返回附件信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public DataSet GetAttachment(string userID, int category)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAttachment(userID, category));
            op.Do();
            return op.Ds;
        }

        public DataSet GetOutTeacherByUserID(string userid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetOutTeacherByUserID(userid));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 添加新的中期考核表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="url"></param>
        public int  AddNewMidFormByStu(string userId, string url, string subject)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlAddMidForm(userId, url, subject));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            else
            {
                return -1;
            }
        }

        public int AddNewOutTeacher(string userId, string url, string filename)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlAddNewOutTeacher(userId, url, filename));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 更新中期考核表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool updateMidFormByStu(int attachID, string url,string subject)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateMidForm(attachID, url,subject));
            op.Do();
            if (true == op.ExecuteResult)
            {
                return true;
            }
            return false;
        }

        public bool updateOutTeacher(int attachID, string url, string subject)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateOutTeacher(attachID,url,subject));
            op.Do();
            if (true == op.ExecuteResult)
            {
                return true;
            }
            return false;
        }

        public bool updateOutTeacherByuserID(string userID, string url, string fileName)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlupdateOutTeacherByuserID(userID,url, fileName));
            op.Do();
            if (true == op.ExecuteResult)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 返回论文初稿的结果集
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetPaperByUserID(string userId)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPaperByStuId(userId));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 添加论文初稿
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="userId"></param>
        /// <param name="url"></param>
        public int AddNewPaperByStu(string fileName, string userId, string url)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlAddPaper(fileName, userId, url));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 更新论文初稿
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool updatePaper(int attachID, string url, string fileName)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdatePaper(attachID, url, fileName));
            op.Do();
            if (true == op.ExecuteResult)
            {
                return true;
            }
            return false;
        }

        public DataSet GetStuFinalPaper(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetFinalPaperByStuID(stuid));
            op.Do();
            return op.Ds;
        }

        public bool AddStuFinalPaper(string stuid, int length, string contentType, byte[] content, string filename)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddDocumentInfoDatabase(stuid, length, contentType, content, filename));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        public DataSet GetSqlPrejudicationStatus()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPrejudicationStatus());
            op.Do();
            return op.Ds;
        }

        public DataSet GetPrejudicationStatusByStuid(string stuid)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetPrejudicationStatusByStuid(stuid));
            op.Do();
            return op.Ds;
        }

        public DataSet GetStudentPicture(int attachmentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStudentPictureByAttachId(attachmentID));
            op.Do();
            return op.Ds;
        }
 
        public DataSet GetDiscussionByStudentID(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetDiscussionByStudentID(studentID));
            op.Do();
            return op.Ds;
        }
        
        
        public DataSet GetChildMessage(string parentDisplayOrder, string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetChildMessage(parentDisplayOrder,studentID));
            op.Do();
            return op.Ds;
        }
       
        public void UpdateTeacherClickStatus(int itemID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTeacherClickStatus(itemID));
            op.Do();
        }
        
        public bool AddStudentPic(string studentID, byte[] fileStream)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddStudentPic(studentID,fileStream));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        public DataSet GetStudentPic(string studentID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetStudentPic(studentID));
            op.Do();
            return op.Ds;
        }
        public bool updateOpenSpeechAndOutTeacher()
        {
            updateOpenSpeechByUserID(_studentID, _ktPath,"");
            updateOutTeacherByuserID(_studentID, _otPath,"");
            return true;
        }
        public bool UpdateFinalPaperAttachment(string studentID, string url)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateFinalPaperAttachment(studentID, url));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        public bool updateOpenSpeechAndOutTeacherByTran(string studentID,string newKTPath,string newOTPath)
        {
            _studentID = studentID;
            _ktPath = newKTPath;
            _otPath = newOTPath;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(updateOpenSpeechAndOutTeacher));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }
        public bool AddOpenSpeechAndOutTeacher()
        {
            _dInfo.AttachID = AddNewOpenSpeech(_studentID, _ktPath,"");
            AddNewOutTeacher(_studentID, _otPath,"");
            _dInfo.AddDiscussionByStudent();
            return true;
        }
        public bool AddOpenSpeechRelatedToTran()
        {
            _dInfo.AttachID = AddNewOpenSpeech(_studentID, _url, _dInfo.Title);
            _dInfo.AddDiscussionByStudent();
            return true;
        }
        public bool AddMidSpeechRelatedToTran()
        {
            _dInfo.AttachID = AddNewMidFormByStu(_studentID, _url, _dInfo.Title);
            _dInfo.AddDiscussionByStudent();
            return true;
        }
        public bool AddOutTeacherRelatedToTran()
        {
            _dInfo.AttachID = AddNewOutTeacher(_studentID, _url, _dInfo.Title);
            _dInfo.AddDiscussionByStudent();
            return true;
        }
        public bool AddPaperRelatedToTran()
        {
            _dInfo.AttachID = AddNewPaperByStu(_dInfo.Title, _studentID, _url);
            _dInfo.AddDiscussionByStudent();
            return true;
        }
        public bool AddOpenSpeechAndOutTeacherByTran(string studentID, string newKTPath, string newOTPath,DiscussionInfo dInfo)
        {
            _studentID = studentID;
            _ktPath = newKTPath;
            _otPath = newOTPath;
            _dInfo = dInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddOpenSpeechAndOutTeacher));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 保存开题报告和相关评论信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="path"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public bool AddOpeningSpeechByTran(string studentID, string path, DiscussionInfo dInfo)
        {
            _studentID = studentID;
            _url = path;
            _dInfo = dInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddOpenSpeechRelatedToTran));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 保存中期考核表和相关评论信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="path"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public bool AddMidSpeechByTran(string studentID, string path, DiscussionInfo dInfo)
        {
            _studentID = studentID;
            _url = path;
            _dInfo = dInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddMidSpeechRelatedToTran));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 保存校外导师信息和相关评论信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="path"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public bool AddOutTeacherByTran(string studentID, string path, DiscussionInfo dInfo)
        {
            _studentID = studentID;
            _url = path;
            _dInfo = dInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddOutTeacherRelatedToTran));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 保存初稿和相关评论信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="path"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public bool AddPaperByTran(string studentID, string path, DiscussionInfo dInfo)
        {
            _studentID = studentID;
            _url = path;
            _dInfo = dInfo;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddPaperRelatedToTran));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        public bool AddFinalPaperByStu(string studentID, string path, string title)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddFinalPaperByStu(studentID,path,title));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
        public bool UpdateFinalPaperAndAttachment()
        {
            StudentManage sMag = new StudentManage();
            sMag.UpdateDefenceApply(_studentID, 0, "");
            UpdateFinalPaperAttachment(_studentID, _url);
            return true;
        }
        public bool UpdateFinalPaperAndAttachmentByTran(string studentID, string url)
        {
            _studentID = studentID;
            _url = url;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(UpdateFinalPaperAndAttachment));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }
    }
}
