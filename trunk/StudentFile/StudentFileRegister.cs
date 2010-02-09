using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;

namespace StudentFile
{
    public class StudentFileRegister : IGetAuthList
    {
        public virtual System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {
            TreeView TeacherAuth = new TreeView();
            TreeNode TeacherRoot = new TreeNode("学生档案", "学生档案");
            TeacherAuth.Nodes.Add(TeacherRoot);
            TeacherRoot.ChildNodes.Add(new TreeNode("学生档案管理", "学生档案管理", "", "~/StudentFile/StudentFileMng.aspx", ""));
            
            return TeacherAuth;
        }

        public virtual System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            TreeView StudentAuth = new TreeView();
            return StudentAuth;
        }

        public virtual Boolean SetAsAdmin(String ID)
        {
            return true;
        }
    }
}
