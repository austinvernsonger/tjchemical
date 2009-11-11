using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teaching_Content : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public String GetContent()
    {
        
        if(Request.QueryString["ID"]!=null)
        {
            String ContentID =Request.QueryString["ID"];
            if (Session[ContentID] != null)
            {
                String ContentString = Session[ContentID].ToString();
               // Session.Remove(ContentID);
                return ContentString;
            }
        }
        return "The Content could't be found!";

    }
}
