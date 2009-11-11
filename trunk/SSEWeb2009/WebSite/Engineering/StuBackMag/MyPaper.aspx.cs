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

public partial class Engineering_StuBackMag_MyPaper : System.Web.UI.Page
{
    public string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString().Trim();
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
        }
        bindGvDiscussion();
        
    }
    protected void btPaper_Click(object sender, EventArgs e)
    {
        if (tbPaper.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请输入论文标题')</script>", false);
            return;
        }
        if (fileuploadPaper.HasFile)
        {
            TeacherManage tMag = new TeacherManage();
            StudentManage sMag = new StudentManage();
            DocumentManage dMag = new DocumentManage();
            DiscussionInfo dInfo = new DiscussionInfo();
            DataSet ds = null;
            //检查该学生有没有导师，如果没有导师就不能提交论文
            ds = sMag.GetTeacherInfoByStuID(studentID);
            if (ds.Tables[0].Rows[0]["TeacherID"] == System.DBNull.Value || ds.Tables[0].Rows[0]["TeacherID"].ToString().Trim() == "")
            {
                //该学生没有导师
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('你当前还没有导师，不能上传开题报告')</script>", false);
                return;
            }
            string teacherID = ds.Tables[0].Rows[0]["TeacherID"].ToString().Trim();
            //判断该用户的中期考核表是否已经提交过
            ds = dMag.GetAttachment(studentID, 2);
            if (ds.Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('你的中期考核表还没有提交，请先提交中期考核表')</script>", false);
                return;
            }
            int MaxLength = 1024 * 1024 * 10;//最大为10M
            //判断上传文件的大小是否大于10M
            if (fileuploadPaper.PostedFile.ContentLength > MaxLength)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('文件过大')</script>", false);
                return;
            }
           
            try
            {
                string name = fileuploadPaper.FileName;
                //获取后缀名
                string extension = Path.GetExtension(name);
                if (extension != ".doc" && extension != ".docx")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('只能上传Word文件(doc或docx)')</script>", false);
                    return;
                }
                //判断该用户的论文初稿是否已经提交过
                ds = dMag.GetAttachment(studentID, 3);
                //获取学生所属年级
                string grade = sMag.GetGradebyStuID(studentID);
                //文件以学号重新命名
                string fileName = studentID + extension;
                //论文初稿新路径
                string newPath = @"../MsUpload/paper/" + grade + "/" + fileName;
                string directory = Path.GetDirectoryName(Server.MapPath(newPath));
                //判断论文初稿的路径是否存在
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //论文初稿已经存在
                    int attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
                    string oldAttachUrl = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
                    if (File.Exists(Server.MapPath(oldAttachUrl)))
                    {
                        File.Delete(Server.MapPath(oldAttachUrl));
                    }
                    //保存文件到服务器
                    fileuploadPaper.SaveAs(Server.MapPath(newPath));
                    if (dMag.updatePaper(attachID, newPath, tbPaper.Text.Trim()) == true)
                    {
                        //更新成功
                        //添加评论信息
                        ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 4);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
                            dInfo.Title = tbPaper.Text.Trim();
                            dInfo.Body = "更新了论文初稿";
                            dInfo.Category = 4;
                            dInfo.Status = "10";
                            dInfo.Communicators = dr["Communicators"].ToString();
                            dInfo.AttachID = attachID;
                            dInfo.AddDiscussionInfo();//添加评论信息
                            bindGvDiscussion();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('更新成功')</script>", false);
                        }
                    }
                    else
                    {
                        //更新失败
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('更新失败')</script>", false);
                        return;
                    }
                }
                else
                { 
                    //论文初稿不存在
                    //保存文件到服务器
                    fileuploadPaper.SaveAs(Server.MapPath(newPath));
                    dInfo.Communicators = studentID.Trim() + "|" + teacherID.Trim();
                    dInfo.Category = 4;
                    dInfo.Title = tbPaper.Text.Trim() ;
                    dInfo.Body = "提交的一份论文初稿";
                    if (dMag.AddPaperByTran(studentID, newPath, dInfo) == true)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交成功')</script>", false);
                        tbPaper.Text = "";
                        //绑定交流信息
                        bindGvDiscussion();
                    }
                }
               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('" + ex.Message.ToString() + "')</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('你还没有选择上传文件')</script>", false);
        }
    }
    protected void bindGvDiscussion()
    {
        DiscussionInfo dMag = new DiscussionInfo();
        DataSet ds = dMag.GetDiscussionRelatedtoStudent(studentID, 4);
        gvRecordList.DataSource = ds.Tables[0];
        gvRecordList.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblMessage.Text = "你还没有提交过论文初稿 :-(";
            div_list.Visible = false;
        }
        else
        {
            lblMessage.Text = "我与导师之前的交流";
            lblMessage.Font.Bold = true;
            lblMessage.ForeColor = System.Drawing.Color.Black;
            div_list.Visible = true;
            ViewState["AttachID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
        }
    }
    public string GetSpeaker(string Communicator)
    {
        string[] speakers = Communicator.Split('|');
        if (string.Compare(speakers[0].Trim(), studentID) == 0)
        {
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStusInfo(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["sName"].ToString();
            }
            return null;
        }
        else
        {
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetTeacherInfoByTeacherID(speakers[0].Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["Name"].ToString();
            }
            return null;
        }
    }
    protected void btComment_Click(object sender, EventArgs e)
    {
        DiscussionInfo dInfo = new DiscussionInfo();
        DataSet ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 4);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
            dInfo.Title = dr["Title"].ToString();
            dInfo.Body = tbMessage.Text.Trim();
            dInfo.Category = 4;
            dInfo.Status = "10";
            dInfo.Communicators = dr["Communicators"].ToString();
            dInfo.AttachID = Convert.ToInt32(dr["AttachID"]);
            if (dInfo.AddDiscussionInfo() == true)
            {
                bindGvDiscussion();
                tbMessage.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('留言失败，请重试')</script>", false);
                return;
            }
        }
    }
    protected void lbnDownload_Click(object sender, EventArgs e)
    {
        if (ViewState["AttachID"] != null)
        {
            int attachID = Convert.ToInt32(ViewState["AttachID"]);
            DocumentManage dMag = new DocumentManage();
            DataSet ds = dMag.GetAttachmentByAttachID(attachID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string path = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
                FileInfo file = new FileInfo(Server.MapPath(path));
                if (file.Exists)
                {
                    FileManage.DownLoadFile(file);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('文件不存在！')</script>", false);
                    return;
                }
            }
            else
            {
                //附件不存在
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('文件不存在！')</script>", false);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('下载出错，请重新刷新页面')</script>", false);
            return;
        }
    }
    protected void gvRecordList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRecordList.PageIndex = e.NewPageIndex;
        bindGvDiscussion();
    }
}
