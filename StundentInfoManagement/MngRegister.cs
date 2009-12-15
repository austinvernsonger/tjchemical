using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;

namespace StundentInfoManagement
{
    public class MngRegister : IGetAuthList
    {
        public virtual System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {
             TreeView TeacherAuth = new TreeView();
             /*TreeNode TeacherRoot = new TreeNode("学工办", "学工办");
             TeacherAuth.Nodes.Add(TeacherRoot);
             TeacherRoot.ChildNodes.Add(new TreeNode("通知发布", "通知发布", "", "~/StudentManage/Admin/AddInfo.aspx", ""));*/
            return TeacherAuth;
        }

        public virtual System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            TreeView StudentAuth = new TreeView();
            /* TreeNode StudentRoot = new TreeNode("学工办", "学工办");
             StudentAuth.Nodes.Add(StudentRoot);
             StudentRoot.ChildNodes.Add(new TreeNode("个人信息维护", "个人信息维护", "", "~/StudentManage/Student/InfoSetting.aspx", ""));
             StudentRoot.ChildNodes.Add(new TreeNode("申请学习奖学金", "申请学习奖学金", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));
             StudentRoot.ChildNodes.Add(new TreeNode("申请校外奖学金", "申请校外奖学金", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));
             StudentRoot.ChildNodes.Add(new TreeNode("申请助学金", "申请助学金", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));
             StudentRoot.ChildNodes.Add(new TreeNode("评优报名", "评优报名", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));*/
            return StudentAuth;
        }

        public virtual Boolean SetAsAdmin(String ID)
        {
            return true;
        }
    }
}
