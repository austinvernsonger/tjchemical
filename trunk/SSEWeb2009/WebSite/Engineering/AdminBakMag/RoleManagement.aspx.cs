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
using Department.Engineering;

public partial class Engineering_AdminBakMag_RoleManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindRoles();
        }
    }
    protected void bindRoles()
    {
        RoleManage rMag = new RoleManage();
        DataView dv = rMag.GetAllRolesWithoutSuperAdm();
        gvRoles.DataSource = dv;
        gvRoles.DataBind();
    }
    protected void gvRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox tb = (TextBox)gvRoles.Rows[e.RowIndex].FindControl("tbRoleName");
        if (tb.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('角色名不能为空')</script>");
            return;
        }
        int roleid = Convert.ToInt32(gvRoles.DataKeys[e.RowIndex].Value);
        RoleManage rMag = new RoleManage();
        rMag.UpdateRoles(roleid, tb.Text.Trim());
        gvRoles.EditIndex = -1;
        bindRoles();
    }
    protected void gvRoles_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRoles.EditIndex = e.NewEditIndex;
        bindRoles();
    }
    protected void gvRoles_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvRoles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int roleID = Convert.ToInt32(gvRoles.DataKeys[e.Row.RowIndex].Value);
            ImageButton lnb = (ImageButton)e.Row.FindControl("imgEdit");
            lnb.PostBackUrl = "RolesPrivilege.aspx?id=" + roleID;
        }
    }
    protected void btConfirm_Click(object sender, EventArgs e)
    {
        string ID = tbNewAdmin.Text.Trim();
        DataSet ds = null;
        RoleManage rMag = new RoleManage();
        TeacherManage tMag = new TeacherManage();
        ds = tMag.GetTeacherInfoByTeacherID(ID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblRes.Text = "该账号不属于教师账号，超级管理员的权限必须移交给教师";
            return;
        }
        if (rMag.AddSuperAdminForMSEByTran(ID) == true)
        {
            lblRes.Text = "权限移交成功,请退出系统";
            btConfirm.Enabled = false;
        }
        else
        {
            lblRes.Text = "权限移交失败,请重试";
        }
    }
}
