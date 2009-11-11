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

using LabCenter.Repair;
using LabCenter.LabUtility.TimeUtility;
using LabCenter.LabUtility.LoginUtility;

public partial class RepairManagement_Unhandled_ComputerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 9, 1);
        }
        ComputerManager cpm = new ComputerManager();
        DataSet ds = cpm.GetOrderUnhandledList();
        if (ds.Tables.Count > 0)
        {
            GVUnhandledCp.DataSource = ds;
            GVUnhandledCp.DataBind();
        }
        else
        {
            lblMsg.Text = "没有报修数据";
        }
    }
    protected void GVUnhandledCp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());
        Response.Redirect("~/LabCenter/Repair/Unhandled/ComputerDetail.aspx?id=" + GVUnhandledCp.Rows[index].Cells[1].Text);
        //GVUnhandledCp.Rows[index];
        //this.Session["managerID"] = GridView1.DataKeys[index].Value.ToString().Trim();
        //Response.Redirect("AuthoManage.aspx");
    }
    protected void GVUnhandledCp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                DateTime dt=DateTime.Parse(e.Row.Cells[3].Text);
                if (DateTime.Now.Ticks-dt.Ticks>=864000000000)
                {
                    //有点长了时间
                    //e.Row.BorderStyle = BorderStyle.Solid;
                    //e.Row.BorderWidth = 1;
                    //e.Row.BorderColor=System.Drawing.Color.LightGray;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }
                e.Row.Cells[3].Text = TimeTeller.Diff(DateTime.Parse(e.Row.Cells[3].Text),DateTime.Now);
                
            }
        }
    }
}
