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

public partial class RepairManagement_Record_OtherRepair : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 9, 1);
        }
    }
    protected void GVOtRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                string t1 = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = OtherManager.ParseDate(t1);
                string state = e.Row.Cells[6].Text;
                e.Row.Cells[6].Text = StateCtrl.ParseToString(int.Parse(state));
                string t2 = e.Row.Cells[7].Text;
                if (!t2.Equals(""))
                {
                    e.Row.Cells[7].Text = OtherManager.ParseDate(t2);
                }

            }
        }
    }
}
