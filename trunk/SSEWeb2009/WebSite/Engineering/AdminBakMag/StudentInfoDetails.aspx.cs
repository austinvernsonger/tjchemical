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

public partial class Engineering_AdminBakMag_StudentInfoDetails : System.Web.UI.Page
{
    private string studentID;
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"].ToString() != "")
        {
            studentID = Request["id"].ToString();
            if (!IsPostBack)
            {
                TabContainer1.ActiveTabIndex = 0;
                //绑定基本信息
                bindStuBasicInfo();
                //绑定照片
                bindPicture();
                //绑定联系方式
                bindContact();
                //绑定学费信息
                bindTuition();
                //绑定成绩信息
                bindScore();
                //绑定论文信息
                bindThesis();
            }
        }
    }
    protected void bindStuBasicInfo()
    {
        StudentInfo stuInfo = new StudentInfo();
        StudentManage stuMag = new StudentManage();
        stuInfo = stuMag.GetStudentInfo(studentID);
        if (stuInfo == null)
        {
            //返回出错，等待处理
            return;
        }
        lblName.Text = stuInfo.StuName;
        lblStuNo.Text = stuInfo.StuID;
        if (stuInfo.Gender != -1)
        {
            lblGender.Text = ((stuInfo.Gender == 0) ? "男" : "女");
        }
        if (stuInfo.Birthday != null)
        {
            lblBirthday.Text = stuInfo.Birthday;
        }
        if (stuInfo.NativePro != null)
        {
            lblProvince.Text = stuInfo.NativePro;
        }
        if (stuInfo.Nation != null)
        {
            lblNation.Text = stuInfo.Nation;
        }
        if (stuInfo.PolStatus != null)
        {
            lblPolitics.Text = stuInfo.PolStatus;
        }
        if (stuInfo.StuIDNumber != null)
        {
            lblStuIDNum.Text = stuInfo.StuIDNumber;
        }
        if (stuInfo.MarStatus != -1)
        {
            lblMarStatus.Text = ((stuInfo.MarStatus == 0) ? "未婚" : "已婚");
        }
        if (stuInfo.TeacherName != null)
        {
            lblTutor.Text = stuInfo.TeacherName;
        }
        if (stuInfo.Grade != null)
        {
            lblGrade.Text = stuInfo.Grade;
        }
        if (stuInfo.TeaSchoolName != null)
        {
            lblSchool.Text = stuInfo.TeaSchoolName;
        }
        if (stuInfo.Degree != null)
        {
            lblDegree.Text = stuInfo.Degree;
        }
        if (stuInfo.GraduateTime != null)
        {
            lblLeavingTime.Text = stuInfo.GraduateTime;
        }
    }
    protected void bindPicture()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStudentPicture(studentID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //照片存在
            string imagePath = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
            imgPicture.ImageUrl = imagePath;
        }
    }
    protected void bindContact()
    {
        StudentInfo stuInfo = new StudentInfo();
        StudentManage stuMag = new StudentManage();
        stuInfo = stuMag.GetStudentInfo(studentID);
        if (stuInfo == null)
        {
            //返回出错，等待处理
            return;
        }
        if (stuInfo.MobPhone != null)
        {
            lblMobile.Text = stuInfo.MobPhone;
        }
        if (stuInfo.FixedPhone != null)
        {
            lblFixPhone.Text = stuInfo.FixedPhone;
        }
        if (stuInfo.EmailAddress != null)
        {
            lblEmail.Text = stuInfo.EmailAddress;
        }
        if (stuInfo.Address != null)
        {
            lblAddress.Text = stuInfo.Address;
        }
        if (stuInfo.PostalCode != null)
        {
            lblPostalCode.Text = stuInfo.PostalCode;
        }
        if (stuInfo.HomeAddress != null)
        {
            lblHomeAddress.Text = stuInfo.HomeAddress;
        }
        if (stuInfo.WorkPlace != null)
        {
            lblCompany.Text = stuInfo.WorkPlace; 
        }
        if (stuInfo.WorkPlaceAdd != null)
        {
            lblCompanyAddress.Text =  stuInfo.WorkPlaceAdd;
        }
    }
    protected void bindTuition()
    {
        TuitionManage tMag = new TuitionManage();
        DataSet ds = tMag.GetTuitionInfo(studentID);
        gvTuitionInfo.DataSource = ds.Tables[0];
        gvTuitionInfo.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
        }
    }
    protected void bindScore()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetExamResultByStuID(studentID);
        gvScoreInfo.DataSource = ds.Tables[0];
        gvScoreInfo.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblScoreMsg.Visible = true;
            div_score.Visible = false;
        }
    }
    protected void bindThesis()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStuDefenceApplyCondition(studentID);
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 1)
                {
                    string speach = "已提交（最新提交时间：";
                    speach = speach + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    speach = speach + ")";
                    lblOpenSpeach.Text = speach;
                    lblOpenSpeach.ForeColor = System.Drawing.Color.Black;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 2)
                {
                    string midForm = "已提交（最新提交时间：";
                    midForm = midForm + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    midForm = midForm + ")";
                    lblMidForm.Text = midForm;
                    lblMidForm.ForeColor = System.Drawing.Color.Black;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 3)
                {
                    string paper = "已提交（最新提交时间：";
                    paper = paper + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    paper = paper + ")";
                    lblPaper.Text = paper;
                    lblPaper.ForeColor = System.Drawing.Color.Black;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Category"]) == 4)
                {
                    string outTutor = "已提交（最新提交时间：";
                    outTutor = outTutor + Convert.ToDateTime(ds.Tables[0].Rows[i]["LastModifyTime"]).ToString("yyyy-MM-dd");
                    outTutor = outTutor + ")";
                    lblOutTeacher.Text = outTutor;
                    lblOutTeacher.ForeColor = System.Drawing.Color.Black;
                }
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
            courseTime = courseTime + "秋";
        }
        else
        {
            courseTime = courseTime + "春";
        }
        return courseTime;
    }
    protected void gvScoreInfo_DataBound(object sender, EventArgs e)
    { 
        float degreeSum = 0;
        float noneDegreeSum = 0;
        float mclassSum = 0;
        for (int i = 0; i < gvScoreInfo.Rows.Count; i++)
        {
            if (IsNumber(gvScoreInfo.Rows[i].Cells[6].Text.Trim()) == true)
            {
                // 数字
                if (Convert.ToInt32(gvScoreInfo.Rows[i].Cells[6].Text.Trim()) < 60)
                {
                    gvScoreInfo.Rows[i].Cells[6].BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (gvScoreInfo.Rows[i].Cells[1].Text.Contains("学位") == true && gvScoreInfo.Rows[i].Cells[1].Text.Contains("非")==false)
                    { 
                        degreeSum =degreeSum + Convert.ToInt32(gvScoreInfo.Rows[i].Cells[5].Text.Trim());
                    }
                    else
                    {
                        noneDegreeSum = noneDegreeSum + Convert.ToInt32(gvScoreInfo.Rows[i].Cells[5].Text.Trim());
                    }
                }
            }
            else
            { 
                //非数字 稍后处理
               
            }
        }
        lblDegreeCredit.Text = "已完成学位课学分：" + degreeSum.ToString();
        lblNonDegreeCredit.Text = "非学位课学分：" + noneDegreeSum.ToString();
        lblTotalCredit.Text = "总学分：" + (degreeSum + noneDegreeSum + mclassSum).ToString();
    }
    protected bool IsNumber(string value)
    {
        try
        {
            Convert.ToInt32(value);
            return true;
        }
        catch
        {
            //非数字
            return false;
        }
    }
}
