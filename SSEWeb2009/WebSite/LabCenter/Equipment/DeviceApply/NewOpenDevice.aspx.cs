using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LabCenter.Equipment;
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Equipment_DeviceApply_NewOpenDevice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 7, 9);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strDeviceName = tbDeviceId.Text;
        string strRemark = tbRemark.Text;
        OpenDeviceManage odm = new OpenDeviceManage();
        odm.AddDevice(strDeviceName, strRemark);
        Label1.Visible = true;
        tbDeviceId.Text = "";
        tbRemark.Text = "";
    }
}
