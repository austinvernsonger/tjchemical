using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department;
using LabCenter.LabUtility.SuperUtility;

namespace LabCenter.Authority
{
    public class MngRegister : Department.Interface.IGetAuthList
    {
        public System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {

            return GetAuthorityList(ID);
        }

        public System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            return GetAuthorityList(ID);
        }

        public Boolean SetAsAdmin(String ID)
        {
            return SuperCtrl.AddSuper(ID);
        }

        public TreeView GetAuthorityList(String id)
        {
            TreeView AuthList = new TreeView();
            TreeNode SubRoot = null;

            AuthorityManage am = new AuthorityManage();
            if (am.IsSuper(id) || am.HasAuthority(id, 1, 1))
            {
                //介绍
                TreeNode IntroRoot = new TreeNode("介绍", "介绍");
                IntroRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("编辑介绍", "编辑介绍", "", "~/LabCenter/Introduction/Back/EditIntroduction.aspx", "");
                IntroRoot.ChildNodes.Add(SubRoot);

                AuthList.Nodes.Add(IntroRoot);
            }

            //新闻
            if (am.IsSuper(id) || am.HasAuthority(id, 2, 1) || am.HasAuthority(id, 2, 2))
            {
                TreeNode NewsRoot = new TreeNode("新闻", "新闻");
                NewsRoot.SelectAction = TreeNodeSelectAction.Expand;
                if (am.IsSuper(id) || am.HasAuthority(id, 2, 1))
                {
                    SubRoot = new TreeNode("添加新闻", "添加新闻", "", "~/LabCenter/News/Back/Add.aspx", "");
                    NewsRoot.ChildNodes.Add(SubRoot);
                }
                if (am.IsSuper(id) || am.HasAuthority(id, 2, 2))
                {
                    SubRoot = new TreeNode("编辑新闻", "编辑新闻", "", "~/LabCenter/News/Back/Editlist.aspx", "");
                    NewsRoot.ChildNodes.Add(SubRoot);                    
                }
                AuthList.Nodes.Add(NewsRoot);
            }

            //通知
            if (am.IsSuper(id) || am.HasAuthority(id, 2, 1) || am.HasAuthority(id, 2, 2))
            {
                TreeNode NewsRoot = new TreeNode("通知", "通知");
                NewsRoot.SelectAction = TreeNodeSelectAction.Expand;
                if (am.IsSuper(id) || am.HasAuthority(id, 2, 1))
                {
                    SubRoot = new TreeNode("添加通知", "添加通知", "", "~/LabCenter/Notice/Back/Add.aspx", "");
                    NewsRoot.ChildNodes.Add(SubRoot);
                }
                if (am.IsSuper(id) || am.HasAuthority(id, 2, 2))
                {
                    SubRoot = new TreeNode("编辑通知", "编辑通知", "", "~/LabCenter/Notice/Back/Editlist.aspx", "");
                    NewsRoot.ChildNodes.Add(SubRoot);
                }
                AuthList.Nodes.Add(NewsRoot);
            }

            if (am.IsSuper(id) || am.HasAuthority(id, 9, 1))
            {
                //报修管理
                TreeNode RepairRoot = new TreeNode("报修管理", "报修管理");
                RepairRoot.SelectAction = TreeNodeSelectAction.Expand;


                SubRoot = new TreeNode("未处理", "未处理");
                SubRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot.ChildNodes.Add(new TreeNode("机房电脑", "机房电脑", "", "~/LabCenter/Repair/Unhandled/ComputerList.aspx", ""));
                SubRoot.ChildNodes.Add(new TreeNode("其它设备", "其它设备", "", "~/LabCenter/Repair/Unhandled/OtherList.aspx", ""));
                RepairRoot.ChildNodes.Add(SubRoot);

                SubRoot = new TreeNode("记录", "记录");
                SubRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot.ChildNodes.Add(new TreeNode("机房电脑", "机房电脑", "", "~/LabCenter/Repair/Record/Computer.aspx", ""));
                SubRoot.ChildNodes.Add(new TreeNode("其它设备", "其它设备", "", "~/LabCenter/Repair/Record/Other.aspx", ""));
                RepairRoot.ChildNodes.Add(SubRoot);

                SubRoot = new TreeNode("统计", "统计");
                SubRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot.ChildNodes.Add(new TreeNode("机房电脑", "机房电脑", "", "~/LabCenter/Repair/Statistics/Computer.aspx", ""));
                RepairRoot.ChildNodes.Add(SubRoot);

                AuthList.Nodes.Add(RepairRoot);
            }

            if (am.IsSuper(id) || am.HasAuthority(id, 7, 1) || am.HasAuthority(id, 7, 2))
            {
                //设备管理
                TreeNode EquipRoot = new TreeNode("设备管理", "设备管理");
                EquipRoot.SelectAction = TreeNodeSelectAction.Expand;

                 if (am.IsSuper(id) || am.HasAuthority(id, 7, 1))
                 {
                     SubRoot = new TreeNode("设备信息管理", "设备信息管理", "", "~/LabCenter/Equipment/DeviceInfo.aspx", "");
                     EquipRoot.ChildNodes.Add(SubRoot);

                     SubRoot = new TreeNode("耗材信息管理", "耗材信息管理", "", "~/LabCenter/Equipment/MaterialInfo.aspx", "");
                     EquipRoot.ChildNodes.Add(SubRoot);

                     SubRoot = new TreeNode("添加可借用设备", "添加可借用设备", "", "~/LabCenter/Equipment/DeviceApply/NewOpenDevice.aspx", "");
                     EquipRoot.ChildNodes.Add(SubRoot);

                     SubRoot = new TreeNode("查看可借用设备", "查看可借用设备", "", "~/LabCenter/Equipment/OpenDeviceList.aspx", "");
                     EquipRoot.ChildNodes.Add(SubRoot);
                 }

                 if (am.IsSuper(id) || am.HasAuthority(id, 7, 2))
                 {
                     SubRoot = new TreeNode("设备借用查看", "设备借用查看", "", "~/LabCenter/Equipment/DeviceApplyTable.aspx", "");
                     EquipRoot.ChildNodes.Add(SubRoot);

                     SubRoot = new TreeNode("耗材领用查看", "耗材领用查看", "", "~/LabCenter/Equipment/MaterialApplyTable.aspx", "");
                     EquipRoot.ChildNodes.Add(SubRoot);
                 }
                AuthList.Nodes.Add(EquipRoot);
            }

            if (am.IsSuper(id) || am.HasAuthority(id, 8, 1))
            {

                //预约管理
                TreeNode ReservationRoot = new TreeNode("预约管理", "预约管理");
                /*RepairRoot.SelectAction = TreeNodeSelectAction.Expand;

                SubRoot = new TreeNode("配置", "配置");
                SubRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot.ChildNodes.Add(new TreeNode("默认时间表", "默认时间表", "", "~/LabCenter/Reservation/Back/EditDefaulTime.aspx", ""));
                SubRoot.ChildNodes.Add(new TreeNode("安排实验", "安排实验", "", "~/LabCenter/Reservation/Back/ArrangeExperiment.aspx", ""));
                ReservationRoot.ChildNodes.Add(SubRoot);

                SubRoot = new TreeNode("统计", "统计");
                SubRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot.ChildNodes.Add(new TreeNode("实验情况", "实验情况", "", "~/LabCenter/Reservation/Back/CheckTotalInfo.aspx", ""));
                ReservationRoot.ChildNodes.Add(SubRoot);*/

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("修改基本配置信息", "修改基本配置信息", "", "~/LabCenter/Reservation/Back/Initialize.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("添加修改实验", "添加修改实验", "", "~/LabCenter/Reservation/Back/AddorEditExperiment.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("配置默认时间段", "配置默认时间段", "", "~/LabCenter/Reservation/Back/EditDefaultTime.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("安排实验", "安排实验", "", "~/LabCenter/Reservation/Back/ArrangeExperiment.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("查看正在实验人数", "查看正在实验人数", "", "~/LabCenter/Reservation/Back/CurrentStu.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("不良记录", "不良记录", "", "~/LabCenter/Reservation/Back/BadRecord.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("实验报告管理", "实验报告管理", "", "~/LabCenter/Reservation/Back/UpdateReport.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);

                ReservationRoot.SelectAction = TreeNodeSelectAction.Expand;
                SubRoot = new TreeNode("查看统计信息", "查看统计信息", "", "~/LabCenter/Reservation/Back/CheckTotalInfo.aspx", "");
                ReservationRoot.ChildNodes.Add(SubRoot);


                AuthList.Nodes.Add(ReservationRoot);
            }
            if (am.IsSuper(id))
            {
                //权限管理
                TreeNode AuthorityRoot = new TreeNode("权限管理", "权限管理", "", "~/LabCenter/Authority/Back/SearchManager.aspx", "");
                AuthList.Nodes.Add(AuthorityRoot);
            }
            return AuthList;
        }
    }
}
