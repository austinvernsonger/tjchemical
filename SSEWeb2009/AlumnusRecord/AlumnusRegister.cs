using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;


namespace AlumnusRecord
{
    public class AlumnusRegister : IGetAuthList
    {
        public System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID)
        {

            bool isAdmin = true;
            if (isAdmin == true)
            {
                TreeView adminTree = new TreeView();

                TreeNode subNode = new TreeNode("院友之家管理", "院友之家管理", "", "~/AlumnusRecord/Admin/Default.aspx", "");
                adminTree.Nodes.Add(subNode);
               
                return adminTree;
            }
            else
            {
                return null;
            }


        }

        public System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID)
        {
            bool isMSE = false;
            if (isMSE == true)
            {
                  return null;
            }
            return null;

          
        }

        public Boolean SetAsAdmin(String ID)
        {
            return false;
        }
    }
}

