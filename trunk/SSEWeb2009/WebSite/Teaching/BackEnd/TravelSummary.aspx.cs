using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_TravelSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery opsQuery = new opsTeachingQuery("select Name from Teacher where TeacherID = '" + Session["IdentifyNumber"].ToString()+"'");
            opsQuery.Do();
            if (opsQuery.mResult.Tables.Count == 0 || opsQuery.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            if (Request.QueryString["ID"] == null)
                return;
            opsQuery = new opsTeachingQuery("select Summary, Resource from TravelApplication where RequestID = " + Request.QueryString["ID"].ToString());
            opsQuery.Do();
            if (opsQuery.mResult.Tables.Count == 0 || opsQuery.mResult.Tables[0].Rows.Count == 0)
                return;
            Summary.Value = opsQuery.mResult.Tables[0].Rows[0][0].ToString();
            ResourcePath.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        String sql;
        if(Summary.Value == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "出差总结的内容");
            return;
        }
        if(ResourcePath.Text == "")
        {
            sql = "update TravelApplication set Summary = " + FckConverter.ProcessString(Summary.Value) + " where RequestID = " + Request.QueryString["ID"].ToString();
        }
        else
        {
            if(CheckStatus())
            {
                sql = "update TravelApplication set Summary = " + FckConverter.ProcessString(Summary.Value) + ", Resource=\'" + ResourcePath.Text + "\' " +"where RequestID = " + Request.QueryString["ID"].ToString();
            }
            else
            {
                return;
            }
        }
        opsTeachingExec opsExec = new opsTeachingExec(sql);
        opsExec.Do();
        Response.Redirect("~/Teaching/BackEnd/TravelApplicationList.aspx");
    }

    protected bool CheckStatus()
    {
        if (ResourcePath.Text.Length > 0)
        {
            String Resource = Label.Text + ResourcePath.Text;
            if (StatusCheck.Check(Resource, "guest1", ""))
            {
                Indicator.Text = "<p><span class=\"Apple-style-span\" style=\"font-family: Simsun; font-size: 16px; \"> " +
            "<div style=\"background-color: rgb(255, 255, 255); padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left:"
            + " 5px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; font-family: Arial, Verdana, sans-serif;"
            + " font-size: 12px; \"><strong><span style=\"color: rgb(255, 0, 0); \">&nbsp;请填写"
            + "该路径存在"
            + " </span></strong></div>" + "</span></p>";
                return true;
            }
            else
            {
                Indicator.Text = "<p><span class=\"Apple-style-span\" style=\"font-family: Simsun; font-size: 16px; \"> " +
            "<div style=\"background-color: rgb(255, 255, 255); padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left:"
            + " 5px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; font-family: Arial, Verdana, sans-serif;"
            + " font-size: 12px; \"><strong><span style=\"color: rgb(255, 0, 0); \">&nbsp;请填写"
            + "该路径不存在"
            + " </span></strong></div>" + "</span></p>";
            }
            return false;
        }
        else
        {
            Indicator.Text = "";
            return false;
        }
    }
}
