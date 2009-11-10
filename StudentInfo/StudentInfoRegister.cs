using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;

namespace StudentInfo
{
    public class StudentInfoRegister : IGetAuthList
    {
       


        #region IGetAuthList Members

        public TreeView GetTeacherAuthorityList(string ID)
        {
            throw new NotImplementedException();
        }

        public bool SetAsAdmin(string ID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IGetAuthList Members


        public TreeView GetStudentAuthorityList(string ID)
        {
            TreeView StudentAuth = new TreeView();
            TreeNode SubRoot = null;
            TreeNode StudentNode = new TreeNode("学生", "学生");
            StudentNode.SelectAction = TreeNodeSelectAction.Expand;
            String StudentUrl = "";
            StudentNode.ChildNodes.Add(new TreeNode("个人信息", "个人信息", "", StudentUrl, ""));

            StudentAuth.Nodes.Add(StudentNode);

            return StudentAuth;
            //throw new NotImplementedException();
        }

        #endregion
    }
}
