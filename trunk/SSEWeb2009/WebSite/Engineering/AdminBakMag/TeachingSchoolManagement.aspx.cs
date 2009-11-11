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

public partial class Engineering_AdminBakMag_TeachingSchoolManagement : System.Web.UI.Page
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
        TeachingSchool ts = new TeachingSchool();
        DataSet ds = ts.GetTeaSchool();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
        }
        gvTSchool.DataSource = ds.Tables[0];
        gvTSchool.DataBind();
    }
    protected void gvTSchool_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTSchool.PageIndex = e.NewPageIndex;
        bindData();
    }
    protected void gvTSchool_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string tSchoolID = gvTSchool.DataKeys[e.Row.RowIndex].Value.ToString();
            ImageButton lnbEdit = (ImageButton)e.Row.FindControl("lnbRevise");
            lnbEdit.PostBackUrl = "TeaSchoolDetails.aspx?id="+tSchoolID;
        }
    }
    protected void lbNewSchool_Click(object sender, EventArgs e)
    {

    }
}
