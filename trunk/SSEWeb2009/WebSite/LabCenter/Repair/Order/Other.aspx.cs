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
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Repair_Order_Other : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            this.lblRetmsg.Visible = true;
        }
        else
        {
            LoginCtrl.CheckLoginRedirect(this);
        }
    }
    protected void btnNewOtherOrder_Click(object sender, EventArgs e)
    {
        string reporter_id;
        //获取登陆账号
        reporter_id = LoginCtrl.CheckLoginRedirect(this);


        OtherManager om = new OtherManager();
        string devname = tbDevName.Text;
        string location = tbLocation.Text;
        string discrip=tbDiscription.Text;
        string retmsg;
        if(!om.NewOrder(reporter_id,devname,location,discrip))
        {
            retmsg = om.ErrorMsg;
        }
        else
        {
            retmsg = "提交成功";
            tbDevName.Text = "";
            tbDiscription.Text = "";
            tbLocation.Text = "";
        }
        lblRetmsg.Text = retmsg;
    }
    
}
