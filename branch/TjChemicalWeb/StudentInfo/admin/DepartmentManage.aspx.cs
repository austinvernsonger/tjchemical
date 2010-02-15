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


public partial class StudentInfo_admin_DepartmentManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        if (Session["Authority"].ToString()!="Admin")
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        //String Adminnumber = "110";
        //if(StudentBasicInfoEx.CheckAdmin(Adminnumber))
        //{
            if (!IsPostBack)
            {
                Rebind();
            }
        //}
        //else
        //{
          //  SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
    }
    protected void bt_addDepartmentName_Click(object sender, EventArgs e)
    {
        string sDepartmentname = txtDepartmentName.Text.ToString();
        if(!DepartmentInfoEx.AddDepartName(sDepartmentname))
        {
            ERRORMessage.Text = "插入失败！";
            return;
        }
        Rebind();
    }
    protected void Rebind()
    {
        DataSet DepartmentName_dataset = DepartmentInfoEx.SelectAllDepartName();
        GridViewDepartment.DataSource = DepartmentName_dataset;
        GridViewDepartment.DataBind();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId = GridViewDepartment.DataKeys[index].Value.ToString().Trim();
        //ERRORMessage.Text = SelectId;
        
        if (!DepartmentInfoEx.DeleteDepartName(SelectId))
        {
            ERRORMessage.Text = "删除失败！";
            return;
        }
        Rebind();
    }
}
