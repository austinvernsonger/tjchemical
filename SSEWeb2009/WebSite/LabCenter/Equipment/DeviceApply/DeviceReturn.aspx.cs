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

public partial class LabCenter_Equipment_DeviceApply_DeviceReturn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string strApplyId = tbApplyId.Text;
        DeviceReturnManager drm = new DeviceReturnManager();
        drm.ReturnDevice(strApplyId);
    }
}
