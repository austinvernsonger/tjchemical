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

public partial class Engineering_TeacherBackMag_MyStudents : System.Web.UI.Page
{
    private string teacherID;
    private DocumentManage dMage = new DocumentManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            BindMyStudent();
        }
        if (IsPostBack)
        {
            CreateGridControl();
        }
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
            ddlSchool.SelectedIndex = 0;
        }
        else
        {
            ddlSchool.Items.Clear();
        }
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (tbName.Text.Trim() != "")
        {
            qInfo.Name = tbName.Text;
        }
        if (ddlGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade.SelectedValue;
        }
        if (ddlSchool.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool.SelectedValue;
        }
        ViewState["qInfo"] = qInfo;
        BindMyStudent();
    }
    protected void gvMyStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string stuId = gvMyStudents.DataKeys[e.Row.RowIndex].Value.ToString();
            DataSet ds = dMage.GetAttachment(stuId, 1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                LinkButton lbOpenSpeech = new LinkButton();
                lbOpenSpeech.ID = "lbOpenSpeech";
                lbOpenSpeech.Text = "已提交";
                lbOpenSpeech.ForeColor = System.Drawing.Color.Blue;
                lbOpenSpeech.CommandName = "cmdOpenSpeech";
                lbOpenSpeech.CommandArgument = stuId;
                e.Row.Cells[6].Controls.Add(lbOpenSpeech);

            }
            else
            {
                Label lblSpeech = new Label();
                lblSpeech.ID = "lblSpeech";
                lblSpeech.Text = "未提交";
                lblSpeech.ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[6].Controls.Add(lblSpeech);
            }
            DataSet dsOutTeacher = dMage.GetAttachment(stuId, 4);
            if (dsOutTeacher.Tables[0].Rows.Count > 0)
            {
                LinkButton lbOutTeacher = new LinkButton();
                lbOutTeacher.ID = "lbOutTeacher";
                lbOutTeacher.Text = "已提交";
                lbOutTeacher.ForeColor = System.Drawing.Color.Blue; 
                lbOutTeacher.CommandName = "cmdOutTeacher";
                lbOutTeacher.CommandArgument = stuId;
                e.Row.Cells[7].Controls.Add(lbOutTeacher);
            }
            else
            {
                Label lblOutTeacher = new Label();
                lblOutTeacher.ID = "lblOutTeacher";
                lblOutTeacher.Text = "未提交";
                lblOutTeacher.ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[7].Controls.Add(lblOutTeacher);
            }
            DataSet dsMidForm = dMage.GetAttachment(stuId, 2);
            if (dsMidForm.Tables[0].Rows.Count > 0)
            {
                LinkButton lbMidForm = new LinkButton();
                lbMidForm.ID = "lbMidForm";
                lbMidForm.Text = "已提交";
                lbMidForm.ForeColor = System.Drawing.Color.Blue;
                lbMidForm.CommandName = "cmdMidForm";
                lbMidForm.CommandArgument = stuId;
                e.Row.Cells[8].Controls.Add(lbMidForm);
            }
            else
            {
                Label lblMidForm = new Label();
                lblMidForm.ID = "lblMidForm";
                lblMidForm.Text = "未提交";
                lblMidForm.ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[8].Controls.Add(lblMidForm);
            }
            DataSet dsPaper = dMage.GetAttachment(stuId, 3);
            if (dsPaper.Tables[0].Rows.Count > 0)
            {
                LinkButton lbPaper = new LinkButton();
                lbPaper.ID = "lbPaper";
                lbPaper.Text = "已提交";
                lbPaper.ForeColor = System.Drawing.Color.Blue;
                lbPaper.CommandName = "cmdPaper";
                lbPaper.CommandArgument = stuId;
                e.Row.Cells[9].Controls.Add(lbPaper);
            }
            else
            {
                Label lblPaper = new Label();
                lblPaper.ID = "lblPaper";
                lblPaper.Text = "未提交";
                lblPaper.ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[9].Controls.Add(lblPaper);
            }
        }
    }
    protected void BindMyStudent()
    {
        if (ViewState["qInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStudentsInfoByteaId(teacherID, qInfo);
            gvMyStudents.DataSource = ds.Tables[0];
            gvMyStudents.DataBind();
        }
        else
        {
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStudentsInfoByteaIdWithNoneQuery(teacherID);
            gvMyStudents.DataSource = ds.Tables[0];
            gvMyStudents.DataBind();
        }
    }  
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
    protected void CreateGridControl()
    {
        foreach (GridViewRow row in gvMyStudents.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string stuId = gvMyStudents.DataKeys[row.RowIndex].Value.ToString();
                DataSet ds = dMage.GetAttachment(stuId, 1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LinkButton lbOpenSpeech = new LinkButton();
                    lbOpenSpeech.ID = "lbOpenSpeech";
                    lbOpenSpeech.Text = "已提交";
                    lbOpenSpeech.ForeColor = System.Drawing.Color.Blue;
                    lbOpenSpeech.CommandName = "cmdOpenSpeech";
                    lbOpenSpeech.CommandArgument = stuId;
                    row.Cells[6].Controls.Add(lbOpenSpeech);
                }
                else
                {
                    Label lblSpeech = new Label();
                    lblSpeech.ID = "lblSpeech";
                    lblSpeech.Text = "未提交";
                    lblSpeech.ForeColor = System.Drawing.Color.Red;
                    row.Cells[6].Controls.Add(lblSpeech);
                }
                DataSet dsOutTeacher = dMage.GetAttachment(stuId, 4);
                if (dsOutTeacher.Tables[0].Rows.Count > 0)
                {
                    LinkButton lbOutTeacher = new LinkButton();
                    lbOutTeacher.ID = "lbOutTeacher";
                    lbOutTeacher.Text = "已提交";
                    lbOutTeacher.ForeColor = System.Drawing.Color.Blue;
                    lbOutTeacher.CommandName = "cmdOutTeacher";
                    lbOutTeacher.CommandArgument = stuId;
                    row.Cells[7].Controls.Add(lbOutTeacher);
                }
                else
                {
                    Label lblOutTeacher = new Label();
                    lblOutTeacher.ID = "lblOutTeacher";
                    lblOutTeacher.Text = "未提交";
                    lblOutTeacher.ForeColor = System.Drawing.Color.Red;
                    row.Cells[7].Controls.Add(lblOutTeacher);
                }
                DataSet dsMidForm = dMage.GetAttachment(stuId, 2);
                if (dsMidForm.Tables[0].Rows.Count > 0)
                {
                    LinkButton lbMidForm = new LinkButton();
                    lbMidForm.ID = "lbMidForm";
                    lbMidForm.Text = "已提交";
                    lbMidForm.ForeColor = System.Drawing.Color.Blue;
                    lbMidForm.CommandName = "cmdMidForm";
                    lbMidForm.CommandArgument = stuId;
                    row.Cells[8].Controls.Add(lbMidForm);
                }
                else
                {
                    Label lblMidForm = new Label();
                    lblMidForm.ID = "lblMidForm";
                    lblMidForm.Text = "未提交";
                    lblMidForm.ForeColor = System.Drawing.Color.Red;
                    row.Cells[8].Controls.Add(lblMidForm);
                }
                DataSet dsPaper = dMage.GetAttachment(stuId, 3);
                if (dsPaper.Tables[0].Rows.Count > 0)
                {
                    LinkButton lbPaper = new LinkButton();
                    lbPaper.ID = "lbPaper";
                    lbPaper.Text = "已提交";
                    lbPaper.ForeColor = System.Drawing.Color.Blue;
                    lbPaper.CommandName = "cmdPaper";
                    lbPaper.CommandArgument = stuId;
                    row.Cells[9].Controls.Add(lbPaper);
                }
                else
                {
                    Label lblPaper = new Label();
                    lblPaper.ID = "lblPaper";
                    lblPaper.Text = "未提交";
                    lblPaper.ForeColor = System.Drawing.Color.Red;
                    row.Cells[9].Controls.Add(lblPaper);
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void gvMyStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = null;
        if (e.CommandName == "cmdOpenSpeech")
        {
            string stuid = e.CommandArgument.ToString();
            ds = dMage.GetAttachment(stuid, 1);
        }
        if (e.CommandName == "cmdOutTeacher")
        {
            string stuid = e.CommandArgument.ToString();
            ds = dMage.GetAttachment(stuid, 4);
        }
        if (e.CommandName == "cmdMidForm")
        {
            string stuid = e.CommandArgument.ToString();
            ds = dMage.GetAttachment(stuid, 2);
        }
        if (e.CommandName == "cmdPaper")
        {
            string stuid = e.CommandArgument.ToString();
            ds = dMage.GetAttachment(stuid, 3);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件不存在')</script>");
            return;
        }
        string path = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
        string name = ds.Tables[0].Rows[0]["AttachName"].ToString();
        string extension = Path.GetExtension(path);
        name = name + extension;
        if (ds.Tables[0].Rows.Count > 0)
        {
            FileInfo file = new FileInfo(Server.MapPath(path));
            downLoadFile(file, name);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件不存在')</script>");
            return;
        }
    }
    protected void downLoadFile(FileInfo file, string name)
    {
        if (file.Exists == true)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AppendHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('文件不存在')</script>");
        }
    } 
}
