using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;
using Department.Engineering;
using System.Data;

namespace Department.Engineering
{
    public class EngineerLogRegister : IGetAuthList 
    {
        public TreeView GetTeacherAuthorityList(String ID)
        {
            return GetAuthorityList(ID);
        }

        public TreeView GetStudentAuthorityList(string ID)
        {
            return GetAuthorityList(ID);
        }

        public TreeView GetAuthorityList(string accountID)
        {
            string ID = accountID.Trim();
            RoleManage rMag = new RoleManage();
            //判断当前账号是否属于MSE
            DataSet ds = rMag.GetUsersFromMSE(ID);
            if (ds.Tables[0].Rows.Count == 0)
            { 
                //当前账号不属于MSE
                return null;
            }
            //是MSE成员
            TreeView AuthorityTree = new TreeView();
            TreeNode subNode = null;

            #region 以下是管理员相关权限
            if (AuthorityManage.HasAuthorities(ID, "1-9") == true)
            {
                subNode = new TreeNode("消息信息管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                subNode.ChildNodes.Add(new TreeNode("消息中心", "消息中心", "", "~/Engineering/AdminBakMag/MessageCenter.aspx", ""));
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "1-10") == true)
            {
                subNode = new TreeNode("教学点管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                subNode.ChildNodes.Add(new TreeNode("教学点信息管理", "教学点信息管理", "", "~/Engineering/AdminBakMag/TeachingSchoolManagement.aspx", ""));
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "1-11") == true
                || AuthorityManage.HasAuthorities(ID, "1-12") == true
                || AuthorityManage.HasAuthorities(ID, "1-10") == true)
            {
                subNode = new TreeNode("学生管理", "学生管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "1-11") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("学生信息管理", "学生信息管理", "", "~/Engineering/AdminBakMag/StudentsManagement.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-12") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("学费信息管理", "学费信息管理", "", "~/Engineering/AdminBakMag/TutionInfoManage.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-13") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("学籍信息管理", "学籍信息管理", "", "~/Engineering/AdminBakMag/ApplyInfoManagement.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "1-14") == true || AuthorityManage.HasAuthorities(ID, "1-15") == true
                || AuthorityManage.HasAuthorities(ID, "1-16") == true || AuthorityManage.HasAuthorities(ID, "1-17") == true
                || AuthorityManage.HasAuthorities(ID, "1-18") == true)
            {
                subNode = new TreeNode("课程管理", "课程管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "1-14") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("管理课程信息", "管理课程信息", "", "~/Engineering/AdminBakMag/CoursesManagement.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-15") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("管理选课信息", "管理选课信息", "", "~/Engineering/AdminBakMag/CourseViewManagement.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-16") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("管理考试安排", "管理考试安排", "", "~/Engineering/AdminBakMag/ExamArrageManagement.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-17") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("管理课程成绩", "管理课程成绩", "", "~/Engineering/AdminBakMag/ScoreViewManagement.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-18") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("管理教学评测信息", "管理教学评测信息", "", "~/Engineering/AdminBakMag/TeachingEvaluationManagement.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "1-19") == true
                || AuthorityManage.HasAuthorities(ID, "1-20") == true)
            {
                subNode = new TreeNode("选导师管理", "选导师管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "1-19") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("管理导师选择日程", "管理导师选择日程", "", "~/Engineering/AdminBakMag/TutorAgendaManagement.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-20") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("管理导师分配信息", "管理导师分配信息", "", "~/Engineering/AdminBakMag/TutorResultManagement.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "1-21") == true
                || AuthorityManage.HasAuthorities(ID, "1-22") == true)
            {
                subNode = new TreeNode("论文信息管理", "论文信息管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "1-21") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("分配预审论文", "分配预审论文", "", "~/Engineering/AdminBakMag/AssignPaperForStus.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-22") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("查看论文评审结果", "查看论文评审结果", "", "~/Engineering/AdminBakMag/ViewPaperJudgeResult.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "1-25") == true || AuthorityManage.HasAuthorities(ID, "1-26") == true
                || AuthorityManage.HasAuthorities(ID, "1-27") == true || AuthorityManage.HasAuthorities(ID, "1-28") == true
                || AuthorityManage.HasAuthorities(ID, "1-29") == true || AuthorityManage.HasAuthorities(ID, "1-30") == true
                || AuthorityManage.HasAuthorities(ID, "1-31") == true || AuthorityManage.HasAuthorities(ID, "1-32") == true
                || AuthorityManage.HasAuthorities(ID, "1-33") == true || AuthorityManage.HasAuthorities(ID, "1-34") == true
                || AuthorityManage.HasAuthorities(ID, "1-35") == true)
            {
                subNode = new TreeNode("富文本信息管理", "富文本信息管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "1-25") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("硕士通知管理", "硕士通知管理", "", "~/Engineering/FrontEndPageMag/NoticeMag.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-26") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("硕士新闻管理", "硕士新闻管理", "", "~/Engineering/FrontEndPageMag/NewsMag.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-27") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("中心介绍管理", "中心介绍管理", "", "~/Engineering/FrontEndPageMag/AboutMSEPost.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-28") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("招生简章管理", "招生简章管理", "", "~/Engineering/FrontEndPageMag/EnrollRegulationMag.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-29") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("招生流程管理", "招生流程管理", "", "~/Engineering/FrontEndPageMag/EnrollProcessPost.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-30") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("常见问题", "常见问题", "", "~/Engineering/FrontEndPageMag/EnrollFAQPost.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-31") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("历年成果展示", "历年成果展示", "", "~/Engineering/FrontEndPageMag/EnrollHistoryPost.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-32") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("培养计划管理", "培养计划管理", "", "~/Engineering/FrontEndPageMag/EducationPlanPost.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-33") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("教学培养流程", "教学培养流程", "", "~/Engineering/FrontEndPageMag/DegreeProcessPost.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-34") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("申请答辩流程管理", "申请答辩流程管理", "", "~/Engineering/FrontEndPageMag/DegreeApplicationPost.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-35") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("答辩材料要求管理", "答辩材料要求管理", "", "~/Engineering/FrontEndPageMag/DegreeDatumPost.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "1-23") == true
                || AuthorityManage.HasAuthorities(ID, "1-24") == true)
            {
                subNode = new TreeNode("用户权限管理", "用户权限管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "1-23") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("角色权限管理", "角色权限管理", "", "~/Engineering/AdminBakMag/RoleManagement.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "1-24") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("用户角色管理", "用户角色管理", "", "~/Engineering/AdminBakMag/UserRoleManagement.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            #endregion

            #region 以下是教师，导师相关权限
            if (AuthorityManage.HasAuthorities(ID, "2-2") == true || AuthorityManage.HasAuthorities(ID, "2-3") == true)
            {
                subNode = new TreeNode("学生信息", "学生信息");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "2-2") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("我的学生", "我的学生", "", "~/Engineering/TeacherBackMag/MyStudents.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "2-3") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("学生意向选择", "学生意向选择", "", "~/Engineering/TeacherBackMag/ChooseMyStudents.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "2-5") == true || AuthorityManage.HasAuthorities(ID, "2-6") == true)
            {
                subNode = new TreeNode("课程与考试信息", "课程与考试信息");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "2-5") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("我的课程安排", "我的课程安排", "", "~/Engineering/TeacherBackMag/MyCourse.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "2-6") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("我的考试安排", "我的考试安排", "", "~/Engineering/TeacherBackMag/MyTestArrange.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "2-8") == true || AuthorityManage.HasAuthorities(ID, "2-9") == true
                || AuthorityManage.HasAuthorities(ID, "2-10") == true)
            {
                subNode = new TreeNode("我学生的论文", "我学生的论文");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "2-8") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("学生论文互动", "学生论文互动", "", "~/Engineering/TeacherBackMag/AboutPaperSubmitingRecorder.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "2-9") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("学生答辩申请", "学生答辩申请", "", "~/Engineering/TeacherBackMag/MyStudDefenceApply.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "2-10") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("论文评审结果", "论文评审结果", "", "~/Engineering/TeacherBackMag/ViewPaperFeedBack.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "2-12") == true)
            {
                subNode = new TreeNode("评审学生论文", "评审学生论文");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                subNode.ChildNodes.Add(new TreeNode("待评审的论文", "待评审的论文", "", "~/Engineering/TeacherBackMag/ViewAllPaper.aspx", ""));
                AuthorityTree.Nodes.Add(subNode);
            }
            #endregion

            #region 以下学生相关权限
            if (AuthorityManage.HasAuthorities(ID, "4-1") == true)
            {
                //有注册个人信息的权限
                if (StudentManage.IsStudentRegistered(ID) == false)
                {
                    // 第一次登陆系统，需要注册个人信息
                    subNode = new TreeNode("注册个人信息", "注册个人信息", "", "~/Engineering/StuBackMag/Registration.aspx", "");
                    AuthorityTree.Nodes.Add(subNode);
                    return AuthorityTree;
                }
            }
            if (AuthorityManage.HasAuthorities(ID, "4-3") == true || AuthorityManage.HasAuthorities(ID, "4-4") == true)
            {
                subNode = new TreeNode("个人信息管理", "个人信息管理");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "4-3") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("我的个人信息", "我的个人信息", "", "~/Engineering/StuBackMag/MyInformation.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "4-4") == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("更新个人信息", "更新个人信息", "", "~/Engineering/StuBackMag/ModifyMyInformation.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-5") == true )
            {
                subNode = new TreeNode("我的学费信息", "我的学费信息", "", "~/Engineering/StuBackMag/TuitionInfo.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-6") == true)
            {
                subNode = new TreeNode("我的学籍信息", "我的学籍信息", "", "~/Engineering/StuBackMag/MyApplyForStuChange.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-7") == true)
            {
                subNode = new TreeNode("所有导师信息", "所有导师信息", "", "~/Engineering/StuBackMag/ViewAllTutorsInfo.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-8") == true)
            {
                subNode = new TreeNode("我的导师", "我的导师", "", "~/Engineering/StuBackMag/MyTutorInformation.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-9") == true)
            {
                subNode = new TreeNode("开课课程查询", "开课课程查询", "", "~/Engineering/StuBackMag/ViewClasses.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-10") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
            {
                if (TeachingAgendaManage.GetCourTimeArrangedByStuID(ID).Tables[0].Rows.Count > 0)
                {
                    //在网上选课的日程内
                    subNode = new TreeNode("网上选课", "网上选课", "", "~/Engineering/StuBackMag/ChooseMyCourse.aspx", "");
                    AuthorityTree.Nodes.Add(subNode);
                }
            }
            if (AuthorityManage.HasAuthorities(ID, "4-11") == true)
            {
                subNode = new TreeNode("我的课表", "我的课表", "", "~/Engineering/StuBackMag/ViewMyCourses.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-12") == true)
            {
                subNode = new TreeNode("我的考试信息", "我的考试信息", "", "~/Engineering/StuBackMag/MyTestArragement.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-13") == true)
            {
                subNode = new TreeNode("我的成绩查询", "我的成绩查询", "", "~/Engineering/StuBackMag/MyScoreInfo.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-14") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
            {
                if (TeachingAgendaManage.GetEvaluationAgendaByStuID(ID) == true)
                {
                    // 在教学评估日程内
                    subNode = new TreeNode("教学评估", "教学评估", "", "~/Engineering/StuBackMag/EvaluateTeaching.aspx", "");
                    AuthorityTree.Nodes.Add(subNode);
                }
            }
            if (AuthorityManage.HasAuthorities(ID, "4-15") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
            {
                if (TeachingAgendaManage.GetTeaChooseTimeByStu(ID) == true)
                {
                    //在选导师日程内
                    subNode = new TreeNode("网上选导师", "网上选导师", "", "~/Engineering/StuBackMag/ChooseMyTutor.aspx", "");
                    AuthorityTree.Nodes.Add(subNode);
                }
            }
            if (AuthorityManage.HasAuthorities(ID, "4-16") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
            {
                subNode = new TreeNode("我的开题报告", "我的开题报告", "", "~/Engineering/StuBackMag/MyOpenSpeech.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-22") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
            {
                subNode = new TreeNode("我的校外导师", "我的校外导师", "", "~/Engineering/StuBackMag/MyOutTeacher.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-17") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
            {
                subNode = new TreeNode("我的中期考核", "我的中期考核", "", "~/Engineering/StuBackMag/MyMiddleForm.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-18") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
            {
                subNode = new TreeNode("我的论文初稿", "我的论文初稿", "", "~/Engineering/StuBackMag/MyPaper.aspx", "");
                AuthorityTree.Nodes.Add(subNode);
            }
            if (AuthorityManage.HasAuthorities(ID, "4-20") == true || AuthorityManage.HasAuthorities(ID, "4-21") == true)
            {
                subNode = new TreeNode("我的论文评审", "我的论文评审");
                subNode.SelectAction = TreeNodeSelectAction.Expand;
                if (AuthorityManage.HasAuthorities(ID, "4-20") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("申请论文答辩", "申请论文答辩", "", "~/Engineering/StuBackMag/MyDefenseApplicant.aspx", ""));
                }
                if (AuthorityManage.HasAuthorities(ID, "4-21") == true && StatusChgAppMgr.GetStudentsApplyStatus(ID) == true)
                {
                    subNode.ChildNodes.Add(new TreeNode("查询评审结果", "查询评审结果", "", "~/Engineering/StuBackMag/ViewMyPaperRes.aspx", ""));
                }
                AuthorityTree.Nodes.Add(subNode);
            }
            #endregion

            AuthorityTree.CollapseAll();
            return AuthorityTree;
        }

        public Boolean SetAsAdmin(String ID)
        {
            //设置部门超级管理员（由实验中心负责）
            string accountID = ID.Trim();
            RoleManage rMag = new RoleManage();
            if (rMag.AddSuperAdminForMSEByTran(accountID) == true)
            {
                //添加成功
                return true;
            }
            return false;
        }

    }
}

