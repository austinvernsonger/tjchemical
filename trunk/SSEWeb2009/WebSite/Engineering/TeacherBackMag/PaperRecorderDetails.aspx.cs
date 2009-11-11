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

public partial class Engineering_TeacherBackMag_PaperRecorderDetails : System.Web.UI.Page
{
    private string teacherID ;
    private int itemID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherID = Session["IdentifyNumber"].ToString().Trim();
        if (Request["id"] != null && Request["id"] != "")
        {
            itemID = Convert.ToInt32(Request["id"]);
            if (!IsPostBack)
            {
                //首先更新主题的点击状态
                DocumentManage dMag = new DocumentManage();
                dMag.UpdateTeacherClickStatus(itemID);
                // 显示主题的评论信息
                bindData();
            }
        }
    }
    protected void bindData()
    {
        DiscussionInfo dInfo = new DiscussionInfo();
        DocumentManage dMag = new DocumentManage();
        DataSet ds = null;
        ds = dInfo.GetDiscussionByItemID(itemID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
            ViewState["attachID"] = attachID;
            string parentDisplayOrder = ds.Tables[0].Rows[0]["DisplayOrder"].ToString();
            string studentID = ds.Tables[0].Rows[0]["Communicators"].ToString().Substring(0, 10);
            string title = ds.Tables[0].Rows[0]["Title"].ToString();
            string createdTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]).ToString("yyyy-MM-dd");
            lblTitle.Text = "主题：" + title;
            lblCreatedTime.Text = "创建时间：" + createdTime;
            StudentManage sMag = new StudentManage();
            ds = sMag.GetStusInfo(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string name = ds.Tables[0].Rows[0]["sName"].ToString();
                string grade = ds.Tables[0].Rows[0]["Grade"].ToString();
                string teachingSchool = ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();
                lblName.Text = "来自：" + name;
                lblGrade.Text = grade + teachingSchool + "教学点";
                lblStuID.Text = "学号：" + studentID;
            }
            ds = dMag.GetAttachmentByAttachID(attachID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastModifyTime"]).ToString("yyyy-MM-dd HH:mm");
            }
            ds = dInfo.GetChildMessageByteacher(parentDisplayOrder, teacherID);
            dlChildMessage.DataSource = ds.Tables[0];
            dlChildMessage.DataBind();
        }
    }
    public string GetSpeaker(string Communicator)
    {
        string[] speakers = Communicator.Split('|');
        if (string.Compare(speakers[0].Trim(), teacherID) == 0)
        {
            return "我说道：";
        }
        else
        {
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStusInfo(speakers[0].Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["sName"].ToString()+"说道：";
            }
            return null;
        }
    }
    protected void btComment_Click(object sender, EventArgs e)
    {
        if (tbComment.Text.Trim() == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<script language='javascript'>alert('请输入评论的内容')</script>");
            return;
        }
        DiscussionInfo dInfo = new DiscussionInfo();
        DataSet ds = dInfo.GetDiscussionByItemID(itemID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
            string communicator = dr["Communicators"].ToString();
            dInfo.Title = dr["Title"].ToString();
            dInfo.Body = tbComment.Text.Trim();
            dInfo.Category = Convert.ToInt32(dr["Category"]);
            dInfo.Status = "01";
            dInfo.AttachID = Convert.ToInt32(dr["AttachID"]);
            string [] communicators = communicator.Split('|');
            dInfo.Communicators = communicators[1].Trim() + "|" + communicators[0].Trim();
            if (dInfo.AddDiscussionInfo() == true)
            {
                //评论成功
                bindData();
                tbComment.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<script language='javascript'>alert('评论失败，请重试')</script>");
            }
        }
    }
    protected void lbDownload_Click(object sender, EventArgs e)
    {
       //string stuid = ViewState["studentID"].ToString();
        if (ViewState["attachID"] != null)
        {
            int attachID = (int)ViewState["attachID"];
            DocumentManage dMag = new DocumentManage();
            DataSet ds = dMag.GetAttachmentByAttachID(attachID);
            string path = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
            FileInfo file = new FileInfo(Server.MapPath(path));
            if (file.Exists)
            {
                FileManage.DownLoadFile(file);
            }
            else
            {
                Response.Write("<script language='javascript'>alert('文件不存在！')</script>");
            }
        }
    }
}
