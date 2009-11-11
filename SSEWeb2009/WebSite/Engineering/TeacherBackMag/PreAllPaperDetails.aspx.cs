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

public partial class Engineering_TeacherBackMag_PreAllPaperDetails : System.Web.UI.Page
{
    private string teacherid;
    private string studentID;
    private string bNo;
    private string filePath;
    private string fileName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherid = Session["IdentifyNumber"].ToString();
        if (Request["id"] != null && Request["id"] != "")
        {
            bNo = Request["id"].ToString();
            tbBNo.Text = bNo;
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetAllPrePaperBybNo(bNo);
            studentID = ds.Tables[0].Rows[0]["StudentID"].ToString();
            filePath = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
            string extension = Path.GetExtension(Server.MapPath(filePath));
            fileName = ds.Tables[0].Rows[0]["AttachName"].ToString() + extension;
            int count = ds.Tables[0].Rows.Count;
            int index = 0;
            if (!IsPostBack)
            {
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["IsLeader"]) == 1)
                    {
                        index = i;
                    }

                    if (string.Compare(ds.Tables[0].Rows[i]["TeacherID"].ToString().Trim(), teacherid) == 0)
                    {
                        tbTitle.Text = ds.Tables[0].Rows[i]["AttachName"].ToString();
                        tbRemark.Text = ds.Tables[0].Rows[i]["JudgeResult"].ToString();
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["IsLeader"]) == 1)
                        {
                            ViewState["leader"] = true;
                        }
                        if (ds.Tables[0].Rows[i]["JudgeTime"] != System.DBNull.Value)
                        {
                            lblTime.Text = "最近评审时间：" + Convert.ToDateTime(ds.Tables[0].Rows[i]["JudgeTime"]).ToString("yyyy年MM月dd日");
                        }
                        else
                        {
                            lblTime.Text = "当前时间：" + System.DateTime.Now.ToString("yyyy年MM月dd日");
                        }
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["IsCriterion"]) == 2)
                        {
                            rbNoQualify.Checked = true;
                        }
                        else
                        {
                            rbQualify.Checked = true;
                        }
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["IsLeader"]) == 1)
                        {
                            //当前用户是组长
                            DataSet ds1 = new DataSet();
                            ds1 = tMag.GetNoLeaderPaperJudge(bNo);
                            dvOtherMemRes.DataSource = ds1.Tables[0];
                            dvOtherMemRes.DataBind();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                lblMessage.Visible = false;
                            }
                            //Label2.Visible = true;
                            CollapsiblePanelExtender1.Enabled = true;
                            Panel1.Visible = true;
                            Panel2.Visible = true;
                        }
                    }
                }
                if (index == 0)
                {
                    lblLeader.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblMember1.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    lblMember2.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                }
                if (index == 1)
                {
                    lblLeader.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    lblMember1.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblMember2.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                }
                if (index == 2)
                {
                    lblLeader.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                    lblMember1.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    lblMember2.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
            }
        }
    }
    protected void lbDownload_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath(filePath));
        if (file.Exists)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.Buffer = false;
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.AppendHeader("Content-Length", file.Length.ToString());
            Response.WriteFile(file.FullName);
            Response.Flush();
            Response.End();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('文件不存在！')</script>");
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        PaperJudge pj = new PaperJudge();
        pj.Teacherid = teacherid;
        //pj.BNo = bNo;
        pj.StudentID = studentID;
        lblTime.Text = System.DateTime.Now.ToString("yyyy年MM月dd日");
        if (tbRemark.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填写评语')</script>");
            return;
        }
        else
        {
            pj.Result = tbRemark.Text.Trim();
        }
        if (rbNoQualify.Checked == true)
        {
            pj.Criterion = 2;
        }
        if (rbQualify.Checked == true)
        {
            pj.Criterion = 1;
        }
        TeacherManage tMag = new TeacherManage();
        if (tMag.UpdatePaperJudgeStatus(pj) == true)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert(' 保存成功')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败')</script>");
        }
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        if (ViewState["leader"] == null && Convert.ToBoolean(ViewState["leader"]) == false)
        {
            //不是组长
            PaperJudge pj = new PaperJudge();
            pj.Teacherid = teacherid;
            //pj.BNo = bNo;
            pj.StudentID = studentID;
            pj.JudgeStatue = 1;
            lblTime.Text = System.DateTime.Now.ToString("yyyy年MM月dd日");
            if (tbRemark.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填写评语')</script>");
                return;
            }
            else
            {
                pj.Result = tbRemark.Text.Trim();
            }
            if (rbNoQualify.Checked == true)
            {
                pj.Criterion = 2;
            }
            if (rbQualify.Checked == true)
            {
                pj.Criterion = 1;
            }
            TeacherManage tMag = new TeacherManage();
            if (tMag.UpdatePaperJudgeStatus(pj) == true)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交成功')</script>");
               // btSubmit.Enabled = false;
               // btSave.Enabled = false;
                Response.Redirect("~/Engineering/TeacherBackMag/ViewAllPaper.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交失败，请重试')</script>");
                return;
            }
        }
        else
        {
            //是组长
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetNoLeaderPaperJudge(bNo);
            int count = ds.Tables[0].Rows.Count;
            if (count == 2)
            {
                //表示2个成员都已经评审完成
                PaperJudge pj = new PaperJudge();
                pj.Teacherid = teacherid;
                //pj.BNo = bNo;
                pj.StudentID = studentID;
                pj.JudgeStatue = 1;
                lblTime.Text = System.DateTime.Now.ToString("yyyy年MM月dd日");
                if (tbRemark.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填写评语')</script>");
                    return;
                }
                else
                {
                    pj.Result = tbRemark.Text.Trim();
                }
                if (rbNoQualify.Checked == true)
                {
                    pj.Criterion = 2;
                }
                if (rbQualify.Checked == true)
                {
                    pj.Criterion = 1;
                }
                if (tMag.UpdatePaperJudgeStatus(pj) == true)
                {
                 //   Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交成功')</script>");
                    //btSubmit.Enabled = false;
                  //  btSave.Enabled = false;
                    Response.Write("~/Engineering/TeacherBackMag/ViewAllPaper.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交失败，请重试')</script>");
                    return;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你是组长，需要等其他成员评审完成，才能提交最后评审结果，当前你可以点保存按钮，保存你的评审结果！')</script>");
                return;
            }
        }
    }
    protected void dvOtherMemRes_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lID = (Label)e.Item.FindControl("lblID");
        string teacherid = lID.Text;
        Label lNo = (Label)e.Item.FindControl("lblbNo");
        string bNo = lNo.Text;
        LinkButton lb = (LinkButton)e.Item.FindControl("lbViewDetails");
        lb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + bNo + "','" + teacherid + "',560,500)"); 
    }
    protected void dvOtherMemRes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
