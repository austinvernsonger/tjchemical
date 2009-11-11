using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using StudentManages.Sql;
using System.Text;

public partial class StudentManage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string url = HttpContext.Current.Request.ApplicationPath + "/Login/Login.aspx?toURL=" + HttpContext.Current.Request.ApplicationPath + "/StudentManage/LoginCheck.aspx";
            this.Response.Redirect(url);
            
    }
}
