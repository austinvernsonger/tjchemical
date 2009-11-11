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
using LabCenter.LabUtility.SimpleHtmlGenerator;
using LabCenter.LabUtility.LoginUtility;

public partial class RepairManagement_Unhandled_OtherOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
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
        string recordid = Request.Params.Get("id");
        if (null != recordid)
        {
            lblRecordID.Text = recordid;
            OtherManager omg = new OtherManager();
            OtherRecord ord = omg.GetOrderUnhandledDetail(recordid);
            if(null!=ord)
            {
                lblRecordID.Text = ord.RecordID.ToString();
                lblDevName.Text = ord.DevName;
                lblLocation.Text = ord.Location;
                lblDescription.Text = ord.Discription;
                lblReporter.Text = ord.Reporter_ID;
                if (ord.Reporter_Name != null && !ord.Reporter_Name.Equals(""))
                {
                    lblReporter.Text += "(" + ord.Reporter_Name + ")";
                }
                lblUpdateTime.Text = ord.Update_Time.ToLongDateString();
            }
            else
            {
                lblMsg.Text = "不存在的id编号";
                Content.Visible = false;
                Message.Visible = true;
            }
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
        shb.Append(new SimpleHtmlLabel(lblRecordIDinfo));
        shb.Append(new SimpleHtmlLabel(lblRecordID));
        shb.Append(new SimpleHtmlbr());
        shb.Append(new SimpleHtmlLabel(lblDevNameinfo));
        shb.Append(new SimpleHtmlLabel(lblDevName));
        shb.Append(new SimpleHtmlbr());
        shb.Append(new SimpleHtmlLabel(lblLocationinfo));
        shb.Append(new SimpleHtmlLabel(lblLocation));
        shb.Append(new SimpleHtmlbr());
        shb.Append(new SimpleHtmlLabel(lblDescriptioninfo));
        shb.Append(new SimpleHtmlLabel(lblDescription));
        shb.Append(new SimpleHtmlbr());
        shb.Append(new SimpleHtmlLabel(lblUpdateTimeinfo));
        shb.Append(new SimpleHtmlLabel(lblUpdateTime));
        shb.Append(new SimpleHtmlbr());
        shb.Append(new SimpleHtmlLabel(lblReporterinfo));
        shb.Append(new SimpleHtmlLabel(lblReporter));
        shb.Append(new SimpleHtmlbr());
        return ((IHtmlable)shb).GetStringBuilder().ToString();
    }
    protected void btnMakeSure_Click(object sender, EventArgs e)
    {
        OtherManager omg = new OtherManager();
        if (omg.Confirm(lblRecordID.Text))
        {
            lblMsg.Text = "确认成功";
        }
        else
        {
            lblMsg.Text = omg.ErrorMsg;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        OtherManager omg = new OtherManager();
        if (omg.Cancel(lblRecordID.Text))
        {
            lblMsg.Text = "取消成功";
        }
        else
        {
            lblMsg.Text = omg.ErrorMsg;
        }
    }
}
