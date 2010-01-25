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

public partial class StudentInfo_admin_WorkingPlaceManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        if (Session["Authority"] != "Admin")
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            Rebind();
        }
    }
    protected void Rebind()
    {
        DataSet dtWorkingPlaceName = WorkUnitInfoEx.SelectAllWorkUnitName();
        GridviewWorkingPlace.DataSource = dtWorkingPlaceName;
        GridviewWorkingPlace.DataBind();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId = GridviewWorkingPlace.DataKeys[index].Value.ToString().Trim();
        if (!WorkUnitInfoEx.DeleteWorkUnitName(SelectId))
        {
            ERRORMessage.Text = "删除失败！";
            return;
        }
        Rebind();
    }
    protected void bt_AddWorkingPlace_Click(object sender, EventArgs e)
    {
        string WorkPlaceName = txtWorkingPlaceName.Text.ToString();
        if (!WorkUnitInfoEx.AddWorkUnitName(WorkPlaceName))
        {
            ERRORMessage.Text = "添加失败！";
            return;
        }
        Rebind();
    }
}
