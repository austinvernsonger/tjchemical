using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Department;

public partial class MasterPage_BackSys : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["IdentifyNumber"] == null)
            {
                //SysCom.Login.LoginRedirect(Request.Url.ToString());
            }
            else
            {
               /* Department.Interface.DepartmentList.GenerateNavigation(
                    ref pnl_nav, (String)Session["IdentifyNumber"],
                    "dpmntTitle", "treeCssClass", "ifrm_content");*/
            }
        }
    }
}
