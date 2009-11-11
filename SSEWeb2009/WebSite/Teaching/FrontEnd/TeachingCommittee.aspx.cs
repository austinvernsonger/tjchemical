using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching.Ops;

public partial class Teaching_Committee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public String ShowContent()
    {
        if (Request.QueryString["ID"] != null)
        {
            opsTeachingQuery opsSelect = new opsTeachingQuery("select [Content]from [EducationMeetingRecord] where ID =" + Request.QueryString["ID"]);
            opsSelect.Do();
            if (opsSelect.mResult.Tables.Count == 1 && opsSelect.mResult.Tables[0].Columns["Content"] != null)
            {
                return opsSelect.mResult.Tables[0].Rows[0]["Content"].ToString();
            }
        }
        return "";
    }
}
