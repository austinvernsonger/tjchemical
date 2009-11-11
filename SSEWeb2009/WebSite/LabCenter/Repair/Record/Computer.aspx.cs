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

public partial class RepairManagement_Record_ComputerRepair : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 9, 1);
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        //if(!tbBeginTime.Text.Equals("") || !tbEndTime.Text.Equals(""))
        //{
        //    GVCpRecords.DataSourceID = "obj_date";
        //    GVCpRecords.DataBind();
        //}
    }
    protected void GVCpRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                string t1 = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = ComputerManager.ParseDate(t1);
                string state = e.Row.Cells[5].Text;
                e.Row.Cells[5].Text = StateCtrl.ParseToString(int.Parse(state));
                string t2 = e.Row.Cells[6].Text;
                if (!t2.Equals(""))
                {
                    e.Row.Cells[6].Text = ComputerManager.ParseDate(t2);
                }
                
            }
        }
    }
}
