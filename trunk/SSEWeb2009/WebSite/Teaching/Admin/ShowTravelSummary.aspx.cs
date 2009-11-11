using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching.Ops;

public partial class Teaching_Admin_ShowTravelSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected String ShowSummary()
    {
        if (Request.QueryString["ID"] != null)
        {
            opsTeachingQuery opsSelect = new opsTeachingQuery("select [Summary] from [TravelApplication] where [RequestID] = " + Request.QueryString["ID"]);
            opsSelect.Do();
            if (opsSelect.mResult.Tables.Count == 1 && opsSelect.mResult.Tables[0].Columns["Summary"] != null)
            {
                return opsSelect.mResult.Tables[0].Rows[0]["Summary"].ToString();
            }
        }
        return "";
    }
}
