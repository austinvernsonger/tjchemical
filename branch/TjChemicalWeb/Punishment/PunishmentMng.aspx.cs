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

public partial class Punishment_PunishmentMng : System.Web.UI.Page
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
            txtAddTime.Text = DateTime.Today.ToString();
        }
    }
    private void Rebind()
    {
        DataSet Rs = StundentInfoManagement.AwardPunishment.SelectAllStudent();
        this.GridViewPunishment.DataSource = Rs;
        this.GridViewPunishment.DataBind();
    }
    protected Int16 CheckContent(TextBox a)
    {
        if (a.Text.Trim() == String.Empty)
        {
            return -1;
        }
        return Convert.ToInt16(a.Text.Trim());
    }
    protected String DateStringFomate(String DateString)
    {
        if (DateString.Length > 11)
        {
            String[] splitDate = DateString.Split('/');
            String[] dateString = splitDate[2].Split(' ');
            String year = splitDate[0];
            String month = splitDate[1];
            String date = dateString[0];
            String Result = year + "/" + month + "/" + date;
            return Result;
        }
        return DateTime.Today.ToString();
    }
    protected String CheckDropDownListView(DropDownList Dp, Object a)
    {
        String content = a.ToString();
        ListItem Checkitem = Dp.Items.FindByValue(content);
        if (Checkitem == null)
        {
            return "-1";
        }
        return content;
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        String SelectId =this.GridViewPunishment.DataKeys[index].Value.ToString().Trim();
        if (!StundentInfoManagement.AwardPunishment.DeleteStudent(SelectId))
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
        String SelectId = this.GridViewPunishment.DataKeys[index].Value.ToString().Trim();
        DataSet Rs = StundentInfoManagement.AwardPunishment.SelectSingleContent(SelectId);
        txtEditID.Text = SelectId;
        txtEditStudentID.Text = Rs.Tables[0].Rows[0][0].ToString();
        txtEditStudentID.Enabled = false;
        txtEditName.Text = Rs.Tables[0].Rows[0][1].ToString();
        txtEditName.Enabled = false;
        DropDownListType.SelectedValue =CheckDropDownListView(DropDownListType,Rs.Tables[0].Rows[0][2]);
        txtAddTime.Text = DateStringFomate(Rs.Tables[0].Rows[0][3].ToString());
        txtContent.Text = Rs.Tables[0].Rows[0][4].ToString();
    }
    protected void bt_Query_Click(object sender, EventArgs e)
    {
        DataSet Rs = StundentInfoManagement.AwardPunishment.SelectByQuery(txtStudentID.Text.Trim(), txtStudentName.Text.Trim(),
            CheckContent(txtClass));
        this.GridViewPunishment.DataSource = Rs;
        this.GridViewPunishment.DataBind();
    }
    protected void bt_Add_Click(object sender, EventArgs e)
    {
        if (txtEditStudentID.Text.Trim() == String.Empty)
        {
            lbErrorMessage.Text = "请输入学号后按保存！";
            return;
        }
        String SelectId = txtEditStudentID.Text.Trim();
        IdentifyLibrary.Identity checkStudent = new IdentifyLibrary.Identity(SelectId);
        if (!checkStudent.isStudent)
        {
            lbErrorMessage.Text = "该学生尚未注册！";
            return;
        }
        if (txtAddTime.Text.Trim() == String.Empty)
        {
            txtAddTime.Text = DateTime.Today.ToString();
        }
        if (txtEditID.Text.Trim() == String.Empty)
        {
            txtEditID.Text = "0";
        }
        if (StundentInfoManagement.AwardPunishment.AddAwardPunishmentData(Convert.ToInt32(txtEditID.Text.Trim()), txtEditStudentID.Text.Trim(), txtAddTime.Text.Trim(), Convert.ToInt16(DropDownListType.SelectedValue), txtContent.Text.Trim()))
        {
            lbErrorMessage.Text = "保存成功！";
            Rebind();
            ClearAll();
            return;
        }
        lbErrorMessage.Text = "保存失败！";
    }
    protected void bt_Cancel_Click(object sender, EventArgs e)
    {
        ClearAll();
    }
    private void ClearAll()
    {
        txtEditStudentID.Text = String.Empty;
        txtEditName.Text = String.Empty;
        txtAddTime.Text = String.Empty;
        txtContent.Text = String.Empty;
        txtAddTime.Text = DateTime.Today.ToString();
        txtEditStudentID.Enabled = true;
        txtEditName.Enabled = true;
        txtEditID.Text = String.Empty;
    }
}
