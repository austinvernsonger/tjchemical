using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;

namespace News
{
    public class NoticeRegister : IGetAuthList
    {
        public virtual System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {
            TreeView TeacherAuth = new TreeView();
            TreeNode TeacherRoot = new TreeNode("通知管理", "通知管理");
            TeacherRoot.SelectAction = TreeNodeSelectAction.Expand;
            TeacherAuth.Nodes.Add(TeacherRoot);
            TeacherRoot.ChildNodes.Add(new TreeNode("发布通知", "发布通知", "", "~/Notice/Admin/PublishNotice.aspx", ""));
            TeacherRoot.ChildNodes.Add(new TreeNode("通知列表", "通知列表", "", "~/Notice/Admin/NoticeList.aspx", ""));
            return TeacherAuth;
        }

        public virtual System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            TreeView StudentAuth = new TreeView();
            TreeNode StudentRoot = new TreeNode("通知", "通知");
            StudentRoot.SelectAction = TreeNodeSelectAction.Expand;
            StudentAuth.Nodes.Add(StudentRoot);
            StudentRoot.ChildNodes.Add(new TreeNode("查看通知", "查看通知", "", "~/Notice/Student/NoticeShow.aspx", ""));
            return StudentAuth;
        }

        public virtual Boolean SetAsAdmin(String ID)
        {
            return true;
        }
    }
}
