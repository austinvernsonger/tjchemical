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
using StudentFile;
public partial class StudentFile_StudentFileMng : System.Web.UI.Page
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
    public void Rebind()
    {
        DataSet Rs = StudentFileEx.SelectAllStudentFile();
        this.GridviewFile.DataSource = Rs;
        GridviewFile.DataBind();
    }
    protected Int16 CheckContent(TextBox a)
    {
        if (a.Text.Trim() == String.Empty)
        {
            return -1;
        }
        return Convert.ToInt16(a.Text.Trim());
    }
    public void Rebind(String ID,String strName,Int16 iClass)
    {
        DataSet Rs = StudentFileEx.SelectStudentFileQuery(ID,strName,iClass);
        this.GridviewFile.DataSource = Rs;
        GridviewFile.DataBind();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId = this.GridviewFile.DataKeys[index].Value.ToString().Trim();
        if (!StudentFileEx.DeleteStudentFile(SelectId))
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
        String SelectId = this.GridviewFile.DataKeys[index].Value.ToString().Trim();
        String strurl = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        if (!strurl.EndsWith("/")) strurl += "/";
        strurl += "StudentFile/StudentFileBasicInfo.aspx" + "?id=" + SelectId + "&Type=edit";
        Response.Redirect(strurl);
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        Rebind(txtStudentID.Text.Trim(),txtName.Text.Trim(),CheckContent(txtClass));
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        if (txtStudentID.Text.Trim()==String.Empty)
        {
            lbErrorMessage.Text = "请输入学号后按添加！";
            return;
        }
        String SelectId = txtStudentID.Text.Trim();
        if(StudentFileEx.CheckStudent(SelectId))
        {
            lbErrorMessage.Text = "该学生已存在！";
            return;
        }
        if (!StudentFileEx.CheckStudentTable(SelectId))
        {
            lbErrorMessage.Text = "该学生尚未注册！";
            return;
        }
        if (!StudentFileEx.InsertStudentFile(SelectId))
        {
            lbErrorMessage.Text = "数据插入失败!";
            return;
        }
        
        String strurl = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        if (!strurl.EndsWith("/")) strurl += "/";
        strurl += "StudentFile/StudentFileBasicInfo.aspx" + "?id=" + SelectId+"&Type=add";
        Response.Redirect(strurl);
    }
}
