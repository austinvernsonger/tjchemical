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

public partial class LabCenter_Equipment_MaterialApply_MaterialApply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        MaterialManage mm = new MaterialManage();
        DataSet ds = mm.GetOpenMaterial();
        MaterialDrop.Items.Clear();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            MaterialDrop.Items.Insert(i, (ds.Tables[0].Rows[i][0]).ToString());
        }
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string item = MaterialDrop.SelectedItem.Text;
        string applier = Session["IdentifyNumber"].ToString();
        string count = tbCount.Text;
        string time = DateTime.Now.ToString();
        string status = "0";
        string remark = devRemark.Text;
        if (count.Equals(""))
        {
            Information.Text = "请输入申请数量。";
        }
        else
        {
            MaterialApplyManage mam = new MaterialApplyManage();
            mam.ApplyMaterial(item, applier, count, time, status, remark);
            Information.Visible = true;
            Information.Text = "申请成功";
        }

    }
    protected void RecordBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UserMaterialApplyTable.aspx");
    }
}
