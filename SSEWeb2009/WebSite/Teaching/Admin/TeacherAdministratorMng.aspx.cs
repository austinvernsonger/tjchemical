using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_TeacherAdministratorMng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery op = new opsTeachingQuery("select * from TeacherAdministrator where TeacherID = '" + Session["IdentifyNumber"].ToString() + "' and IfSuperAdmin = 1");
            op.Do();
            if (op.mResult.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script language=javascript> alert(test); </script>");
                Response.Write("<script language=javascript> history.go(-1); </script>");
            }
            else
            {
                Rebind();
            }
        }
    }

    private void Rebind()
    {
        opsTeachingQuery op = new opsTeachingQuery("select * from TeacherAdministrator where IfSuperAdmin = 0");
        op.Do();
        TeacherAdminGridView.DataSource = op.mResult;
        TeacherAdminGridView.DataBind();
        
        opsTeachingQuery op1 = new opsTeachingQuery("select TeacherID from Teacher where TeacherID not in (select TeacherID from TeacherAdministrator)");
        op1.Do();
        TeacherCBL.DataSource = op1.mResult.Tables[0];
        TeacherCBL.DataTextField = op1.mResult.Tables[0].Columns[0].ToString();
//         TeacherCBL.DataValueField = op1.mResult.Tables[0].Columns[1].ToString();
        TeacherCBL.DataBind();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId = TeacherAdminGridView.DataKeys[index].Value.ToString().Trim();
        opsTeachingExec op = new opsTeachingExec("delete from TeacherAdministrator where TeacherID = '" + SelectId + "'");
        op.Do();
        Rebind();
    }

    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TeacherAdminGridView.PageIndex = e.NewPageIndex;
        Rebind();
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < TeacherCBL.Items.Count; i++)
        {
            if (TeacherCBL.Items[i].Selected)
            {
                opsTeachingExec op = new opsTeachingExec("insert into TeacherAdministrator (TeacherID, IfSuperAdmin, Valid) values ('" + TeacherCBL.Items[i].ToString() + "',0,1)");
                op.Do();
            }  
        }
        Rebind();
    }
}
