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

public partial class Engineering_AdminBakMag_CourseScoreDetails : System.Web.UI.Page
{

    //private DataSet _ds;
    private bool status = false;
    List<string> stu = new List<string>();
  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null && Request["id"] != "")
            {
                int courseid = Convert.ToInt32(Request["id"]);
                ViewState["CourseID"] = courseid;
                BindGvScoreDetails();
            }
        }
    }
    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
        if (term == 0)
        {
            courseTime = courseTime + "年秋学期";
        }
        else
        {
            courseTime = courseTime + "年春学期";
        }
        return courseTime;
    }
    protected void BindGvScoreDetails()
    {
        int courseid = (int)ViewState["CourseID"];

        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetChoosingCourseInfoByCourID(courseid);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblGrade.Text = "年级：" + ds.Tables[0].Rows[0]["Grade"].ToString();
            lblSchool.Text = "教学点：" + ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();
            lblCourseTime.Text = GetCourseTime(ds.Tables[0].Rows[0]["CourseTime"].ToString()) ;
            lblCourseName.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
            ViewState["_ds"] = ds;
        }

        gvScoreDetails.DataSource = ds.Tables[0];
        gvScoreDetails.DataBind();
    }
    protected void lbCheckScore_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath("~/Engineering/Resources/Files/核对成绩专用表.xls"));

        if (file.Exists)
        {
            FileManage.DownLoadFile(file);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('文件不存在！')</script>");
        }
    }
    protected void gvScoreDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            if (status == true)
            {
                if (stu.Count > 0)
                {
                    for (int i = 0; i < stu.Count; i++)
                    {
                        if (string.Compare(e.Row.Cells[0].Text.Trim(), stu[i]) == 0)
                        {
                            e.Row.BackColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
    }
    protected void btClose_Click(object sender, EventArgs e)
    {
        //if (ViewState["num"] == null)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('发布失败，请先确认成绩')</script>", false);
        //    return;
        //}
        //int num = Convert.ToInt32(ViewState["num"]);
        //if (num != gvScoreDetails.Rows.Count)
        //{ 
        //    //存在课程成绩还没有确认
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('发布失败，有课程成绩还没有确认')</script>", false);
        //    return;
        //}
        CourseManage cMag = new CourseManage();
        DataSet ds = null;
        int num = 0;
        if(ViewState["CourseID"]  != null)
        {
            //CourseManage cMag = new CourseManage();
            int courseID = (int)ViewState["CourseID"] ;
            for (int i = 0; i < gvScoreDetails.Rows.Count; i++)
            {
                string studentID = gvScoreDetails.DataKeys[i].Value.ToString();
                ds = cMag.GetRecordFromExamResult(studentID, courseID);
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsOk"]) == 2)
                {
                    num++;
                }
            }
            if (num != gvScoreDetails.Rows.Count)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('发布失败，有课程成绩还没有确认')</script>", false);
                return;
            }
            try
            {
                for (int i = 0; i < gvScoreDetails.Rows.Count; i++)
                {
                    string studentID = gvScoreDetails.DataKeys[i].Value.ToString();
                    cMag.updateCourseConfirmStatus(courseID, studentID, 1);
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('确认成功')</script>");
                btClose.Enabled = false;
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('确认失败，请重试！')</script>");
                return;
            }

        }
    }
    protected void gvScoreDetails_DataBound(object sender, EventArgs e)
    {
        int num = 0;//标记
        int flag = 0;
        int courseID = Convert.ToInt32(ViewState["CourseID"]);
        CourseManage cMag = new CourseManage();
        DataSet ds = null;
        for (int i = 0; i < gvScoreDetails.Rows.Count; i++)
        { 
            string studentID = gvScoreDetails.DataKeys[i].Value.ToString();
            ds = cMag.GetRecordFromExamResult(studentID, courseID);
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsOk"]) == 1)
            {
                flag++;
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsOk"]) == 2)
            {
                CheckBox cbConfirm = (CheckBox)gvScoreDetails.Rows[i].FindControl("cbConfirm");
                cbConfirm.Checked = true;
                gvScoreDetails.Rows[i].BackColor = System.Drawing.Color.LightBlue;
                num++;
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsOk"]) == 3)
            {
                CheckBox cbNoConfirm = (CheckBox)gvScoreDetails.Rows[i].FindControl("cbNoConfirm");
                cbNoConfirm.Checked = true;
                gvScoreDetails.Rows[i].BackColor = System.Drawing.Color.Red;
            }
        }
        if (flag == gvScoreDetails.Rows.Count)
        {
            btClose.Visible = false;
            gvScoreDetails.Columns[4].Visible = false;
            gvScoreDetails.Columns[5].Visible = false;
        }
        else
        {
            ViewState["num"] = num;
        }
    }
    protected void cbConfirm_CheckedChanged(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ViewState["CourseID"]);
        CourseManage cMag = new CourseManage();
        for (int i = 0; i < gvScoreDetails.Rows.Count; i++)
        {
            string studentID = gvScoreDetails.DataKeys[i].Value.ToString();
            CheckBox cbConfirm = (CheckBox)gvScoreDetails.Rows[i].FindControl("cbConfirm");
            CheckBox cbNoConfirm = (CheckBox)gvScoreDetails.Rows[i].FindControl("cbNoConfirm");
            if (cbConfirm.Checked == true)
            {
                cbNoConfirm.Checked = false;
                gvScoreDetails.Rows[i].BackColor = System.Drawing.Color.LightBlue;
                cMag.updateCourseConfirmStatus(courseID, studentID, 2);
            }
            else
            {
                if (cbNoConfirm.Checked == false)
                {
                    gvScoreDetails.Rows[i].BackColor = System.Drawing.Color.White;
                    cMag.updateCourseConfirmStatus(courseID, studentID, 0);
                }
            }
        }
    }
    protected void cbNoConfirm_CheckedChanged(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ViewState["CourseID"]);
        CourseManage cMag = new CourseManage();
        for (int i = 0; i < gvScoreDetails.Rows.Count; i++)
        {
            string studentID = gvScoreDetails.DataKeys[i].Value.ToString();
            CheckBox cbNoConfirm = (CheckBox)gvScoreDetails.Rows[i].FindControl("cbNoConfirm");
            CheckBox cbConfirm = (CheckBox)gvScoreDetails.Rows[i].FindControl("cbConfirm");
            if (cbNoConfirm.Checked == true)
            {    
                cbConfirm.Checked = false;
                gvScoreDetails.Rows[i].BackColor = System.Drawing.Color.Red;
                cMag.updateCourseConfirmStatus(courseID, studentID, 3); 
            }
            else
            {
                if (cbConfirm.Checked == false)
                {
                    gvScoreDetails.Rows[i].BackColor = System.Drawing.Color.White;
                    cMag.updateCourseConfirmStatus(courseID, studentID, 2);
                }
            }
        }
    }
}
