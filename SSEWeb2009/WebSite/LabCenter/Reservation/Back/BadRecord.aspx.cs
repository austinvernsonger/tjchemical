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
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Reservation_Back_BadRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

        }  
    }
    protected void GV_BadRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                DateTime dt = DateTime.Parse(e.Row.Cells[1].Text);
                e.Row.Cells[1].Text=dt.ToString("yyyy-MM-dd hh:mm");
            }
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Width = 100;
            e.Row.Cells[1].Width = 150;
            e.Row.Cells[2].Width = 300;
        }
    }
}
