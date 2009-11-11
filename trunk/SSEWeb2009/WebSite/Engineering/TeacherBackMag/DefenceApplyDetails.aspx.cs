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

public partial class Engineering_TeacherBackMag_DefenceApplyDetails : System.Web.UI.Page
{
    private string stuID;
    private string _speachPath;
    private string _outTeacherPath;
    private string _midFormPath;
    private string _paperPath;
    private string _speachName;
    private string _outTeacherName;
    private string _midFormName;
    private string _paperName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (Request["id"] != null && Request["id"] != "")
        {
            stuID = Request["id"].ToString();
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStusInfo(stuID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dvDefenceDetails.DataSource = ds.Tables[0];
                dvDefenceDetails.DataBind();
            }
        }
    }
    protected void dvDefenceDetails_DataBound(object sender, EventArgs e)
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStuDefenceApplyCondition(stuID);
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 1)
                {
                    _speachName = ds.Tables[0].Rows[i]["AttachName"].ToString();
                    _speachPath = ds.Tables[0].Rows[i]["AttachNameUrl"].ToString();
                    Label lb = (Label)dvDefenceDetails.Rows[5].FindControl("lblSpeach");
                    LinkButton lbt = (LinkButton)dvDefenceDetails.Rows[5].FindControl("lbSpeach");
                    lb.Text = "已提交";
                    lb.ForeColor = System.Drawing.Color.Black;
                    lbt.Visible = true;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 2)
                {
                    _midFormName = ds.Tables[0].Rows[i]["AttachName"].ToString();
                    _midFormPath = ds.Tables[0].Rows[i]["AttachNameUrl"].ToString();
                    Label lb = (Label)dvDefenceDetails.Rows[7].FindControl("lblMidForm");
                    LinkButton lbt = (LinkButton)dvDefenceDetails.Rows[7].FindControl("lbMidForm");
                    lb.Text = "已提交";
                    lb.ForeColor = System.Drawing.Color.Black;
                    lbt.Visible = true;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 3)
                {
                    _paperName = ds.Tables[0].Rows[i]["AttachName"].ToString(); 
                    _paperPath = ds.Tables[0].Rows[i]["AttachNameUrl"].ToString();
                    Label lb = (Label)dvDefenceDetails.Rows[8].FindControl("lblPaper");
                    LinkButton lbt = (LinkButton)dvDefenceDetails.Rows[8].FindControl("lbPaper");
                    lb.Text = "已提交";
                    lb.ForeColor = System.Drawing.Color.Black;
                    lbt.Visible = true;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 4)
                {
                    _outTeacherName = ds.Tables[0].Rows[i]["AttachName"].ToString(); 
                    _outTeacherPath = ds.Tables[0].Rows[i]["AttachNameUrl"].ToString();
                    Label lb = (Label)dvDefenceDetails.Rows[6].FindControl("lblOutTeacher");
                    LinkButton lbt = (LinkButton)dvDefenceDetails.Rows[6].FindControl("lbOutTeacher");
                    lb.Text = "已提交";
                    lb.ForeColor = System.Drawing.Color.Black;
                    lbt.Visible = true;
                }
            }
        }
    }
    protected void lbSpeach_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath(_speachPath));
        if (file.Exists)
        {
            string extension = Path.GetExtension(Server.MapPath(_speachPath));
            string name = _speachName + extension;
            downLoadFile(file, name);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('文件不存在！')</script>");
        }
    }
    protected void lbOutTeacher_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath(_outTeacherPath));
        if (file.Exists)
        {
            string extension = Path.GetExtension(Server.MapPath(_outTeacherPath));
            string name = _outTeacherName + extension;
            downLoadFile(file, name);
            FileManage.DownLoadFile(file);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('文件不存在！')</script>");
        }
    }
    protected void lbMidForm_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath(_midFormPath));
        if (file.Exists)
        {
            string extension = Path.GetExtension(Server.MapPath(_midFormPath));
            string name = _midFormName + extension;
            downLoadFile(file, name);
            FileManage.DownLoadFile(file);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('文件不存在！')</script>");
        }
    }
    protected void lbPaper_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath(_paperPath));
        if (file.Exists)
        {
            string extension = Path.GetExtension(Server.MapPath(_paperPath));
            string name = _paperName + extension;
            downLoadFile(file, name);
            FileManage.DownLoadFile(file);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('文件不存在！')</script>");
        }
    }
    protected void tbConfirm_Click(object sender, EventArgs e)
    {
        int res = 0;
        if (rbAgree.Checked == true)
        {
            res = 1;
        }
        else
        {
            res = 2;
        }
        StudentManage sMag = new StudentManage();
        if(true == sMag.UpdateApplyStatus(stuID, res, tbReason.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作成功')</script>");
            Response.Redirect("~/Engineering/TeacherBackMag/MyStudDefenceApply.aspx");
           // tbConfirm.Enabled = false;
            //lblResult.Text = "操作成功！";
          //  lblResult.Visible = true;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作失败')</script>");
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
