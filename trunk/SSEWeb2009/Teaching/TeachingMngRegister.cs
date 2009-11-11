using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Teaching.Ops;
using Department.Interface;

namespace Teaching
{
    public class TeachingMngRegister : IGetAuthList
    {
        public virtual System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {
            
            
            opsTeachingQuery QueryName = new opsTeachingQuery("select * from TeacherAdministrator where TeacherID = '" +ID+"'");
            QueryName.Do();
            bool isAdmin = false;
            if (QueryName.mResult.Tables.Count != 0 && QueryName.mResult.Tables[0].Rows.Count != 0) isAdmin = true;
            bool isOrdinaryTeacher = false;
            QueryName = new opsTeachingQuery("select * from TeacherOrdinary where TeacherID = '" +ID+"'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count != 0 && QueryName.mResult.Tables[0].Rows.Count != 0) isOrdinaryTeacher = true;
            
            bool isExternalTeacher = false;
            QueryName = new opsTeachingQuery("select * from TeacherExternal where TeacherID = '" +ID+"'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count != 0 && QueryName.mResult.Tables[0].Rows.Count != 0) isExternalTeacher = true;

            bool isSuperAdmin = false;
            QueryName = new opsTeachingQuery("select * from TeacherAdministrator where TeacherID = '" + ID + "' and IfSuperAdmin = 1");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count != 0 && QueryName.mResult.Tables[0].Rows.Count != 0) isSuperAdmin = true;

            TreeView TeacherAuth = new TreeView();
            TreeNode SubRoot = null;

            TreeNode TeacherRoot = new TreeNode("教师个人账户管理", "教师个人账户管理");
            TeacherRoot.SelectAction = TreeNodeSelectAction.Expand;

            String TeacherInfoUrl = "";
            if(isAdmin && (isOrdinaryTeacher || isExternalTeacher)){
                TeacherInfoUrl = "~/Teaching/BackEnd/TeacherAdmin.aspx";
            }else if(isAdmin && !isExternalTeacher && !isOrdinaryTeacher){
                TeacherInfoUrl = "~/Teaching/BackEnd/OrdinaryAdmin.aspx";
            }else if(!isAdmin && !isExternalTeacher && isOrdinaryTeacher){
                TeacherInfoUrl = "~/Teaching/BackEnd/OrdinaryTeacher.aspx";
            }else if(!isAdmin && isExternalTeacher && !isOrdinaryTeacher){
                TeacherInfoUrl = "~/Teaching/BackEnd/ExternalTeacher.aspx";
            }
            TeacherRoot.ChildNodes.Add(new TreeNode("个人信息", "个人信息", "", TeacherInfoUrl, ""));

            SubRoot = new TreeNode("出差事务管理", "出差事务管理");
            SubRoot.SelectAction = TreeNodeSelectAction.Expand;
            SubRoot.ChildNodes.Add(new TreeNode("出差申请", "出差申请", "", "~/Teaching/BackEnd/TravelApplication.aspx", ""));
            SubRoot.ChildNodes.Add(new TreeNode("申请记录", "申请记录", "", "~/Teaching/BackEnd/TravelApplicationList.aspx", ""));
            TeacherRoot.ChildNodes.Add(SubRoot);

            SubRoot = new TreeNode("开课管理", "开课管理");
            SubRoot.SelectAction = TreeNodeSelectAction.Expand;
            SubRoot.ChildNodes.Add(new TreeNode("开课申请", "开课申请", "", "~/Teaching/BackEnd/NewCourseApplication.aspx", ""));
            SubRoot.ChildNodes.Add(new TreeNode("申请记录", "申请记录", "", "~/Teaching/BackEnd/NewCourseApplicationList.aspx", ""));
            //SubRoot.ChildNodes.Add(new TreeNode("教学大纲", "教学大纲"));
            TeacherRoot.ChildNodes.Add(SubRoot);

            SubRoot = new TreeNode("讲座管理", "讲座管理");
            SubRoot.SelectAction = TreeNodeSelectAction.Expand;
            SubRoot.ChildNodes.Add(new TreeNode("讲座申请", "讲座申请", "", "~/Teaching/BackEnd/LectureApplication.aspx", ""));
            SubRoot.ChildNodes.Add(new TreeNode("申请记录", "申请记录", "", "~/Teaching/BackEnd/LectureApplicationList.aspx", ""));
            TeacherRoot.ChildNodes.Add(SubRoot);

            //TeacherRoot.ChildNodes.Add(new TreeNode("个人总结", "个人总结"));
            //TeacherRoot.ChildNodes.Add(new TreeNode("考核详细信息", "考核详细信息"));



            TreeNode AdminRoot = new TreeNode("教学部管理", "教学部管理");
            AdminRoot.SelectAction = TreeNodeSelectAction.Expand;

            //SubRoot = new TreeNode("课程管理","课程管理");
            //SubRoot.SelectAction = TreeNodeSelectAction.Expand;
            //SubRoot.ChildNodes.Add(new TreeNode("查询课程信息","查询课程信息"));
            //SubRoot.ChildNodes.Add(new TreeNode("统计信息", "统计信息"));
            //SubRoot.ChildNodes.Add(new TreeNode("精品课程介绍", "精品课程介绍"));
            //AdminRoot.ChildNodes.Add(SubRoot);

            SubRoot = new TreeNode("教学后台管理", "教学后台管理");
            SubRoot.SelectAction = TreeNodeSelectAction.Expand;
            if (isSuperAdmin)
            {
                SubRoot.ChildNodes.Add(new TreeNode("教学管理员设置", "教学管理员设置", "", "~/Teaching/Admin/TeacherAdministratorMng.aspx", ""));
            }
            SubRoot.ChildNodes.Add(new TreeNode("教学条例管理", "教学条例管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=4", ""));
            SubRoot.ChildNodes.Add(new TreeNode("学生培养方案管理", "学生培养方案管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=5", ""));
            SubRoot.ChildNodes.Add(new TreeNode("企业合作介绍管理", "企业合作介绍管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=6", ""));
                TreeNode SubbRoot = new TreeNode("教学工作委员会管理", "教学工作委员会管理");
                SubbRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubbRoot.ChildNodes.Add(new TreeNode("委员会章程", "委员会章程", "", "~/Teaching/Admin/TeachingCommitteeMng.aspx?ID=0", ""));
                SubbRoot.ChildNodes.Add(new TreeNode("委员会组成", "委员会组成", "", "~/Teaching/Admin/TeachingCommitteeMng.aspx?ID=1", ""));
                SubbRoot.ChildNodes.Add(new TreeNode("会议记录管理", "会议记录管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=7", ""));
                SubRoot.ChildNodes.Add(SubbRoot);
            SubRoot.ChildNodes.Add(new TreeNode("下载专区管理", "下载专区管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=8", ""));
            SubRoot.ChildNodes.Add(new TreeNode("教学教改研究管理", "教学教改研究管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=9", ""));
            SubRoot.ChildNodes.Add(new TreeNode("部门公告管理", "部门公告管理", "", "~/Teaching/Admin/BulletinManage.aspx", ""));
            SubRoot.ChildNodes.Add(new TreeNode("部门新闻管理", "部门新闻管理", "", "~/Teaching/Admin/NewsManagement.aspx", ""));
            SubRoot.ChildNodes.Add(new TreeNode("课程查询", "课程查询", "", "~/Teaching/Admin/QueryCourseInfo.aspx", ""));
            SubRoot.ChildNodes.Add(new TreeNode("精品课程查询", "精品课程查询", "", "~/Teaching/Admin/ElaborateCourse.aspx", ""));
            AdminRoot.ChildNodes.Add(SubRoot);

            SubRoot = new TreeNode("事务管理", "事务管理");
            SubRoot.SelectAction = TreeNodeSelectAction.Expand;
            SubRoot.ChildNodes.Add(new TreeNode("出差管理", "出差管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=1", ""));
            SubRoot.ChildNodes.Add(new TreeNode("讲座管理", "讲座管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=2", ""));
            SubRoot.ChildNodes.Add(new TreeNode("开课管理", "开课管理", "", "~/Teaching/Admin/AdminManagement.aspx?Type=3", ""));
            AdminRoot.ChildNodes.Add(SubRoot);

            //SubRoot = new TreeNode("教师管理", "教师管理");
            //SubRoot.SelectAction = TreeNodeSelectAction.Expand;
            //SubRoot.ChildNodes.Add(new TreeNode("教师个人总结记录", "教师个人总结记录"));
            //SubRoot.ChildNodes.Add(new TreeNode("教师考核详细信息记录", "教师考核详细信息记录"));
            //AdminRoot.ChildNodes.Add(SubRoot);

            //AdminRoot.ChildNodes.Add(new TreeNode("学生信息查询", "学生信息查询"));
            //AdminRoot.ChildNodes.Add(new TreeNode("国际合作查询", "国际合作查询"));



            if (isAdmin && (isOrdinaryTeacher || isExternalTeacher))
            {
                TeacherAuth.Nodes.Add(TeacherRoot);
                TeacherAuth.Nodes.Add(AdminRoot);
            }
            else if (!isAdmin && (isOrdinaryTeacher || isExternalTeacher))
            {
                //foreach (TreeNode tn in TeacherRoot.ChildNodes)
                //{
                //    TeacherAuth.Nodes.Add(tn.);
                //}
                TeacherRoot.SelectAction = TreeNodeSelectAction.None;
                TeacherAuth.Nodes.Add(TeacherRoot);
            }
            else if (isAdmin && !(isOrdinaryTeacher || isExternalTeacher))
            {
                //foreach (TreeNode tn in AdminRoot.ChildNodes)
                //{
                //    TeacherAuth.Nodes.Add(tn);
               //}
                AdminRoot.SelectAction = TreeNodeSelectAction.None;
                TeacherAuth.Nodes.Add(AdminRoot);
            }

            return TeacherAuth;
        }

        public virtual System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            return null;
        }
        public virtual Boolean SetAsAdmin(String ID)
        {
            opsTeachingSetAsAdmin op = new opsTeachingSetAsAdmin(ID);
            op.Do();
            return op.isSucc;
        }
    }
}
