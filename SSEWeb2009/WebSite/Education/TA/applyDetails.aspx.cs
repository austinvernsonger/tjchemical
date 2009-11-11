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
using Education.src;
using Education.Sql;

public partial class Education_TA_applyDetails : System.Web.UI.Page
{
    private DataSet ds = null;
    private int num = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            num = (int)Session["num"];
            String SQL = "select * from assistant_apply where apply_num=" + num.ToString() + "";
            ds = EducationDbOpe.DoQuery(SQL);
            DetailsViewApply.DataSource = ds.Tables[0].DefaultView;
            DetailsViewApply.DataBind();
        }
        HyperLinkback.NavigateUrl = "~TA_examine.aspx";
    }
    protected void ButtonAgree_Click(object sender, EventArgs e)
    {
        sqlAgreeAssistant theagreesql = new sqlAgreeAssistant(num);
        EducationDbOpe.DoExecute(theagreesql);
    }
    protected void ButtonReject_Click(object sender, EventArgs e)
    {
        sqlRejectAssistant theagreesql = new sqlRejectAssistant(num);
        EducationDbOpe.DoExecute(theagreesql);
    }
}
