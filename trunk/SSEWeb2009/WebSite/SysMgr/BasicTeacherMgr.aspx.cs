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
using SysCom;

public partial class SysMgr_BasicTeacherMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            DataSet a=    BasicTeacherInfo.QueryTeacherAll();
            TeacherGridView.DataSource = a;

            TeacherGridView.DataBind();
        }
    }

    private void bandgrid()
    {
        TeacherGridView.DataSource = BasicTeacherInfo.QueryTeacherAll(); 
        TeacherGridView.DataBind();
    }

    protected void TeacherGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.TeacherGridView.PageIndex = e.NewPageIndex;
        bandgrid();
    }

    protected void TeacherGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
        String SelectId = TeacherGridView.DataKeys[index].Value.ToString().Trim();
        BasicTeacherInfo.TeacherRowDelete(SelectId);
        bandgrid();
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = Convert.ToInt16(e.NewEditIndex.ToString());
        String SelectId = TeacherGridView.DataKeys[index].Value.ToString().Trim();
        System.Data.DataSet QueryStringResult = SysCom.BasicTeacherInfo.QueryTeacher(SelectId);
        
        tbTeacherID.Text = QueryStringResult.Tables[0].Rows[0]["TeacherID"].ToString();
        tbName.Text = QueryStringResult.Tables[0].Rows[0]["Name"].ToString();
        String gender = QueryStringResult.Tables[0].Rows[0]["Gender"].ToString() == "False" ? "男":"女";
        tbGender.SelectedIndex = -1;
        tbGender.Items.FindByText(gender).Selected = true;
    }

    protected void AddInfo_Click(object sender, EventArgs e)
    {
        if (tbTeacherID.Text == String.Empty)
        {
            Response.Write("<script>alert('教师ID不能为空 请选择一项修改！')</script>");
            return;
        }
        if (tbName.Text == String.Empty)
        {
            Response.Write("<script>alert('教师姓名不能为空 请选择一项修改！')</script>");
            return;
        }

        SavingTeacherInfo  UpdateTeacher = new SavingTeacherInfo();
        UpdateTeacher.SetTeacherID(tbTeacherID.Text);
        UpdateTeacher.SetTeacherName(tbName.Text);
        UpdateTeacher.SetGender(tbGender.SelectedItem.Value);
        BasicTeacherInfo.TeahcerUpdate(UpdateTeacher);
        bandgrid();
        Response.Write("<script>alert('更新成功！')</script>");
    }
}
