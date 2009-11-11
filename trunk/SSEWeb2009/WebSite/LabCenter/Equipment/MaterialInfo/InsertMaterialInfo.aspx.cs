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

public partial class LabCenter_Equipment_MaterialInfo_InsertMaterialInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnNewMaterial_Click(object sender, EventArgs e)
    {
        string name = devName.Text;
        string account = devAccount.Text;
        string unit = devUnit.Text;
        string open;
        if (CheckBox1.Checked)
        {
            open = "1";
        }
        else
        {
            open = "0";
        }
        string remark = devRemark.Text;
        MaterialInfoInsert mii = new MaterialInfoInsert(name, account, unit, open, remark);
        mii.InsertMaterialInfo();     
    }
}
