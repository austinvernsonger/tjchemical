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

public partial class StudentManage_AdiministratorContestVerifyStu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string studentID = Convert.ToString(Request.QueryString["StudentID"]);
            string name = Convert.ToString(Request.QueryString["StudentName"]);

        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //返回AdministratorContestVerify页面，并且grade和class保持原状
    }
}
