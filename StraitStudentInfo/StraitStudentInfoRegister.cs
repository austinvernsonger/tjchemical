using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;

namespace StraitStudentInfo
{
    public class StraitStudentInfoRegister : IGetAuthList
    {
        public virtual System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {
            TreeView TeacherAuth = new TreeView();
            TreeNode TeacherRoot = new TreeNode("困难生管理", "困难生管理");
            TeacherAuth.Nodes.Add(TeacherRoot);
            TeacherRoot.ChildNodes.Add(new TreeNode("困难生登记", "困难生登记", "", "~/StraitStudentInfo/admin/StraitStudentInfoLogin.aspx",""));
            TeacherRoot.ChildNodes.Add(new TreeNode("助学金管理", "助学金管理", "", "~/StraitStudentInfo/admin/StipendManage.aspx", ""));
            TeacherRoot.ChildNodes.Add(new TreeNode("特困补助管理", "特困补助管理", "", "~/StraitStudentInfo/admin/SubsidyManage.aspx", ""));
            TeacherRoot.ChildNodes.Add(new TreeNode("勤工助学管理", "勤工助学管理", "", "~/StraitStudentInfo/admin/WorkForStudyManage.aspx", ""));
            TeacherRoot.ChildNodes.Add(new TreeNode("国家助学贷款管理", "国家助学贷款管理", "", "~/StraitStudentInfo/admin/LoanManage.aspx", ""));
            return TeacherAuth;
        }

        public virtual System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            TreeView StudentAuth = new TreeView();
            if (true)
            {
                TreeNode StudentRoot = new TreeNode("困难生管理", "困难生管理");
                StudentAuth.Nodes.Add(StudentRoot);
                StudentRoot.ChildNodes.Add(new TreeNode("助学金申请", "助学金申请", "", "~/StraitStudentInfo/student/StipendApply.aspx", ""));
                StudentRoot.ChildNodes.Add(new TreeNode("特困补助申请", "特困补助申请", "", "~/StraitStudentInfo/student/SubsidyApply.aspx", ""));
                StudentRoot.ChildNodes.Add(new TreeNode("勤工助学申请", "勤工助学申请", "", "~/StraitStudentInfo/student/WorkForStudyApply.aspx", ""));
                StudentRoot.ChildNodes.Add(new TreeNode("国家助学贷款申请", "国家助学贷款申请", "", "~/StraitStudentInfo/student/LoanApply.aspx", ""));
            }
            return StudentAuth;
        }

        public virtual Boolean SetAsAdmin(String ID)
        {
            return true;
        }
    }
}
