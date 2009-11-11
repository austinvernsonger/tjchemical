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

public partial class SysMgr_BasicStudentMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            Rebind();
        }
    }

    private void Rebind()
    {
        StudentGridView.DataSource = SysCom.BasicStudentInfo.GetStudentTable();
        StudentGridView.DataBind();
    }

    protected void StudentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        StudentGridView.PageIndex = e.NewPageIndex;
        Rebind();
    }

    protected void StudentGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ECF3E1'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId = StudentGridView.DataKeys[index].Value.ToString().Trim();
        SysCom.BasicStudentInfo.DelStudentAccount(SelectId);
        Rebind();
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = Convert.ToInt16(e.NewEditIndex.ToString());
        String SelectId = StudentGridView.DataKeys[index].Value.ToString().Trim();
        SysCom.BasicStudentInfo BSI = SysCom.BasicStudentInfo.GetStudentInfo(SelectId);
        txtStudentID.Text = BSI.m_StudentID;
        txtName.Text = BSI.m_StudentName;
        dropGender.SelectedValue = BSI.m_Gender.ToString();
        txtMajor.Text = BSI.m_Major;
        txtLOS.Text = BSI.m_LengthOfSchooling;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        SysCom.BasicStudentInfo BSI = new SysCom.BasicStudentInfo(txtStudentID.Text.Trim(), txtName.Text.Trim(), "", dropGender.SelectedValue.ToString() == "0" ? 0 : 1, txtMajor.Text.Trim(), txtLOS.Text.Trim(), "");
        BSI.UpdateStudent();
        Rebind();
    }
}
