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

public partial class Engineering_ChooseMyTutor : System.Web.UI.Page
{
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindAllddlData();
            bindgvStuTeahcerNum();
            StudentManage sMag = new StudentManage();
            TeachingAgendaManage taMag = new TeachingAgendaManage();
            DataSet ds = null;
            // 获得导师日程的开始时间和结束时间
            ds = taMag.GetTeaChooseAgenda(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string message = "";
                message = message + Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]).ToString("yyyy-MM-dd");
                message = message + " 到 " + Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]).ToString("yyyy-MM-dd");
                lblMessage.Text = "选导师系统的开放时间：" + message;
            }
            else
            {
                return;
            }
            ds = sMag.GetStuChooseTeacherInfo(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //表示已经选择了导师
                bindStuWill(ds);//绑定学生的志愿
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["TeaWill"]).ToString() == "0" &&
                    Convert.ToInt32(ds.Tables[0].Rows[1]["TeaWill"]).ToString() == "0" &&
                     Convert.ToInt32(ds.Tables[0].Rows[2]["TeaWill"]).ToString() == "0")
                {
                    btModify.Visible = true;
                    btOk.Visible = false;
                }
                else
                {
                    btModify.Visible = false;
                    btOk.Visible = false;
                }
                ddlFirst.Enabled = false;
                ddlSecond.Enabled = false;
                ddlThird.Enabled = false;
            }
            else
            { 
                //还没选择导师
                btModify.Visible = false;
            }
        }
    }
    protected void btOk_Click(object sender, EventArgs e)
    {
        lblFirst.Text = "";
        lblSecond.Text = "";
        lblThird.Text = "";
        Willing stuWill = new Willing();
        StudentManage sMag = new StudentManage();
        TeacherManage tMag = new TeacherManage();
        DataSet ds = null;
        if (ddlFirst.SelectedIndex == 0 || ddlSecond.SelectedIndex == 0 || ddlThird.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交失败，三个志愿都必须选！')</script>", false);
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('提交失败，三个志愿都必须选！')</script>");
            return;
        }
        if (ddlFirst.SelectedValue == ddlSecond.SelectedValue || ddlFirst.SelectedValue == ddlThird.SelectedValue
            || ddlSecond.SelectedValue == ddlThird.SelectedValue)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交失败，三个志愿必须都不一样！')</script>", false);
          //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('提交失败，三个志愿必须都不一样！')</script>");
            return;
        }
        else
        {
            stuWill.FirstTeaID = ddlFirst.SelectedValue.Trim();
            stuWill.SecondTeaID = ddlSecond.SelectedValue.Trim();
            stuWill.ThirdTeaID = ddlThird.SelectedValue.Trim();
        }
        ds = sMag.GetStuChooseTeacherInfo(studentID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //表示已经选择了导师
            if (tMag.AddTeacherStudentInfoByTran(studentID, stuWill) == true)
            {
                btModify.Visible = true;
                btOk.Visible = false;
                ddlFirst.Enabled = false;
                ddlSecond.Enabled = false;
                ddlThird.Enabled = false;
                bindgvStuTeahcerNum();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('保存成功')</script>");  
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('保存失败'')</script>", false);
            }
        }
        else
        {
            //还没有选择导师
            if (tMag.AddTeacherStudentInfo(studentID, stuWill) == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交成功！'')</script>", false);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('提交成功！')</script>");
                btModify.Visible = true;
                btOk.Visible = false;
                ddlFirst.Enabled = false;
                ddlSecond.Enabled = false;
                ddlThird.Enabled = false;
                bindgvStuTeahcerNum();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交失败！'')</script>", false);
             //   Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('提交失败！')</script>");
            }
        }
        
    }
    protected void btModify_Click(object sender, EventArgs e)
    {
        lblResult.Visible = false;
        btOk.Text = "保存";
        btOk.Visible = true;     
        btModify.Visible = false;
        ddlFirst.Enabled = true;
        ddlSecond.Enabled = true;
        ddlThird.Enabled = true;
    }
    protected void bindStuWill(DataSet ds)
    {
        if (ds.Tables[0].Rows.Count == 3)
        {
            // 三个不同的志愿
            string will1 = ds.Tables[0].Rows[0]["Will"].ToString();
            string teacher1 = ds.Tables[0].Rows[0]["TeacherID"].ToString().Trim();

            string will2 = ds.Tables[0].Rows[1]["Will"].ToString();
            string teacher2 = ds.Tables[0].Rows[1]["TeacherID"].ToString().Trim();

            string will3 = ds.Tables[0].Rows[2]["Will"].ToString();
            string teacher3 = ds.Tables[0].Rows[2]["TeacherID"].ToString().Trim();
            selectedWill(will1, teacher1);
            selectedWill(will2, teacher2);
            selectedWill(will3, teacher3);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交失败！'')</script>", false);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('提交失败！')</script>"); 
        }
    }
    protected void selectedWill(string will, string teacherID)
    {
        if (string.Compare(will, "1") == 0)
        {
            for (int i = 0; i < ddlFirst.Items.Count; i++)
            {
                if (string.Compare(ddlFirst.Items[i].Value.Trim(), teacherID) == 0)
                {
                    ddlFirst.Items[i].Selected = true;
                    break;
                }
            }
        }
        if (string.Compare(will, "2") == 0)
        {
            for (int i = 0; i < ddlSecond.Items.Count; i++)
            {
                if (string.Compare(ddlSecond.Items[i].Value.Trim(), teacherID) == 0)
                {
                    ddlSecond.Items[i].Selected = true;
                    break;
                }
            }
        }if (string.Compare(will, "3") == 0)
        {
            for (int i = 0; i < ddlThird.Items.Count; i++)
            {
                if (string.Compare(ddlThird.Items[i].Value.Trim(), teacherID) == 0)
                {
                    ddlThird.Items[i].Selected = true;
                    break;
                }
            }
        }
    }
    protected void bindAllddlData()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = tMag.GetAllTutorInfoList();
        ddlFirst.DataTextField = "UserName";
        ddlFirst.DataValueField = "UserID";
        ddlFirst.DataSource = ds.Tables[0];
        ddlFirst.DataBind();

        ddlSecond.DataTextField = "UserName";
        ddlSecond.DataValueField = "UserID";
        ddlSecond.DataSource = ds.Tables[0];
        ddlSecond.DataBind();

        ddlThird.DataTextField = "UserName";
        ddlThird.DataValueField = "UserID";
        ddlThird.DataSource = ds.Tables[0];
        ddlThird.DataBind();
    }
    protected void bindgvStuTeahcerNum()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = tMag.GetAllTutorInfo();
        gvStuTeacherNum.DataSource = ds.Tables[0];
        gvStuTeacherNum.DataBind();
    }
    protected void gvStuTeacherNum_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string teacherID = gvStuTeacherNum.DataKeys[e.Row.RowIndex].Value.ToString();
            StudentManage sMag = new StudentManage();
            int firstNum = sMag.GetStuChooseTeacherNumByWill(teacherID, studentID, "1");
            e.Row.Cells[1].Text = firstNum.ToString();
            int secondNum = sMag.GetStuChooseTeacherNumByWill(teacherID, studentID, "2");
            e.Row.Cells[2].Text = secondNum.ToString();
            int thirdNum = sMag.GetStuChooseTeacherNumByWill(teacherID, studentID, "3");
            e.Row.Cells[3].Text = thirdNum.ToString();
            e.Row.Cells[4].Text = (firstNum + secondNum + thirdNum).ToString();
        }
    }
}
