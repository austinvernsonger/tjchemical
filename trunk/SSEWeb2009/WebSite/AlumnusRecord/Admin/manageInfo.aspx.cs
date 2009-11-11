using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AlumnusRecord_Admin_manageInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.MMTList1.DepartmentId = Convert.ToInt32(this.DropDownList1.SelectedValue); 
    }
}
