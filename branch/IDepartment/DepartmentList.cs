using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Department.Interface
{
    /// <summary>
    /// Department List.
    /// @Modify: Push-2009.5.22
    /// </summary>
    /// revised on 8-12 22:20 by Recruitement Department 
    /// Increase an ID for Recruitment 
    public enum DepartmentListEnum
    {
        Global = 0,
        StudentManage = 1,
        StudentFile = 2,
        MaxCount = 3,  // Increase this when register new department.

        // Revised On 8/22      
        Recruitment = 8
    }

    /// <summary>
    /// Provide registration of all departments.
    /// @Author: Push
    /// </summary>
    public class DepartmentList
    {
        /// <summary>
        /// Register the department.
        /// </summary>
        /// <param name="DepartmentName">The name of the department.</param>
        /// <param name="DelegateInterface">The interface to get the authorization.</param>
        static public void Register(String DepartmentName, Interface.IGetAuthList DelegateInterface)
        {
            for (Int32 i = 0; i < gDepartments.Count; ++i)
                if (gDepartments[i].Key.Equals(DepartmentName)) return;
            gDepartments.Add(new KeyValuePair<String, IGetAuthList>(DepartmentName, DelegateInterface));
        }

        /// <summary>
        /// The department pool.
        /// </summary>
        static private List<KeyValuePair<String, IGetAuthList>> gDepartments =
            new List<KeyValuePair<String, IGetAuthList>>();

        /// <summary>
        /// Readonly paramenter of the department list.
        /// </summary>
        static public List<KeyValuePair<String, IGetAuthList>> Departments
        { get { return gDepartments; } }

        /*
         * No need in the new version.
         * Change to GenerateNavigation.
        /// <summary>
        /// Create a tree view via the string id.
        /// </summary>
        /// <param name="Container"></param>
        /// <param name="ID"></param>
        static public void GenerateTreeView(ref System.Web.UI.Control Container, String ID)
        {
            for (int i = 0; i < gDepartments.Count; ++i)
            {
                // Check if the Account is Teacher or Student
                DataStructure.Tree<AuthItem> tmpDp = gDepartments[i].GetTeacherAuthorityList(ID);
                if (tmpDp != null)
                {
                    TreeView tmpTree = new TreeView();
                    TreeNode root = new TreeNode(tmpDp.CurrentNode.AuthString);
                    tmpTree.Nodes.Add(root);
                    generate(tmpDp, ref root);
                    Container.Controls.Add(tmpTree);
                }
            }
        }
        */

        /// <summary>
        /// Generate the navigation of the current user's authoriztion.
        /// On null continue.
        /// </summary>
        /// <param name="Container">The container to add the navigation to.</param>
        /// <param name="ID">The User's ID.</param>
        /// <param name="SubTitleCssClass">The title's CssClass.</param>
        /// <param name="TreeCssClass">The tree's CssClass.</param>
        static public void GenerateNavigation(ref System.Web.UI.WebControls.Panel Container, String ID,
            String SubTitleCssClass, String TreeCssClass, String TargetWindow)
        {
            Boolean isStudent = false;  // Shoude be change to get the correct state.

            
            for (int i = 0; i < gDepartments.Count; ++i)
            {
                TreeView tmpTree = (isStudent) ?
                    gDepartments[i].Value.GetStudentAuthorityList(ID) :
                    gDepartments[i].Value.GetTeacherAuthorityList(ID);
                // No Authorization for current user.
                if (tmpTree == null || tmpTree.Nodes.Count == 0) continue;

                tmpTree.Target = TargetWindow;
                tmpTree.CssClass = TreeCssClass;

                tmpTree.ExpandDepth = 1;

                //                 Label lbDpName = new Label();
                //                 lbDpName.Text = gDepartments[i].Key;
                //                lbDpName.CssClass = SubTitleCssClass;

                // Add to the container.
                //                 HtmlGenericControl divTitle = new HtmlGenericControl("div");
                //                 divTitle.Controls.Add(lbDpName);
                HtmlGenericControl divTree = new HtmlGenericControl("div");
                divTree.Controls.Add(tmpTree);

                //                Container.Controls.Add(divTitle);
                Container.Controls.Add(divTree);
            }
            if (isStudent)
            {
                AndStudentAction(ref Container, ID, SubTitleCssClass, TreeCssClass, TargetWindow);
            }
            else
            {
                AndTeacherAction(ref Container, ID, SubTitleCssClass, TreeCssClass, TargetWindow);
            }
        }
       
       
//         static private void generate(DataStructure.Tree<AuthItem> SubTree, ref TreeNode TheRoot)
//         {
//             DataStructure.Tree<AuthItem> tmpTree = SubTree.GetNextSubTree();
//             while (tmpTree != null)
//             {
//                 TreeNode tmpNode = new TreeNode(tmpTree.CurrentNode.AuthString, 
//                     null, null, tmpTree.CurrentNode.AuthUrl, "sysContainer");
//                 TheRoot.ChildNodes.Add(tmpNode);
//                 generate(tmpTree, ref tmpNode);
//                 tmpTree = SubTree.GetNextSubTree(tmpTree);
//             }
//         }
      static private void AndPublicAction(ref System.Web.UI.WebControls.Panel Container, String ID,
            String SubTitleCssClass, String TreeCssClass, String TargetWindow)
        {

        }
        static private void AndTeacherAction(ref System.Web.UI.WebControls.Panel Container, String ID,
            String SubTitleCssClass, String TreeCssClass, String TargetWindow)
        {
            TreeView TeacherActionTree = new TreeView();
            TeacherActionTree.Target = TargetWindow;
            TeacherActionTree.CssClass = TreeCssClass;

            TeacherActionTree.ExpandDepth = 1;


            // Add to the container.
            //             HtmlGenericControl divTitle = new HtmlGenericControl("div");
            //             divTitle.Controls.Add(lbDpName);
            HtmlGenericControl divTree = new HtmlGenericControl("div");
            divTree.Controls.Add(TeacherActionTree);

            //            Container.Controls.Add(divTitle);
            Container.Controls.Add(divTree);

        }

        

        static private void AndStudentAction(ref System.Web.UI.WebControls.Panel Container, String ID,
            String SubTitleCssClass, String TreeCssClass, String TargetWindow)
        {

        }
    }
}
