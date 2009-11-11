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

public partial class Engineering_AdminBakMag_TeaSchoolDetails : System.Web.UI.Page
{
    private string tSchoolID;
    private bool isEdit = false;
    private bool status = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            //修改已有教学点
            tSchoolID = Request["id"].ToString();
            isEdit = true;
            if (!IsPostBack)
            {
                bindData();
            }
        }
        else
        { 
            //添加新教学点
            FormView1.ChangeMode(FormViewMode.Insert);
            lblMessage.Visible = true;
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
           
            TeachingSchool ts = new TeachingSchool();
            DataSet ds = null;
            TextBox tbID = (TextBox)FormView1.FindControl("tbTSchoolNum");
            TextBox tbName = (TextBox)FormView1.FindControl("tbTSchoolName");
            TextBox tbPassword = (TextBox)FormView1.FindControl("tbTSchoolPassword");
            ts.TeaSchoolID = tbID.Text.Trim();
            ts.TeaSchoolName = tbName.Text.Trim();
            ts.Password = tbPassword.Text.Trim();
            if (FormView1.CurrentMode == FormViewMode.Insert)
            {
                //当前为新增教学点
                // 判断当前教学点的编号是否存在
                ds = ts.GetTeaSchoolInfoBytSchoolID(ts.TeaSchoolID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败，该教学点编号已经存在')</script>");
                    return;
                }
                //判断输入的教学点名称是否存在
                ds = ts.GetTeaSchoolInfoBytSchoolName(ts.TeaSchoolName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败，该教学点名称已经存在')</script>");
                    return;
                }
                if (ts.AddNewTeaSchoolInfo(ts) == true)
                {
                    //保存成功
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功')</script>");
                    status = true;
                }
                else
                {
                    //保存失败
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败，请重试')</script>");
                }
            }
            if (FormView1.CurrentMode == FormViewMode.Edit)
            {
                //当前为编辑已有教学点
                if (ts.UpdateTeaSchoolInfo(ts) == true)
                {
                    //更新成功
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功')</script>");
                }
                else
                {
                    //保存失败
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败，请重试')</script>");
                }
            }
        }
    }
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if(isEdit == true)
        {
            //当前为编辑状态
            //将教学点的编号设置为不可编辑
            TextBox tbID = (TextBox)FormView1.FindControl("tbTSchoolNum");
            tbID.Enabled = false;
        }
    }
    protected void bindData()
    {
        TeachingSchool ts = new TeachingSchool();
        DataSet ds = ts.GetTeaSchoolInfoBytSchoolID(tSchoolID);
        FormView1.DataSource = ds.Tables[0];
        FormView1.DataBind();
    }
    protected void FormView1_PreRender(object sender, EventArgs e)
    {
        if (status == true)
        {
            TextBox tbID = (TextBox)FormView1.FindControl("tbTSchoolNum");
            TextBox tbName = (TextBox)FormView1.FindControl("tbTSchoolName");
            TextBox tbPassword = (TextBox)FormView1.FindControl("tbTSchoolPassword");
            tbID.Text = "";
            tbName.Text = "";
            tbPassword.Text = "";
        }
    }
}
