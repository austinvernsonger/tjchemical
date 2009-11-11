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

public partial class Engineering_AdminBakMag_AddNewStudent : System.Web.UI.Page
{
    private bool isEdit = false;
    private bool isOk = false;
    private string studentID;
    private string grade;
    private string schoolID;
    private string degree;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            studentID = Request["id"].ToString();
            isEdit = true;
            lblTitle.Text = "更新学生信息";
            if (!IsPostBack)
            {
               bindData();
            }
        }
        else
        {
            //添加新的学生信息
            FormView1.ChangeMode(FormViewMode.Insert);
        }    
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            TextBox tbStuID = (TextBox)FormView1.FindControl("tbStuID");
            TextBox tbName = (TextBox)FormView1.FindControl("tbName");
            RadioButton rbMan = (RadioButton)FormView1.FindControl("rdMan");
            RadioButton rdWoman = (RadioButton)FormView1.FindControl("rdWoman");
            DropDownList ddlGrade = (DropDownList)FormView1.FindControl("ddlGrade");
            DropDownList ddlSchool = (DropDownList)FormView1.FindControl("ddlSchool");
            TextBox tbSchooling = (TextBox)FormView1.FindControl("tbSchooling");
            DropDownList ddlDegree = (DropDownList)FormView1.FindControl("ddlDegree");
            TextBox tbPassword = (TextBox)FormView1.FindControl("tbPassword");
            if (ddlGrade.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择年级')</script>");
                return;
            }
            if (ddlSchool.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择教学点')</script>");
                return;
            }
            if (ddlDegree.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择学位类别')</script>");
                return;
            }
            StudentInfo sInfo = new StudentInfo();
            StudentManage sMag = new StudentManage();
            sInfo.StuID = tbStuID.Text.Trim();
            sInfo.StuName = tbName.Text.Trim();
            if (rbMan.Checked == true)
            {
                sInfo.Gender = 0;
            }
            else
            {
                sInfo.Gender = 1;
            }
            sInfo.Grade = ddlGrade.SelectedValue;
            sInfo.TeaSchoolID = ddlSchool.SelectedValue;
            sInfo.Schooling = tbSchooling.Text.Trim();
            sInfo.Password = tbPassword.Text.Trim();
            sInfo.Degree = ddlDegree.SelectedValue;
            sInfo.Major = "软件工程";
            if (FormView1.CurrentMode == FormViewMode.Insert)
            {
                //添加新生信息
                //判断当前账号是否为10位有效数
                if (tbStuID.Text.Trim().Length != 10)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('硕士生的学号必须是10位有效数')</script>");
                    return;
                }
                //判断当前账号是否存在
                if (sMag.GetAccountByStuID(sInfo.StuID) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('当前账号已经存在，添加失败')</script>");
                    return;
                }
                //添加新生信息
                if (sMag.AddNewStudentByTran(sInfo) == true)
                {
                    //添加成功
                    isOk = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script>alert('添加成功')</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "fail", "<script>alert('添加失败，请重试')</script>");
                }
            }
            if (FormView1.CurrentMode == FormViewMode.Edit)
            { 
                //修改学生信息
                if (sMag.UpdateStudentInfoByTran(sInfo) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script>alert('修改成功')</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "fail", "<script>alert('修改失败')</script>");
                }
            }
        }
    }
    protected void bindGrade()
    {
        DropDownList ddlGrade = (DropDownList)FormView1.FindControl("ddlGrade");
        System.DateTime theDate = System.DateTime.Now;
        ddlGrade.Items.Clear();
        ddlGrade.Items.Add("--请选择年级--");
        for (int i = theDate.Year - 4; i < theDate.Year + 2; i++)
        {
            ddlGrade.Items.Add(i.ToString() + "级");
        }
    }
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        TextBox tbStuID = (TextBox)FormView1.FindControl("tbStuID");
        TextBox tbName = (TextBox)FormView1.FindControl("tbName");
        RadioButton rbMan = (RadioButton)FormView1.FindControl("rdMan");
        RadioButton rdWoman = (RadioButton)FormView1.FindControl("rdWoman");
        DropDownList ddlGrade = (DropDownList)FormView1.FindControl("ddlGrade");
        DropDownList ddlSchool = (DropDownList)FormView1.FindControl("ddlSchool");
        TextBox tbSchooling = (TextBox)FormView1.FindControl("tbSchooling");
        DropDownList ddlDegree = (DropDownList)FormView1.FindControl("ddlDegree");
        if (isEdit == true)
        {
            //当前处于编辑状态
            tbStuID.Enabled = false;
            for (int i = 1; i < ddlGrade.Items.Count; i++)
            {
                if (string.Compare(ddlGrade.Items[i].Value.Trim(), grade.Trim()) == 0)
                {
                    ddlGrade.Items[i].Selected = true;
                }
            }
            for (int i = 1; i < ddlSchool.Items.Count; i++)
            {
                if (string.Compare(ddlSchool.Items[i].Value.Trim(), schoolID.Trim()) == 0)
                {
                    ddlSchool.Items[i].Selected = true;
                }
            }
            for (int i = 1; i < ddlDegree.Items.Count; i++)
            {
                if (string.Compare(ddlDegree.Items[i].Value.Trim(), degree.Trim()) == 0)
                {
                    ddlDegree.Items[i].Selected = true;
                }
            }
        }
        else
        { 
            //当前处于新增状态

        }
    }
    protected void FormView1_PreRender(object sender, EventArgs e)
    {
        if (isOk == true)
        {
            TextBox tbStuID = (TextBox)FormView1.FindControl("tbStuID");
            TextBox tbName = (TextBox)FormView1.FindControl("tbName");
            RadioButton rbMan = (RadioButton)FormView1.FindControl("rdMan");
            RadioButton rdWoman = (RadioButton)FormView1.FindControl("rdWoman");
            DropDownList ddlGrade = (DropDownList)FormView1.FindControl("ddlGrade");
            DropDownList ddlSchool = (DropDownList)FormView1.FindControl("ddlSchool");
            TextBox tbSchooling = (TextBox)FormView1.FindControl("tbSchooling");
            DropDownList ddlDegree = (DropDownList)FormView1.FindControl("ddlDegree");
            TextBox tbPassword = (TextBox)FormView1.FindControl("tbPassword");
            tbStuID.Text = "";
            tbName.Text = "";
            rbMan.Checked = true;
            ddlGrade.SelectedIndex = 0;
            ddlSchool.SelectedIndex = 0;
            tbSchooling.Text = "2.5年";
            ddlDegree.SelectedIndex = 0;
            tbPassword.Text = "";
        }
    }
    protected void bindData()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStusInfo(studentID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grade = ds.Tables[0].Rows[0]["Grade"].ToString();
            schoolID = ds.Tables[0].Rows[0]["TeaSchoolID"].ToString();
            degree = ds.Tables[0].Rows[0]["Degree"].ToString();
        }
        FormView1.DataSource = ds.Tables[0];
        FormView1.DataBind();
    }
}
