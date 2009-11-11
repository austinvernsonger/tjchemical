using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class SysMgr_ActivityEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SysCom.MMTDelegate.PostEvent p =SysCom.MMTInformation.WriteXML;
        EditMMT1.AfterPost = p;
    }
}
