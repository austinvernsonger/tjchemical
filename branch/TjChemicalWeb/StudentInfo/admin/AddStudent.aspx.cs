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
using StundentInfoManagement;


public partial class StudentInfo_admin_AddStudent : System.Web.UI.Page
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
        DataSet Rs =  StudentBasicInfoEx.SelectStudentAccount();
        GridViewStudentInfo.DataSource = Rs;
        GridViewStudentInfo.DataBind();
    }
    protected void AddInfo_Click(object sender, EventArgs e)
    {
        if (!StudentBasicInfoEx.InsertStudent( txtStudentID.Text.Trim(), txtName.Text.Trim()))
        {
            lbErrorMessage.Visible =true;
            lbErrorMessage.Text = "插入失败!";
            return;
        }
        lbErrorMessage.Visible =true;
        lbErrorMessage.Text = "插入成功!";
        Rebind();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId = this.GridViewStudentInfo.DataKeys[index].Value.ToString().Trim();
        StundentInfoManagement.StudentBasicInfoEx.DeleteStudentInfo(SelectId);
        Rebind();
    }
}
