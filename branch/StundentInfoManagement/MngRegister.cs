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
             TreeNode TeacherRoot = new TreeNode("学生信息", "学生信息");
             TeacherRoot.SelectAction = TreeNodeSelectAction.Expand;
             TeacherAuth.Nodes.Add(TeacherRoot);
             TeacherRoot.ChildNodes.Add(new TreeNode("学生信息查询", "学生信息查询", "", "~/StudentInfo/Admin/StudentInfoQuery.aspx", ""));
             TeacherRoot.ChildNodes.Add(new TreeNode("系所管理", "系所管理", "", "~/StudentInfo/Admin/DepartmentManage.aspx", ""));
             TeacherRoot.ChildNodes.Add(new TreeNode("单位管理", "单位管理", "", "~/StudentInfo/Admin/WorkingPlaceManage.aspx", ""));
             TeacherRoot.ChildNodes.Add(new TreeNode("学生账号管理", "学生账号管理", "", "~/StudentInfo/Admin/AddStudent.aspx", ""));
             TeacherRoot.ChildNodes.Add(new TreeNode("困难生管理", "困难生管理", "", "~/StraitStudentInfo/StraitStudentInfoManage.aspx", ""));
             TeacherRoot.ChildNodes.Add(new TreeNode("奖惩管理", "奖惩管理", "", "~/Punishment/PunishmentMng.aspx", ""));
            return TeacherAuth;
        }

        public virtual System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            TreeView StudentAuth = new TreeView();
            TreeNode StudentRoot = new TreeNode("学工办", "学工办");
            StudentRoot.SelectAction = TreeNodeSelectAction.Expand;
             StudentAuth.Nodes.Add(StudentRoot);
             StudentRoot.ChildNodes.Add(new TreeNode("个人信息维护", "个人信息维护", "", "~/StudentInfo/Student/StudentBasicInfo.aspx", ""));
            // StudentRoot.ChildNodes.Add(new TreeNode("申请学习奖学金", "申请学习奖学金", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));
             //StudentRoot.ChildNodes.Add(new TreeNode("申请校外奖学金", "申请校外奖学金", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));
             //StudentRoot.ChildNodes.Add(new TreeNode("申请助学金", "申请助学金", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));
             //StudentRoot.ChildNodes.Add(new TreeNode("评优报名", "评优报名", "", "~/StudentManage/StudentApplyStudyAward.aspx", ""));*/
            return StudentAuth;
        }

        public virtual Boolean SetAsAdmin(String ID)
        {
            return true;
        }
    }
}
