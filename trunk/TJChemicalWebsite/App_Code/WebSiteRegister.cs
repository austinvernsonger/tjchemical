using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Department;
using StudentInfo;
/// <summary>
/// Summary description for WebSiteRegister
/// </summary>
public class WebSiteRegister
{
    public WebSiteRegister()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Register you department here!
    /// </summary>
    /// <returns></returns>
    public static Boolean RegisterDepartment()
    {
        Department.Interface.DepartmentList.Register("学生信息管理", new StudentInfo.StudentInfoRegister());
      

        return true;
    }
}
