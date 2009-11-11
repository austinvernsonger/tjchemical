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

public partial class Engineering_AdminBakMag_TutionInfoManage : System.Web.UI.Page
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
            TabContainer1.ActiveTabIndex = 0;
            bindgvTutionInfo();
        }
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
        }

    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        TuitionInfo tInfo = new TuitionInfo();
        if (ddlGrade.SelectedIndex != 0)
        {
            tInfo.Grade = ddlGrade.SelectedValue;
        }
        if (ddlSchool.SelectedIndex != 0)
        {
            tInfo.TSchoolID =ddlSchool.SelectedValue;
        }
        if (ddlTerm1.SelectedIndex != 0)
        {
            tInfo.PaymentTerm = ddlTerm1.SelectedValue;
        }
        ViewState["tInfo"] = tInfo;
        ddlGrade.SelectedIndex = 0;
        ddlTerm1.SelectedIndex = 0;
        bindgvTutionInfo();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath("~/Engineering/Resources/Files/学费登记表.xls"));

        if (file.Exists)
        {
            FileManage.DownLoadFile(file);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件不存在！')</script>");
        }
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        if (ddlTerm.SelectedIndex == 0)
        {
            Response.Write("<script>alert('请选择缴费学期！')</script>");
            return;
        }
        if (FileUpload1.HasFile)
        {
            ViewState["isOk"] = null;
            string term = ddlTerm.SelectedValue;
            ViewState["term"] = term;
            string file = FileUpload1.PostedFile.FileName;
            string extension = Path.GetExtension(file);
            if (extension != ".xls" && extension != ".xlsx")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('只支持excel格式')</script>", false);
                return;
            }
            ddlTerm.SelectedIndex = 0;
            ExcelEngine ee = new ExcelEngine();
            DataSet ds = ee.WriteTutionToDataset(file);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                div_tuition.Visible = true;
                string message = "当前有" + count + "项信息需要上传，请确认后点击下方的提交按钮";
                lblResult.Text = message;
                lblResult.Visible = true;
                ViewState["dstuition"] = ds;
                bindgvTuitionConfirm();  
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上传失败，请重试！')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择学费信息表！')</script>");
        }
    }
    protected void bindgvTutionInfo()
    {
        TuitionInfo tInfo = (TuitionInfo)ViewState["tInfo"];
        TuitionManage tMag = new TuitionManage();
        DataSet ds = null;
        if (ViewState["tInfo"] != null)
        {
            //查询的结果
            ds = tMag.GetTuitionInfo(tInfo);
            gvTutionInfo.DataSource = ds.Tables[0];
            gvTutionInfo.DataBind();
        }
        else
        {
            //首次加载
            ds = tMag.GetTuitionInfo();
            gvTutionInfo.DataSource = ds.Tables[0];
            gvTutionInfo.DataBind();
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            btDelete.Visible = false;
            btDelete.Enabled = false;
            btAddNewTuition.Visible = false;
            btAddNewTuition.Enabled = false;
        }
        else
        {
            btDelete.Visible = true;
            btDelete.Enabled = true;
            btAddNewTuition.Visible = true;
            btAddNewTuition.Enabled = true;
        }
    }
    protected void gvTutionInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int tuitionID = Convert.ToInt32(gvTutionInfo.DataKeys[e.Row.RowIndex].Value);
            ImageButton lnbEdit = (ImageButton)e.Row.FindControl("lnbEdit");
            lnbEdit.PostBackUrl = "EditTuitionDetails.aspx?id="+tuitionID;
            DataRowView drv = (DataRowView)e.Row.DataItem;
            ((ImageButton)e.Row.Cells[9].FindControl("lnbDelete")).Attributes.Add("onclick","javascript:return confirm('你确认要删除这条缴费信息吗？')");
            if (Convert.ToDouble(drv["ActualMoney"]) != Convert.ToDouble(drv["MustMoney"]))
            {
                e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        int num = 0;
        List<int> indexList = new List<int>();//保存将要删除的记录
        TuitionManage tMag = new TuitionManage();
        for (int i = 0; i < gvTutionInfo.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvTutionInfo.Rows[i].FindControl("cbCheck");
            if (cb.Checked == true)
            {
                num++;
                indexList.Add(Convert.ToInt32(gvTutionInfo.DataKeys[i].Value));
            }
        }
        if (num == 0)
        {
            Response.Write("<script>alert('请选择要删除的项')</script>");
            return;
        }
        int count = indexList.Count;
        for(int i=0; i<count ; i++)
        {
             tMag.DeleteTutionInfoByID(indexList[i]);
        }
        bindgvTutionInfo();
    }
    protected void gvTutionInfo_PreRender(object sender, EventArgs e)
    {

    }
    protected void gvTutionInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }
    protected void gvTutionInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTutionInfo.PageIndex = e.NewPageIndex;
        bindgvTutionInfo();
    }
    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
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
    protected void gvTuitionConfirm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string term = "";
            if (ViewState["term"] != null)
            {
                term = ViewState["term"].ToString();
            }  
            e.Row.Cells[1].Text = GetCourseTime(term.Trim());
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label lblStuNum = (Label)e.Row.FindControl("lblStuNum1");
                Label lblAcutualMoney = (Label)e.Row.FindControl("lblAcutualMoney1");
                Label lblMustMoney = (Label)e.Row.FindControl("lblMustMoney");
                
                string tmpStuID = lblStuNum.Text.Trim();
                StudentManage sMag = new StudentManage();
                TuitionManage tMag = new TuitionManage();
                //判断该账号是否存在
                if (sMag.GetAccountByStuID(tmpStuID) == false)
                {
                    //该账号不存在
                    e.Row.BackColor = System.Drawing.Color.LightSkyBlue;
                    num++;
                }
                //判断该账号该学期的学费信息是否存在
                if (tMag.GetTuitionInfobyTermStu(tmpStuID, term.Trim()) == true)
                {
                    //该学费信息已存在
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                    num++;
                }
                //判断缴费金额是否合法
                if (isNumberic(lblAcutualMoney.Text.Trim()) == false)
                {
                    //实缴金额不为数字
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                    num++;
                }
                //判断缴费金额是否合法
                if (isNumberic(lblMustMoney.Text.Trim()) == false)
                {
                    //应缴金额不为数字
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                    num++;
                }
                //判断实缴金额是否大于应缴金额
                if (isNumberic(lblAcutualMoney.Text.Trim()) == true && isNumberic(lblMustMoney.Text.Trim()) == true)
                {
                    // 实缴金额
                    int aPayment = Convert.ToInt32(lblAcutualMoney.Text.Trim());
                    //应缴金额
                    int mustPayment = Convert.ToInt32(lblMustMoney.Text.Trim());
                    if (aPayment > mustPayment)
                    {
                        //实缴金额 大于 应缴金额
                        e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                        num++;
                    }
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
    protected bool isNumberic(string message)
    {
        //判断是否为整数字符串,如果转换出错表示该字符串不为数字
        int result;
        try
        {
            result = Convert.ToInt32(message);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        lblResult.Text = "";
        gvTuitionConfirm.DataSource = null;
        gvTuitionConfirm.DataBind();
        div_tuition.Visible = false;
        ViewState["dstuition"] = null;
    }
    protected void btConfirm_Click(object sender, EventArgs e)
    {
        if (ViewState["isOk"] != null && (bool)ViewState["isOk"] == true)
        {
            DataSet ds = (DataSet)ViewState["dstuition"];
            string term = ViewState["term"].ToString();
            TuitionManage tMag = new TuitionManage();
            if (true == tMag.AddNewTuition(term, ds))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('学费信息上传成功！')</script>");
                lblResult.Text = "";
                gvTuitionConfirm.DataSource = null;
                gvTuitionConfirm.DataBind();
                div_tuition.Visible = false;
                ViewState["tInfo"] = null;
                ViewState["dstuition"] = null;
                bindgvTutionInfo();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('学费信息上传失败，请重试！')</script>");
            }
        }
        else
        {
            //验证不通过
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上传数据不合法，请更正后重新上传！')</script>");
            return;
        }
       
    }
    protected void gvTutionInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDelete")
        {
            int tuitionID =Convert.ToInt32(e.CommandArgument);
            TuitionManage tMag = new TuitionManage();
            if (tMag.DeleteTutionInfoByID(tuitionID) == true)
            {
                bindgvTutionInfo();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败，请重试')</script>");
            }
        }
    }
    protected void gvTuitionConfirm_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTuitionConfirm.EditIndex = e.NewEditIndex;
        bindgvTuitionConfirm();
    }
    protected void bindgvTuitionConfirm()
    {
        if (ViewState["dstuition"] != null)
        {
            DataSet ds = (DataSet)ViewState["dstuition"];
            gvTuitionConfirm.DataSource = ds.Tables[0];
            gvTuitionConfirm.DataBind();
            
        }
    }
    protected void gvTuitionConfirm_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTuitionConfirm.EditIndex = -1;
        bindgvTuitionConfirm();
    }
    protected void gvTuitionConfirm_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (ViewState["dstuition"] != null)
        {
            TextBox tbStuNum = (TextBox)gvTuitionConfirm.Rows[e.RowIndex].FindControl("tbStuNum1");
            TextBox tbAcutualMoney = (TextBox)gvTuitionConfirm.Rows[e.RowIndex].FindControl("tbAcutualMoney1");
            TextBox tbMustMoney = (TextBox)gvTuitionConfirm.Rows[e.RowIndex].FindControl("tbMustMoney");
            TextBox tbRemark = (TextBox)gvTuitionConfirm.Rows[e.RowIndex].FindControl("tbRemark1");
            DataSet ds = (DataSet)ViewState["dstuition"];
            DataRow dr = ds.Tables[0].Rows[e.RowIndex];
            dr["stuid"] = tbStuNum.Text.Trim();
            dr["actualMoney"] = tbAcutualMoney.Text.Trim();
            dr["mustMoney"] = tbMustMoney.Text.Trim();
            dr["remark"] = tbRemark.Text.Trim();
            ds.AcceptChanges();
            ViewState["dstuition"] = ds;
            gvTuitionConfirm.EditIndex = -1;
            bindgvTuitionConfirm();
        }
    }
    protected void gvTuitionConfirm_DataBound(object sender, EventArgs e)
    {

    }
    protected void gvTuitionConfirm_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["dstuition"] != null)
        {
            DataSet ds = (DataSet)ViewState["dstuition"];
            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.AcceptChanges();
            ViewState["dstuition"] = ds;
            bindgvTuitionConfirm();
        }
    }
    protected void TabContainer1_PreRender(object sender, EventArgs e)
    {
    }
}
