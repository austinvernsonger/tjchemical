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
using Department.Engineering;

public partial class Engineering_StuBackMag_ViewAllTutorsInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (!IsPostBack)
        {
            bindData();
        }
    }
    protected void bindData()
    {
        TeacherManage tm = new TeacherManage();
        DataSet ds = tm.GetTutorsInfoList();
        gvTutorsInfo.DataSource = ds.Tables[0].DefaultView;
        gvTutorsInfo.DataBind();
    }
}
