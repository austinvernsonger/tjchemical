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

public partial class Engineering_AdminBakMag_EditTuitionDetails : System.Web.UI.Page
{
    private int tuitionID;
    private bool isEdit = false;
    private string grade = "";
    private string term = "";
    private string school = "";
    private bool isOk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            //更新学费信息
            tuitionID = Convert.ToInt32(Request["id"]);
            isEdit = true;
            if (!IsPostBack)
            {
                bindData();
            }
        }
        else
        { 
             //添加新的学费信息
            FormView1.ChangeMode(FormViewMode.Insert);
        }
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
    protected void bindData()
    {
        TuitionManage tMag = new TuitionManage();
        DataSet ds = tMag.GetTuitionInfo(tuitionID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grade = ds.Tables[0].Rows[0]["Grade"].ToString();
            term = ds.Tables[0].Rows[0]["PaymentTerm"].ToString();
            school = ds.Tables[0].Rows[0]["TeaSchoolID"].ToString();
        }
        FormView1.DataSource = ds.Tables[0];
        FormView1.DataBind();
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            TextBox tbName = (TextBox)FormView1.FindControl("tbName");
            TextBox tbStuID = (TextBox)FormView1.FindControl("tbStuID");
            TextBox tbGrade = (TextBox)FormView1.FindControl("tbGrade");
            TextBox tbSchoolName = (TextBox)FormView1.FindControl("tbSchool");
            TextBox tbTerm = (TextBox)FormView1.FindControl("tbTerm");
            DropDownList ddlTerm = (DropDownList)FormView1.FindControl("ddlTerm");
            TextBox tbTime = (TextBox)FormView1.FindControl("tbTime");
            TextBox tbMustMoney = (TextBox)FormView1.FindControl("tbMustPay");
            TextBox tbActualMoney = (TextBox)FormView1.FindControl("tbactualMoney");
            TextBox tbRemark = (TextBox)FormView1.FindControl("tbRemark");
            TuitionInfo tInfo = new TuitionInfo();
            TuitionManage tMag = new TuitionManage();
            if (FormView1.CurrentMode == FormViewMode.Edit)
            {
                //当前为编辑学费信息
                tInfo.TuitionID = tuitionID;
                tInfo.MustMoney = Convert.ToInt32(tbMustMoney.Text.Trim());
                tInfo.ActualMoney = Convert.ToInt32(tbActualMoney.Text.Trim());
                if (tbRemark.Text.Trim() != "")
                {
                    tInfo.Remark = tbRemark.Text.Trim();
                }
                if (tMag.UpdateTuitionInfo(tInfo) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功')</script>");
                    return;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败')</script>");
                    return;
                }
            }
            if (FormView1.CurrentMode == FormViewMode.Insert)
            {
                //当前为添加新的学费信息
                if (ddlTerm.SelectedIndex == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择学期')</script>");
                    return;
                }
                tInfo.StudID = tbStuID.Text.Trim();
                tInfo.PaymentTerm = ddlTerm.SelectedValue;
                if (isTimeValid(tbTime.Text.Trim()) == true)
                {
                    tInfo.PaymentTime = tbTime.Text.Trim();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('缴费时间不合法')</script>");
                    return;
                }
                tInfo.MustMoney = Convert.ToDouble(tbMustMoney.Text.Trim());
                tInfo.ActualMoney = Convert.ToDouble(tbActualMoney.Text.Trim());
                tInfo.Remark = tbRemark.Text.Trim();
                //判断该账号是否属于MSE部门
                RoleManage rMag = new RoleManage();
                DataSet ds = rMag.GetUsersFromMSE(tInfo.StudID);
                if ( ds.Tables[0].Rows.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该账号不属于MSE部门，保存失败')</script>");
                    return;
                }
                //判断该学生账号是否存在
                if (tInfo.StudID.Length != 10)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该账号不是学生账号，保存失败')</script>");
                    return;
                }
                //判断该账号，该学期的学费信息是否存在
                if(tMag.GetTuitionInfobyTermStu(tInfo.StudID, tInfo.PaymentTerm) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该账号该学期的学费信息已存在，保存失败')</script>");
                    return;
                }
                //保存新学费信息
                if (tMag.AddTuitionInfo(tInfo) == true)
                {
                    isOk = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功')</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败，请重试')</script>");
                }
            }
        }
    }
    public string GetCourseTime(object cTime)
    {
        if (cTime != null)
        {
            string courseTime = cTime.ToString().Substring(0, 4);
            int term = Convert.ToInt32(cTime.ToString().Substring(4, 1));
            if (term == 0)
            {
                courseTime = courseTime + "年秋";
            }
            else
            {
                courseTime = courseTime + "年春";
            }
            return courseTime;
        }
        return null;
    }
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (isEdit == true)
        {
            TextBox tbName = (TextBox)FormView1.FindControl("tbName");
            TextBox tbStuID = (TextBox)FormView1.FindControl("tbStuID");
            TextBox tbTime = (TextBox)FormView1.FindControl("tbTime");
            DropDownList ddlTerm = (DropDownList)FormView1.FindControl("ddlTerm");
            ddlTerm.Visible = false;
            tbName.Enabled = false;
            tbStuID.Enabled = false;
            ddlTerm.Enabled = false;
            tbTime.Enabled = false;
        }
        else
        {
            TextBox tbGrade = (TextBox)FormView1.FindControl("tbGrade");
            TextBox tbSchool = (TextBox)FormView1.FindControl("tbSchool");
            TextBox tbTerm = (TextBox)FormView1.FindControl("tbTerm");
            HtmlTableRow tr_grade = (HtmlTableRow)FormView1.FindControl("tr_grade");
            HtmlTableRow tr_school = (HtmlTableRow)FormView1.FindControl("tr_school");
            HtmlTableRow tr_name = (HtmlTableRow)FormView1.FindControl("tr_name");
            tbGrade.Visible = false;
            tbSchool.Visible = false;
            tbTerm.Visible = false;
            tr_grade.Visible = false;
            tr_school.Visible = false;
            tr_name.Visible = false;
        }
    }
    protected bool isTimeValid(string time)
    {
        try
        {
            Convert.ToDateTime(time);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void FormView1_PreRender(object sender, EventArgs e)
    {
        if (isOk == true)
        {
            TextBox tbStuID = (TextBox)FormView1.FindControl("tbStuID");
            DropDownList ddlTerm = (DropDownList)FormView1.FindControl("ddlTerm");
            TextBox tbTime = (TextBox)FormView1.FindControl("tbTime");
            TextBox tbMustMoney = (TextBox)FormView1.FindControl("tbMustPay");
            TextBox tbActualMoney = (TextBox)FormView1.FindControl("tbactualMoney");
            TextBox tbRemark = (TextBox)FormView1.FindControl("tbRemark");
            tbStuID.Text = "";
            ddlTerm.SelectedIndex = 0;
            tbTime.Text = "";
            tbMustMoney.Text = "";
            tbActualMoney.Text = "";
            tbRemark.Text = "";
        }
    }
}
