using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;


namespace Application
{
    public class ApplicationRegister : IGetAuthList
    {
        public virtual System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {
            TreeView TeacherAuth = new TreeView();
            TreeNode TeacherRoot = new TreeNode("学生申请管理", "学生申请管理");
            TeacherAuth.Nodes.Add(TeacherRoot);
            //TeacherRoot.ChildNodes.Add(new TreeNode("修改密码", "修改密码", "", "~/Login/ChangePassword.aspx", ""));

            return TeacherAuth;
        }

        public virtual System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            TreeView StudentAuth = new TreeView();
            TreeNode StudentRoot = new TreeNode("申请", "申请");
            StudentAuth.Nodes.Add(StudentRoot);
            //StudentRoot.ChildNodes.Add(new TreeNode("修改密码", "修改密码", "", "~/Login/ChangePassword.aspx", ""));

            return StudentAuth;
        }

        public virtual Boolean SetAsAdmin(String ID)
        {
            return true;
        }
    }
}
