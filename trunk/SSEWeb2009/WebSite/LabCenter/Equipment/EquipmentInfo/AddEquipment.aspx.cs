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

public partial class LabCenter_Equipment_EquipmentInfo_AddEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNewEquipment_Click(object sender, EventArgs e)
    {
       
        string id = devId.Text;
        string name = devName.Text;
        string model = devModel.Text;
        string format = devFormat.Text;
        string account = devAccount.Text;
        string price = devPrice.Text;
        string date = Calendar2.SelectedDate.ToShortDateString();
        string factory = devFactory.Text;
        string status = devStatus.Text;
        string location = devLocation.Text;
        string user = devUser.Text;
        string admin = devAdmin.Text;
        string remark = devRemark.Text;
        EquipmentManager eqm = new EquipmentManager();
        eqm.AddEquipment(id, name, model, format, account, price, date, factory,status, location, location, user, admin, remark);
        
    }


}
