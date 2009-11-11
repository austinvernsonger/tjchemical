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

public partial class LabCenter_Equipment_DeviceApply_DeviceApplyTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        EquipmentManager em = new EquipmentManager();
        DataSet ds = em.GetOpenDevice();
        DeviceDrop.Items.Clear();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DeviceDrop.Items.Insert(i, ds.Tables[0].Rows[i][0].ToString());
        }
        Information.Visible = false;
    }

    protected void btnDeviceApply_Click(object sender, EventArgs e)
    {
        Information.Visible = true;
        string strName = DeviceDrop.SelectedItem.Text;
        string strDesp = tbDescription.Text;
        DeviceApplyTable dat = new DeviceApplyTable();
        int ret = dat.DeviceApplySubmit(Session["IdentifyNumber"].ToString(),strName, strDesp);
        if (ret != -1)
        {
            Information.Text = "申请成功，请记下申请号：" + ret.ToString();
        }
        else
        {
            Information.Text = "申请失败，请稍候再试！";
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UserDeviceApplyTable.aspx");
    }
}
