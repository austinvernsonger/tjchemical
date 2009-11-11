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

public partial class Engineering_AdminBakMag_AssignPaperDetails : System.Web.UI.Page
{
    private string path;
    private string studentID;
    private int attachID;
    private string fileName;
    private string tutorID;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (Request["id"] != null && Request["id"] != "")
        {
            studentID = Request["id"].ToString();
            bindData();
        }
    }
    protected void lbSpeach_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath(path));
        if (file.Exists == true)
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('文件不存在')</script>", false);
            return;
        }
    }
    protected void btGenerateCode_Click(object sender, EventArgs e)
    {
        Hashtable hashtable = new Hashtable();
        Random rm = new Random();
        int RmNum = 5;
        string res = "NO";
        for (int i = 0; hashtable.Count < RmNum; i++)
        {
            int nValue = rm.Next(100);
            if (!hashtable.ContainsValue(nValue) && nValue != 0)
            {
                hashtable.Add(nValue, nValue);
                res = res + nValue.ToString();
            }
        }
        tbNum.Text = res;
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        if (tbNum.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请生成盲审号')</script>");
            return;
        }
        if (ddlLeader.SelectedIndex == 0 || ddlMember1.SelectedIndex ==0 || ddlMember2.SelectedIndex ==0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('必选选择3个评审人员')</script>");
            return;
        }
        if (ddlLeader.SelectedIndex == ddlMember1.SelectedIndex
            || ddlLeader.SelectedIndex == ddlMember2.SelectedIndex
            || ddlMember1.SelectedIndex == ddlMember2.SelectedIndex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('必选选择3个不同的评审人员')</script>");
            return;
        }
        if (string.Compare(ddlLeader.SelectedValue.Trim(), tutorID.Trim()) == 0
            || string.Compare(ddlMember1.SelectedValue.Trim(), tutorID.Trim()) == 0
            || string.Compare(ddlMember2.SelectedValue.Trim(), tutorID.Trim()) == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('评审人员不能包含该学生的导师')</script>");
            return;
        }
        string[] teacher = new string[3];
        teacher[0] = ddlLeader.SelectedValue;
        teacher[1] = ddlMember1.SelectedValue;
        teacher[2] = ddlMember2.SelectedValue;
        TeacherManage tMag = new TeacherManage();
        bool res = tMag.TranThesisJudgeInfo(studentID, teacher, tbNum.Text.Trim());
        if (res == true)
        {
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('分配成功')</script>");
           // btSubmit.Enabled = false;
            Response.Redirect("~/Engineering/AdminBakMag/AssignPaperForStus.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('分配失败')</script>");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                DocumentManage dMag = new DocumentManage();
                StudentManage sMag = new StudentManage();
                DataSet ds = null;
                ds = dMag.GetAttachment(studentID, 5);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //该生的预审论文已经存在
                    //获取论文的路径
                    string path = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
                    string grade = sMag.GetGradebyStuID(studentID);
                    string file = FileUpload1.FileName;
                    string extension = Path.GetExtension(Server.MapPath(path));
                    string name = studentID + extension;
                    string virtualpath = @"../MsUpload/final/" + grade + "/" + name;
                    string directory = Path.GetDirectoryName(Server.MapPath(virtualpath));
                    if (!Directory.Exists(directory))  //判断文件目录是否存在
                    {
                        Directory.CreateDirectory(directory);
                    }
                    FileUpload1.SaveAs(Server.MapPath(virtualpath));
                    if (dMag.UpdateFinalPaperAttachment(studentID, virtualpath) == true)
                    {
                        //更新成功
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('该生预审论文更新成功！')</script>", false);
                        return;
                    }
                    else
                    {
                        //更新失败
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('预审论文更新失败，请重试！')</script>", false);
                        return;
                    }
                }
            }
            catch
            { 

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请指定要上传的论文！')</script>", false);
            return;
        }
    }
    protected void bindData()
    {
        DocumentManage dMag = new DocumentManage();
        DataSet ds = dMag.GetPrejudicationStatusByStuid(studentID);
        dvPrejudication.DataSource = ds.Tables[0];
        dvPrejudication.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            path = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
            attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
            string extension = Path.GetExtension(Server.MapPath(path));
            string name = ds.Tables[0].Rows[0]["AttachName"].ToString();
            fileName = name + extension;
            tutorID = ds.Tables[0].Rows[0]["TeacherID"].ToString();
        }
    }
}
