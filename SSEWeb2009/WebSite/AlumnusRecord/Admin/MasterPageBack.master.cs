using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AlumnusRecord_Admin_MasterPageBack : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());

        //等待学工办

      //  opsTeachingQuery QueryName = new opsTeachingQuery("select Name, Gender, Birthday, Address, Telephone, Fax, Email, Title, Post, Memo, LastDegree, LastCollege from Teacher where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'");
      //  QueryName.Do();
       // if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
       //     SysCom.Login.LoginRedirect(Request.Url.ToString());
    }
}
