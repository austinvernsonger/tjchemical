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

public partial class StudentInfo_StudentInfoQuery : System.Web.UI.Page
{
    private DataSet Rs;
    protected void Rebind()
    {
        String strStudentID = txtStudentID.Text.Trim();
        String strName = txtName.Text.Trim();
        String strNation = txtNation.Text.Trim();
        Int16 strDepartment = CheckDropDownListContent(DropDownListDepartment);
        String strField = txtField.Text.Trim();
        Int32 strEntranceYear = txtEntranceYear.Text.Trim() == String.Empty ? 0 : Convert.ToInt32(txtEntranceYear.Text.Trim());
        Int16 strStudentType = CheckDropDownListContent(DropDownListStudentType);
        Int16 strGraduationType = CheckDropDownListContent(DropDownListGraduationType);
        Int16 strWorkUnit = CheckDropDownListContent(DropDownListWorkUnit);

        Rs = StudentBasicInfoEx.QueryStudentInfo(strStudentID, strName, strNation, strDepartment, strField,
            strEntranceYear, strStudentType, strGraduationType, strWorkUnit);
        GridViewStudentInfo.DataSource = Rs;
        GridViewStudentInfo.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckID();
        if (!IsPostBack)
        {
            ControlInitalize();
        }
    }
    protected void CheckID()
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        if (Session["Authority"].ToString() != "Admin")
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
    }
    protected void ControlInitalize()
    {

        DataSet dtDepartmentName = DepartmentInfoEx.SelectAllDepartName();

        for (int i = 0; i != dtDepartmentName.Tables[0].Rows.Count; i++)
        {
            ListItem ItemDepartmentName = new ListItem();
            ItemDepartmentName.Value = dtDepartmentName.Tables[0].Rows[i][0].ToString();
            ItemDepartmentName.Text = dtDepartmentName.Tables[0].Rows[i][1].ToString();
            DropDownListDepartment.Items.Add(ItemDepartmentName);
        }

        DataSet dtWorkUnitName = WorkUnitInfoEx.SelectAllWorkUnitName();

        for (int i = 0; i != dtWorkUnitName.Tables[0].Rows.Count; i++)
        {
            ListItem ItemWorkUntiName = new ListItem();
            ItemWorkUntiName.Value = dtWorkUnitName.Tables[0].Rows[i][0].ToString();
            ItemWorkUntiName.Text = dtWorkUnitName.Tables[0].Rows[i][1].ToString();
            DropDownListWorkUnit.Items.Add(ItemWorkUntiName);
        }

    }
    protected Int16 CheckDropDownListContent(DropDownList a)
    {
        if (a.SelectedValue == "-1")
        {
            return -1;
        }
        return Convert.ToInt16(a.SelectedValue);
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        Rebind();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridViewStudentInfo.PageIndex = e.NewPageIndex;
        Rebind();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
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
        String SelectId = this.GridViewStudentInfo.DataKeys[index].Value.ToString().Trim();
        StundentInfoManagement.StudentBasicInfoEx.DeleteStudentInfo(SelectId);
        Rebind();
    }
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}
