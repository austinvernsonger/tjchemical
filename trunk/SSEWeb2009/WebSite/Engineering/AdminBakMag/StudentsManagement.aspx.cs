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
using System.IO;
using System.Collections.Generic;

public partial class Engineering_AdminBakMag_StudentsManagement : System.Web.UI.Page
{
    private int num = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (!IsPostBack)
        {
            bindGrade();
            bindData();
            TabContainer1.ActiveTabIndex = 0;
        }
    }
    protected void GradeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GradeList.SelectedIndex == 0)
        {
            TSchoolingList.Items.Clear();
            TSchoolingList.Items.Add("--请选择教学点--");
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (GradeList.SelectedIndex != 0)
        {
            qInfo.Grade = GradeList.SelectedValue;
        }
        if (TSchoolingList.SelectedIndex != 0)
        {
            qInfo.TSchoolID = TSchoolingList.SelectedValue;
        }
        if (tbStuID.Text.Trim() != "")
        {
            qInfo.AccountID = tbStuID.Text.Trim().Replace("'","''");
        }
        ViewState["QInfo"] = qInfo;
        bindData(); 
    }
    public string FormatGrade(string sgrade)
    {
        string nGrade = sgrade.Substring(0, 4);
        return nGrade + "级";
    }
    protected void lbRegistForm_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath("~/Engineering/Resources/Files/学生登记表.xls"));
        if (file.Exists)
        {
            //文件存在
            FileManage.DownLoadFile(file);
        }
        else
        {
            // 文件不存在
        }
    }
    protected void tbSubmit_Click(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择学生所属年级')</script>", false);
            return;
        }
        if (ddlSchool.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择学生所属教学点')</script>", false);
            return;
        }
        if (fuStudentsInfo.HasFile)
        {
            string fileName = fuStudentsInfo.PostedFile.FileName;
            string extension = Path.GetExtension(fileName);
            if (extension != ".xls" && extension != ".xlsx")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('只支持excel格式')</script>", false);
                return;
            }
            ExcelEngine ee = new ExcelEngine();
            DataSet ds = ee.WriteToDataset(fileName);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                lblGrade.Text = "年级："+ddlGrade.SelectedValue+" 教学点："+ddlSchool.SelectedItem.Text;
                string message = "确认后请点击确认按钮提交信息";
                lblMessage.Text = message;
                div_stuinfo.Visible = true;
                ViewState["dsStuInfo"] = ds;
                bindStuInfoConfirm();
            }
            else
            {
                //上传失败
                div_stuinfo.Visible = false;
                lblMessage.Text = "";
                gvFileUplaodStu.DataSource =null;
                gvFileUplaodStu.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('学生信息导入失败！')</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择学生信息登记表')</script>", false);
        }
    }
    protected void gvFileUplaodStu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
        if (e.Row.DataItem != null)
        {
            if (e.Row.RowState == DataControlRowState.Alternate || e.Row.RowState == DataControlRowState.Normal)
            {
                Label lblStuNum = (Label)e.Row.FindControl("lblStuNumv");
                Label lblGender = (Label)e.Row.FindControl("lblGenderv");
                Label lblSchooling = (Label)e.Row.FindControl("lblSchoolingv");
                Label lblDegree = (Label)e.Row.FindControl("lblDegreev");
                Label lblPassword = (Label)e.Row.FindControl("lblPasswordv");
                string stuID = lblStuNum.Text.Trim();
                string gender = lblGender.Text.Trim();
                string degree = lblDegree.Text.Trim();
                string password = lblPassword.Text.Trim();       
                //判断该学号是否存在
                StudentManage sMag = new StudentManage();
                if (sMag.GetAccountByStuID(stuID) == true)
                { 
                    //该账号已存在
                    num++;
                    e.Row.BackColor = System.Drawing.Color.LightSkyBlue;
                }
                //判断学号是否合法
                if (stuID.Length != 10 || IsNumberValid(stuID)==false)
                {
                    num++;
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
               //判断性别输入是否合法
                if (string.Compare(gender, "男") != 0 && string.Compare(gender, "女") != 0)
                {
                    num++;
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                }
                //判断学位类别输入是否合法
                if (degree.Contains("单证") == true)
                {
                    lblDegree.Text = "单证硕士";
                }
                else if (degree.Contains("双证") == true)
                {
                    lblDegree.Text = "双证硕士";
                }
                else
                {
                    num++;
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                }
                //判断密码是否为空
                if (password.Length == 0)
                {
                    num++;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                }
                if (num > 0)
                {
                    ViewState["isOk"] = false;
                }
                else
                {
                    ViewState["isOk"] = true;
                }
            }
        }
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        gvFileUplaodStu.DataSource = null;
        gvFileUplaodStu.DataBind();
        lblMessage.Text = "";
        div_stuinfo.Visible = false;
        ddlGrade.SelectedIndex = 0;
        ddlSchool.SelectedIndex = 0;
        lblGrade.Text = "";
        lblMessage.Text = "";
    }
    protected void btConfirm_Click(object sender, EventArgs e)
    {
        if (ViewState["isOk"] != null && (bool)ViewState["isOk"] == true)
        {
            DataSet ds = (DataSet)ViewState["dsStuInfo"];
            StudentManage sMag = new StudentManage();
            QueryInfo qInfo = new QueryInfo();
            qInfo.TSchoolID = ddlSchool.SelectedValue;
            qInfo.Grade = ddlGrade.SelectedValue;
            sMag.DS = ds;
            if (sMag.TranStuInfoDatabase(qInfo) == true)
            {
                div_stuinfo.Visible = false;
                lblGrade.Text = "";
                lblMessage.Text = "";
                gvFileUplaodStu.DataSource = null;
                gvFileUplaodStu.DataBind();
                ddlGrade.SelectedIndex = 0;
                ddlSchool.SelectedIndex = 0;
                ViewState["dsStuInfo"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('学生信息上传成功！')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('学生信息上传失败，请重试')</script>", false);
            }
        }
        else {
            //验证不通过
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('存在不合法的信息，请更正后，重新上传')</script>", false);
            return;
        }
    }
    protected void gvStudentsInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string studentID = gvStudentsInfo.DataKeys[e.Row.RowIndex].Value.ToString();
            ImageButton lnb = (ImageButton)e.Row.FindControl("lnbView");
            lnb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + studentID + "',650,500)");
            ImageButton lnbModity = (ImageButton)e.Row.FindControl("lnbModify");
            lnbModity.PostBackUrl = "AddNewStudent.aspx?id=" + studentID;
            ImageButton lnbDelete = (ImageButton)e.Row.FindControl("lnbDelete");
            lnbDelete.Attributes.Add("onclick", "javascript:return confirm('你确认要删除 "+e.Row.Cells[2].Text+" 信息吗？')");
        }
    }
    protected void gvStudentsInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudentsInfo.PageIndex = e.NewPageIndex;
        bindData();
    }
    protected void bindData()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = null;
        if (ViewState["QInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["QInfo"];
            ds = sMag.GetStusInfo(qInfo);
        }
        else
        {
            ds = sMag.GetStusInfoWithNull();       
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            btNewStudent.Visible = true;
            btNewStudent.Enabled = true;
        }
        else
        {
            btNewStudent.Visible = false;
            btNewStudent.Enabled = false;
        }
        gvStudentsInfo.DataSource = ds.Tables[0];
        gvStudentsInfo.DataBind();
    }
    protected void bindGrade()
    {
        System.DateTime theDate = System.DateTime.Now;
        ddlGrade.Items.Clear();
        ddlGrade.Items.Add("请选择年级");
        for (int i = theDate.Year - 3; i < theDate.Year + 2; i++)
        {
            ddlGrade.Items.Add(i.ToString()+"级");
        }
    }
    protected void lbRegistForm_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(lbRegistForm);
    }
    protected void tbSubmit_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(tbSubmit);
    }
    protected void bindStuInfoConfirm()
    {
        if (ViewState["dsStuInfo"] != null)
        {
            DataSet ds = (DataSet)ViewState["dsStuInfo"];
            gvFileUplaodStu.DataSource = ds.Tables[0];
            gvFileUplaodStu.DataBind();
        }
    }
    protected void gvFileUplaodStu_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFileUplaodStu.EditIndex = e.NewEditIndex;
        bindStuInfoConfirm();
    }
    protected void gvFileUplaodStu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFileUplaodStu.EditIndex = -1;
        bindStuInfoConfirm();
    }
    protected void gvFileUplaodStu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["dsStuInfo"] != null)
        {
            DataSet ds = (DataSet)ViewState["dsStuInfo"];
            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.AcceptChanges();
            ViewState["dsStuInfo"] = ds;
            bindStuInfoConfirm();
        }
    }
    protected void gvFileUplaodStu_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (ViewState["dsStuInfo"] != null)
        {
            TextBox tbName = (TextBox)gvFileUplaodStu.Rows[e.RowIndex].FindControl("tbNamei");
            TextBox tbStuNum = (TextBox)gvFileUplaodStu.Rows[e.RowIndex].FindControl("tbStuNumi");
            TextBox tbGender = (TextBox)gvFileUplaodStu.Rows[e.RowIndex].FindControl("tbGenderi");
            TextBox tbSchooling = (TextBox)gvFileUplaodStu.Rows[e.RowIndex].FindControl("tbSchoolingi");
            TextBox tbDegree = (TextBox)gvFileUplaodStu.Rows[e.RowIndex].FindControl("tbDegreei");
            TextBox tbPassword = (TextBox)gvFileUplaodStu.Rows[e.RowIndex].FindControl("tbPasswordi");
            DataSet ds = (DataSet)ViewState["dsStuInfo"];
            DataRow dr = ds.Tables[0].Rows[e.RowIndex];
            dr["sName"] = tbName.Text.Trim();
            dr["sStuid"] = tbStuNum.Text.Trim();
            dr["sGender"] = tbGender.Text.Trim();
            dr["sSchooling"] = tbSchooling.Text.Trim();
            dr["sDegree"] = tbDegree.Text.Trim();
            dr["sPassword"] = tbPassword.Text.Trim();
            ds.AcceptChanges();
            ViewState["dsStuInfo"] = ds;
            gvFileUplaodStu.EditIndex = -1;
            bindStuInfoConfirm();
        }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            bindData();
            GradeList.DataBind();
        }
    }
    protected bool IsNumberValid(string num)
    {
        try
        {
            Convert.ToInt32(num);
            return true;
        }
        catch {
            return false;
        }
    }
    protected void btnQuery_PreRender(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnQuery);
    }
    protected void gvStudentsInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDelete")
        {
            string studentID = e.CommandArgument.ToString();
            StudentManage sMag = new StudentManage();
            if (sMag.DeleteInformationsRelatedToStudentByTran(studentID) == true)
            {
                bindData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('删除失败，请重试')</script>", false);
            }
        }
    }

    protected void btDeleteStudents_Click(object sender, EventArgs e)
    {
        int num = 0;
        List<string> indexList = new List<string>();//保存将要删除的记录
        StudentManage sMag = new StudentManage();
        for (int i = 0; i < gvStudentsInfo.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvStudentsInfo.Rows[i].FindControl("cbSelect");
            if (cb.Checked == true)
            {
                num++;
                indexList.Add(gvStudentsInfo.DataKeys[i].Value.ToString());
            }
        }
        if (num == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择要删除的项')</script>", false);
            return;
        }
        int count = indexList.Count;
        for (int i = 0; i < count; i++)
        {
            sMag.DeleteInformationsRelatedToStudentByTran(indexList[i]);
        }
        bindData();
    }
}
