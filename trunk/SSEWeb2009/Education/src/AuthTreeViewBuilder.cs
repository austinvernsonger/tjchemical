using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
namespace Education.src
{
    /// <summary>
    /// 根据登陆用户，生成对应的权限树
    /// 作者：李接业
    /// last_modify_time:2009-7-30.
    /// </summary>
    class AuthTreeViewBuilder
    {
        private bool AddAcountManagement(TreeView treeView)
        {
            return true;
        }
        private bool AddAssistantManagement(TreeView treeView)
        {
            return true;
        }
        private bool GetAdminAuthTree(ref TreeView authTree)
        {

            return true;
        }
        public TreeView GetAuthTreeView(EducationDbOpe.myAuthorityset authType)
        {
          
//             administrator = 1,
//             teacher ,
//             master,
//             teacherassistant ,
//             graduating ,
//             groupleader ,
//             groupmember ,
//             undergraduate ,
//             visitor
            TreeView treeView = new TreeView();
            switch (authType)
            {
                case EducationDbOpe.myAuthorityset.administrator:
                    break;
                case EducationDbOpe.myAuthorityset.teacher:
                    break;
                case EducationDbOpe.myAuthorityset.teacherassistant:
                    break;
                case EducationDbOpe.myAuthorityset.groupleader:
                    break;
                case EducationDbOpe.myAuthorityset.master:
                    break;
                case EducationDbOpe.myAuthorityset.undergraduate:
                    break;
                case EducationDbOpe.myAuthorityset.groupmember:
                    break;
                case EducationDbOpe.myAuthorityset.visitor:
                    break;
            }
            return treeView;
        }
    }
}
