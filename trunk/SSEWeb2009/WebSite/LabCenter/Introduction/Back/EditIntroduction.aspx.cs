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
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Introduction_Back_EditIntroduction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 1, 1);

        }  
    }
}
