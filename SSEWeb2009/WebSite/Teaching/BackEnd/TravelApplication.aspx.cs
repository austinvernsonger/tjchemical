using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_TravelApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery QueryName = new opsTeachingQuery("select Name from Teacher where TeacherID = '" + Session["IdentifyNumber"].ToString()+"'");
            QueryName.Do();
            if(QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            RequestPerson.Text = QueryName.mResult.Tables[0].Rows[0][0].ToString();
            String ArticleId = Request.QueryString["ID"];
            if (ArticleId == null)
                return;
            else
            {
                bnSubmit.Enabled = false;
                opsTeachingQuery opsQuery = new opsTeachingQuery("select PersonTogether, TravelPlace, TravelCompany, PreStartDate, PreEndDate, FundsBudget, TravelTask, Other from TravelApplication where RequestID = " + ArticleId);
                opsQuery.Do();
                PersonTogether.Text = opsQuery.mResult.Tables[0].Rows[0][0].ToString();
                PersonTogether.Enabled = false;
                TravelPlace.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
                TravelPlace.Enabled = false;
                TravelCompany.Text = opsQuery.mResult.Tables[0].Rows[0][2].ToString();
                TravelCompany.Enabled = false;
                PreStartDate.VisibleDate = PreStartDate.SelectedDate = (DateTime)opsQuery.mResult.Tables[0].Rows[0][3];
                PreStartDate.Enabled = false;
                PreEndDate.VisibleDate = PreEndDate.SelectedDate = (DateTime)opsQuery.mResult.Tables[0].Rows[0][4];
                PreEndDate.Enabled = false;
                FundsBudget.Text = opsQuery.mResult.Tables[0].Rows[0][5].ToString();
                FundsBudget.Enabled = false;
                TravelTask.Text = opsQuery.mResult.Tables[0].Rows[0][6].ToString();
                TravelTask.Enabled = false;
                Other.Text = opsQuery.mResult.Tables[0].Rows[0][7].ToString();
                Other.Enabled = false;
            }
        }
    }
    protected void bnSubmit_Click(object sender, EventArgs e)
    {

        if (TravelPlace.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "出差地点");
            return;
        }
        if (TravelCompany.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "出差单位");
            return;
        }
        if (PreStartDate.SelectedDate.ToString() == "0001/1/1 0:00:00")
        {
            ErrorMsg.WriteErrorMsg(Response, "预计出差开始日期");
            return;
        }
        if (PreEndDate.SelectedDate.ToString() == "0001/1/1 0:00:00")
        {
            ErrorMsg.WriteErrorMsg(Response, "预计出差结束日期");
            return;
        }
        if (String.Compare(PreStartDate.SelectedDate.ToString("yyyy-MM-dd"), PreEndDate.SelectedDate.ToString("yyyy-MM-dd")) > 0)
        {
            ErrorMsg.WriteErrorMsg(Response, "正确的日期(预计出差开始日期应该在出差结束日期之前)");
            return;
        }
        if (FundsBudget.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "预算经费");
            return;
        }
        try
        {
            decimal dNumTmp = Convert.ToDecimal(this.FundsBudget.Text);
        }
        catch (System.FormatException)
        {
            ErrorMsg.WriteErrorMsg(Response, "正确格式的预算经费");
            return;
        }
        catch (System.OverflowException)
        {
            ErrorMsg.WriteErrorMsg(Response, "正确的预算经费(预算经费超出了系统可以表示的值)");
            return;
        }
        if (TravelTask.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "出差任务");
            return;
        }
        String sql = "insert into TravelApplication(RequestPerson, PersonTogether, TravelPlace, TravelCompany, PreStartDate, PreEndDate, FundsBudget, TravelTask, Other) values(";
        sql += "\'" + Session["IdentifyNumber"].ToString() + "\',";
        sql += "\'" + TextConverter.ProcessString(this.PersonTogether.Text) + "\',";
        sql += "\'" + TextConverter.ProcessString(this.TravelPlace.Text) + "\',";
        sql += "\'" + TextConverter.ProcessString(this.TravelCompany.Text) + "\',";
        sql += "\'" + this.PreStartDate.SelectedDate.ToString("yyyy-MM-dd") + "\',";
        sql += "\'" + this.PreEndDate.SelectedDate.ToString("yyyy-MM-dd") + "\',";
        decimal dNum = Convert.ToDecimal(this.FundsBudget.Text);
        sql += dNum.ToString() + ",";
        sql += "\'" + TextConverter.ProcessString(this.TravelTask.Text) + "\',";
        sql += "\'" + TextConverter.ProcessString(this.Other.Text) + "\')";
        opsTeachingExec insert = new opsTeachingExec(sql);
        insert.Do();
        Response.Redirect("./TravelApplicationList.aspx");
    }
    protected void bnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("./TravelApplicationList.aspx");
    }
}
