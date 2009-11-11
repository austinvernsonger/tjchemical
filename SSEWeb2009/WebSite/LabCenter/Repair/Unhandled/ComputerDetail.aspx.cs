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
using LabCenter.LabUtility.EmailUtility;
using LabCenter.LabUtility.SimpleHtmlGenerator;
using LabCenter.LabUtility.TimeUtility;
using LabCenter.LabUtility.LoginUtility;


public partial class RepairManagement_Unhandled_ComputerOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            Message.Visible = true;
        }
        else
        {
            LoginCtrl.CheckAuthorityRedirect(this, 9, 1);
            BindData();
        }
        ControlVisibleChange();
    }

    void ControlVisibleChange()
    {
        btnCancel.Visible = LoginCtrl.HasAuthority(this, 9, 3);
        btnMakeSure.Visible = LoginCtrl.HasAuthority(this, 9, 2);
    }

    protected void BindData()
    {
        string cp_number = Request.Params.Get("id");
        if (null != cp_number)
        {
            lblCpNum.Text = cp_number;
            ComputerManager cpm = new ComputerManager();
            DataSet ds = cpm.GetOrderUnhandledDetail(cp_number);
            GVUnhandledCpDetail.DataSource = ds;
            GVUnhandledCpDetail.DataBind();
        }
        else
        {
            lblMsg.Text = "没有id后缀，不合法的访问。";
            Message.Visible = true;
            Content.Visible = false;
        }
    }
    public string GetEmailContent()
    {
        SimpleHtmlBuilder shb = new SimpleHtmlBuilder();
        shb.Append(new SimpleHtmlLabel(lblCpNuminfo));
        shb.Append(new SimpleHtmlLabel(lblCpNum));
        shb.Append(new SimpleHtmlbr(2));
        ComputerManager cpm = new ComputerManager();
        DataSet ds = cpm.GetOrderUnhandledDetail(Request.Params.Get("id"));
        shb.Append(new SimpleHtmlDataset(ds));
        return ((IHtmlable)shb).GetStringBuilder().ToString();
    }
    protected void btnMakeSure_Click(object sender, EventArgs e)
    {
        ComputerManager cpm = new ComputerManager();
        if (cpm.Confirm(lblCpNum.Text))
        {
            lblMsg.Text = "确认成功";
        }
        else
        {
            lblMsg.Text = cpm.ErrorMsg;
        }
        BindData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ComputerManager cpm = new ComputerManager();
        if (cpm.Confirm(lblCpNum.Text))
        {
            lblMsg.Text = "取消成功";
        }
        else
        {
            lblMsg.Text = cpm.ErrorMsg;
        }
        BindData();
    }

    protected void GVUnhandledCpDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                DateTime dt = DateTime.Parse(e.Row.Cells[2].Text);
                if (DateTime.Now.Ticks - dt.Ticks >= 864000000000)
                {
                    //有点长了时间
                    //e.Row.BorderStyle = BorderStyle.Solid;
                    //e.Row.BorderWidth = 1;
                    //e.Row.BorderColor=System.Drawing.Color.LightGray;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }
                e.Row.Cells[2].Text = TimeTeller.Diff(DateTime.Parse(e.Row.Cells[2].Text), DateTime.Now);

            }
        }
    }
}
