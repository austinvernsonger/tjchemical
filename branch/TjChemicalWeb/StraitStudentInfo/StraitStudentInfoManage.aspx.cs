using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class StraitStudentInfo_StraitStudentInfoManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        if (Session["Authority"].ToString() != "Admin")
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (!IsPostBack)
        {

            Rebind();
        }
    }
    private void Rebind()
    {
        DataSet Rs = StundentInfoManagement.StraitStudentInfoEx.SelectAllStraitStudent();
        this.GridviewStraitStudent.DataSource = Rs;
        this.GridviewStraitStudent.DataBind();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId = this.GridviewStraitStudent.DataKeys[index].Value.ToString().Trim();
        if (!StundentInfoManagement.StraitStudentInfoEx.DeleteStraitStudent(SelectId))
        {
            lbErrorMessage.Text = "删除失败！";
            return;
        }
        lbErrorMessage.Text = "删除成功！";
        Rebind();
    }
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = e.NewEditIndex;
        String SelectId = this.GridviewStraitStudent.DataKeys[index].Value.ToString().Trim();
        String strurl = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        if (!strurl.EndsWith("/")) strurl += "/";
        strurl += "StraitStudentInfo/StraitStudentInfoLogin.aspx" + "?id=" + SelectId;
        Response.Redirect(strurl);
    }
    protected Int16 CheckDropDownListContent(DropDownList a)
    {
        if (a.SelectedValue == "-1")
        {
            return -1;
        }
        return Convert.ToInt16(a.SelectedValue);
    }
    protected Int16 CheckContent(TextBox a)
    {
        if (a.Text.Trim()==String.Empty)
        {
            return -1;
        }
        return Convert.ToInt16(a.Text.Trim());
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        DataSet Ds = StundentInfoManagement.StraitStudentInfoEx.StraitStudentQuery(txtStudentID.Text.Trim(), txtName.Text.Trim(),CheckContent(txtClass) ,
            CheckDropDownListContent(DropDownListStraitDegree));
        this.GridviewStraitStudent.DataSource = Ds;
        this.GridviewStraitStudent.DataBind();
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        if (txtStudentID.Text.Trim() == String.Empty)
        {
            lbErrorMessage.Text = "请输入学号后按添加！";
            return;
        }
        String SelectId = txtStudentID.Text.Trim();
        IdentifyLibrary.Identity checkStudent = new IdentifyLibrary.Identity(SelectId);
        if (StundentInfoManagement.StraitStudentInfoEx.HasStraitStudent(SelectId))
        {
            lbErrorMessage.Text = "该学生已存在！";
            return;
        }
        if (!checkStudent.isStudent)
        {
            lbErrorMessage.Text = "该学生尚未注册！";
            return;
        }
        if (!StundentInfoManagement.StraitStudentInfoEx.AddStraitStudent(SelectId))
        {
            lbErrorMessage.Text = "数据插入失败!";
            return;
        }

        String strurl = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        if (!strurl.EndsWith("/")) strurl += "/";
        strurl += "StraitStudentInfo/StraitStudentInfoLogin.aspx" + "?id=" + SelectId + "&Type=add";
        Response.Redirect(strurl);
    }
}
