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

public partial class Engineering_StuBackMag_MyOpenSpeech : System.Web.UI.Page
{
    public string studentID;
    private string btUniqueID = "";

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
    protected void btOpenSpeach_Click(object sender, EventArgs e)
    {
        TeacherManage tMag = new TeacherManage();
        StudentManage sMag = new StudentManage();
        DataSet ds = null;
        if (tbOpeningSpeach.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请输入开题报告名称')</script>", false);
            return;
        }
        ds = sMag.GetTeacherInfoByStuID(studentID);
        if (ds.Tables[0].Rows[0]["TeacherID"] == System.DBNull.Value || ds.Tables[0].Rows[0]["TeacherID"].ToString().Trim() =="")
        { 
            // 该生还没有导师
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('你当前还没有导师，不能上传开题报告')</script>", false);
            return;
        }
        //检查输入的合法性  尚未完成
        if (fuOpeningSpeach.HasFile)
        {
            //开题报告存在
                int MaxLength = 1024 * 1024 * 2;//最大为2M
                //判断开题报告的大小是否大于2M
                if (fuOpeningSpeach.PostedFile.ContentLength > MaxLength)
                {
                    //开题报告的大小不符合要求
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开题报告文档过大')</script>");
                    return;
                }
                //获取该生的导师
                string teacherID = ds.Tables[0].Rows[0]["TeacherID"].ToString().Trim();
                try
                {
                    DocumentManage dMag = new DocumentManage();
                    DiscussionInfo dInfo = new DiscussionInfo();
                    //判断该用户的开题报告是否已经提交过
                    ds = dMag.GetAttachment(studentID,1);
                    string grade = sMag.GetGradebyStuID(studentID);
                    //获取文件名
                    string name = fuOpeningSpeach.FileName;
                    //获取文件的后缀名
                    string extension = Path.GetExtension(name);
                    if (extension != ".doc" && extension != ".docx")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('只能上传Word文件(doc或docx)')</script>", false);
                        return;
                     }
                    //文件以学号重新命名
                    string fileName = studentID + extension;
                    //开题的新路径
                    string newKTPath = @"../MsUpload/kt/" + grade + "/" + fileName;
                    string directoryKT = Path.GetDirectoryName(Server.MapPath(newKTPath));
                    //判断开题报告的路径是否存在
                    if (!Directory.Exists(directoryKT))
                    {
                        Directory.CreateDirectory(directoryKT);
                    }
                    //将开题报告保存到服务器上
                    if (ds.Tables[0].Rows.Count > 0)
                    { 
                        //开题报告存在
                        int attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
                        string oldAttachUrl = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
                        if (File.Exists(Server.MapPath(oldAttachUrl)))
                        {
                            File.Delete(Server.MapPath(oldAttachUrl));
                        }
                        //保存文件到服务器
                        fuOpeningSpeach.SaveAs(Server.MapPath(newKTPath));
                        if (dMag.updateOpenSpeechByAttachID(attachID, newKTPath, tbOpeningSpeach.Text.Trim()) == true)
                        {
                            //更新成功
                            //添加评论信息
                            ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 1);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = ds.Tables[0].Rows[0];
                                dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
                                dInfo.Title = tbOpeningSpeach.Text.Trim();
                                dInfo.Body = "更新了开题报告";
                                dInfo.Category = 1;
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
                        //开题报告不存在
                        fuOpeningSpeach.SaveAs(Server.MapPath(newKTPath));

                        dInfo.Communicators = studentID.Trim() + "|" + teacherID.Trim();
                        dInfo.Category = 1;
                        dInfo.Title = tbOpeningSpeach.Text.Trim();
                        dInfo.Body = "提交的一份开题报告";
                        if (dMag.AddOpeningSpeechByTran(studentID, newKTPath, dInfo) == true)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交成功')</script>", false);
                            tbOpeningSpeach.Text = "";
                            //绑定交流信息
                            bindGvDiscussion();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('提交失败')</script>", false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('Error:+" + ex.Message.ToString() + "')</script>", false);
                    return;
                }
        }
        else
        {
            lblResult.Text = "你还没有选择开题报告文档";
        }
    }
    protected void bindGvDiscussion()
    {
        DiscussionInfo dMag = new DiscussionInfo();
        DataSet ds = dMag.GetDiscussionRelatedtoStudent(studentID, 1);
        gvRecordList.DataSource = ds.Tables[0];
        gvRecordList.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblMessage.Text = "你还没有提交过中期考核表 :-(";
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
        DataSet ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
            dInfo.Title = dr["Title"].ToString();
            dInfo.Body = tbMessage.Text.Trim();
            dInfo.Category = 1;
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('留言失败，请重试')</script>");
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
