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

public partial class Engineering_StuBackMag_MyDefenseApplicant : System.Web.UI.Page
{
    public string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        StudentManage sMag = new StudentManage();
        DocumentManage dMag = new DocumentManage();
        DataSet ds = null;
        //判断当前页面处于哪个状态
        ds = sMag.GetStuApplyStatus(studentID);
        int res;
        int isAgree = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            //导师是否批准
            res = Convert.ToInt32(ds.Tables[0].Rows[0]["IsAnswered"]);
            //管理员是否批准
            isAgree = Convert.ToInt32(ds.Tables[0].Rows[0]["IsQualified"]);
        }
        else
        {
            res = -1;
        }
        if (-1 == res)
        {
            //还没申请
            Panel1.Visible = true;
            bindData();
            
        }
        else if (res == 0)
        {
            //向导师申请中。。。
            Panel2.Visible = true;
        }
        else if (res == 1)
        {
            //导师批准申请
            DataSet ds1 = dMag.GetStuFinalPaper(studentID);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                //该生已经提交了最终论文
                if (isAgree == 0)
                {
                    //管理员还没有处理
                    Panel5.Visible = true;
                }
                if (isAgree == 1)
                {
                    //管理员审核通过
                    Panel5.Visible = true;
                }
                if (isAgree == 2)
                {
                    Panel6.Visible = true;
                    tbAdmReason.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
                }
            }
            else
            { 
                // 该生还没有提交最终论文
                Panel3.Visible = true;
            }
        }
        else
        {
            //导师不批准申请
            Panel4.Visible = true;
            tbReason.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
        }
       
    }
    protected void lblApply_Click(object sender, EventArgs e)
    {
        StudentManage sMag = new StudentManage();
        DateTime nowTime = System.DateTime.Now;
        if (true == sMag.AddDefenceApplyStatus(studentID))
        {
            //申请成功
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }
        else
        {
            //申请失败
            Label1.Text = "失败";
            Label1.Visible = true;
        }
    }
    protected void btNewStart_Click(object sender, EventArgs e)
    {
        StudentManage sMag = new StudentManage();
        if (true == sMag.DeleteStuDefenceApply(studentID))
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            bindData();
        }
        else
        {
            Label5.Visible = true;
        }
    }
    protected void bindData()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStuDefenceApplyCondition(studentID);
        int count = ds.Tables[0].Rows.Count;
        int num = 0;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 1)
                {
                    num++;
                    string speach = "已提交（最新提交时间：";
                    speach = speach + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    speach = speach + ")";
                    lblOpenSpeach.Text = speach;
                    lblOpenSpeach.ForeColor = System.Drawing.Color.Black;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 2)
                {
                    num++;
                    string midForm = "已提交（最新提交时间：";
                    midForm = midForm + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    midForm = midForm + ")";
                    lblMidForm.Text = midForm;
                    lblMidForm.ForeColor = System.Drawing.Color.Black;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 3)
                {
                    num++;
                    string paper = "已提交（最新提交时间：";
                    paper = paper + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    paper = paper + ")";
                    lblPaper.Text = paper;
                    lblPaper.ForeColor = System.Drawing.Color.Black;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 4)
                {
                    num++;
                    string outTutor = "已提交（最新提交时间：";
                    outTutor = outTutor + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    outTutor = outTutor + ")";
                    lblOutTeacher.Text = outTutor;
                    lblOutTeacher.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
        if (num == 4)
        {
            btApply.Enabled = true;
        }
        else
        {
            btApply.Enabled = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                StudentManage sMag = new StudentManage();
                DocumentManage dMag = new DocumentManage();
                string grade = sMag.GetGradebyStuID(studentID);
                string fileName = FileUpload1.PostedFile.FileName;
                string extension = Path.GetExtension(fileName);
                if (extension != ".doc" && extension != ".docx")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能上传Word文件(doc或docx)')</script>");
                    return;
                }
                string name = studentID+ extension;
                string virtualpath = @"../MsUpload/final/" + grade + "/" + name;
                string directory = Path.GetDirectoryName(Server.MapPath(virtualpath));
                if (!Directory.Exists(directory))  //判断文件目录是否存在
                {
                    Directory.CreateDirectory(directory);
                }
                // 保存新文件到服务器上
                FileUpload1.SaveAs(Server.MapPath(virtualpath));
                //将文件地址保存在数据库中
                if (dMag.AddFinalPaperByStu(studentID, virtualpath, tbPaperName.Text.Trim()) == true)
                {
                    Panel5.Visible = true;
                    Panel3.Visible = false;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + ex.Message.ToString() + "')</script>");
                return;
               // lblFinalPaper.Text = "Error:" + ex.Message.ToString();
              //  lblFinalPaper.Visible = true;
            }
        }
        else
        {
            lblFinalPaper.Text = "you have not specified a file.";
            lblFinalPaper.Visible = true;
        }
    }
    protected void btApplyAgn_Click(object sender, EventArgs e)
    {
        StudentManage sMag = new StudentManage();
        if (sMag.UpdateDefenceApply(studentID, 0, "") == true)
        {
            //成功
            Panel5.Visible = true;
            Panel6.Visible = false;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请失败，请重试')</script>");
            return;
        }   
    }
}
