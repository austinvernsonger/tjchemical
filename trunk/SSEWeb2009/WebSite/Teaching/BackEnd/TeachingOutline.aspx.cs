using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_TeachingOutline : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery opsQuery = new opsTeachingQuery("select Name from Teacher where TeacherID = '" + Session["IdentifyNumber"].ToString()+"'");
            opsQuery.Do();
            if (opsQuery.mResult.Tables.Count == 0 || opsQuery.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            if (Request.QueryString["ID"] == null)
                return;
            opsQuery = new opsTeachingQuery("select TeachingOutline from NewCourseApplication where RequestID = " + Request.QueryString["ID"].ToString());
            opsQuery.Do();
            if (opsQuery.mResult.Tables.Count == 0 || opsQuery.mResult.Tables[0].Rows.Count == 0)
                return;
            TeachingOutline.Value = opsQuery.mResult.Tables[0].Rows[0][0].ToString();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (TeachingOutline.Value == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "教学大纲的内容");
            return;
        }
        opsTeachingExec opsExec = new opsTeachingExec("update NewCourseApplication set TeachingOutline = " + FckConverter.ProcessString(TeachingOutline.Value) + " where RequestID = " + Request.QueryString["ID"].ToString());
        opsExec.Do();
    }
}
