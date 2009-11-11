using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using Department.Interface;

namespace Admission
{
    public class AdmissionRegister : IGetAuthList
    {
        public TreeView GetTeacherAuthorityList(String ID)
        {
            TreeView TVTeacher = new TreeView();
            TreeNode TNTeacher = new TreeNode("招生管理", "招生管理");
            TNTeacher.ChildNodes.Add(new TreeNode("招生主页管理", "招生主页管理", "", "~/Recruitment/AdminHome.aspx", ""));
            TNTeacher.ChildNodes.Add(new TreeNode("招生页面管理", "招生页面管理", "", "~/Recruiment/AdminRecruitment.aspx", ""));
            TVTeacher.Nodes.Add(TNTeacher);
            return TVTeacher;
        }

        public TreeView GetStudentAuthorityList(String ID)
        {
            return null;
        }

        public Boolean SetAsAdmin(String ID)
        {
            return false;
        }
    }
}