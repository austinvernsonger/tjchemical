using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Department.Interface;

namespace Education.src
{
    public class EducationAuthRegister: IGetAuthList
    {
         public virtual TreeView GetTeacherAuthorityList(String ID)
         {   
             EducationDbOpe db = new EducationDbOpe();
             EducationDbOpe.myAuthorityset authType = db.GetAuthority(ID);
             AuthTreeViewBuilder builder = new AuthTreeViewBuilder();
            
             return builder.GetAuthTreeView(authType);
         }
         public virtual TreeView GetStudentAuthorityList(String ID)
         {
             TreeView treeView = new TreeView();
             return treeView;
         }
         public  Boolean SetAsAdmin(String ID)
         {
             return true;
         }
    }
}
