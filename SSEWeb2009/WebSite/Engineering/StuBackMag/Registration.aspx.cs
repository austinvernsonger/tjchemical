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

public partial class Engineering_StuBackMag_Registration : System.Web.UI.Page
{
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindBasicInfo();
            bindCalendar();
        }
    }
    protected void btConfirm_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            StudentInfo sInfo = new StudentInfo();
            StudentManage sMag = new StudentManage();
            // 判断当前账号是否已经注册
            if (StudentManage.IsStudentRegistered(studentID) == true)
            { 
                //已注册
                ClientScript.RegisterStartupScript(GetType(), "Message", "<script language='javascript'>alert('你已经注册过了！')</script>");
                return;
            }
            if (GetDateTime() != null)
            {
                sInfo.Birthday = GetDateTime();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<script language='javascript'>alert('出生年月选择有错，注册失败')</script>");
                return;
            }
            sInfo.StuName = tbName.Text.Trim();
            sInfo.StuID = tbStuNo.Text.Trim();
            sInfo.Nation = tbNation.Text.Trim();
            sInfo.NativePro = tbNativePro.Text.Trim();
            sInfo.PolStatus = ddlPolitic.SelectedValue;
            sInfo.StuIDNumber = tbIDNum.Text.Trim();
            sInfo.MarStatus = ddlMarStatus.SelectedIndex -1;
            if (tbPhoneNum.Text.Trim() != "")
            {
                sInfo.MobPhone = tbPhoneNum.Text.Trim();
            }
            if (tbFixedNum.Text.Trim() != "")
            {
                sInfo.FixedPhone = tbFixedNum.Text.Trim();
            }
            if (tbEmail.Text.Trim() != "")
            {
                sInfo.EmailAddress = tbEmail.Text.Trim();
            }
            if (tbAddress.Text.Trim() != "")
            {
                sInfo.Address = tbAddress.Text.Trim();
            }
            if (tbPostalCode.Text.Trim() != "")
            {
                sInfo.PostalCode = tbPostalCode.Text.Trim();
            }
            if (tbHomeAddress.Text.Trim() != "")
            {
                sInfo.HomeAddress = tbHomeAddress.Text.Trim();
            }
            if (tbWorkPlace.Text.Trim() != "")
            {
                sInfo.WorkPlace = tbWorkPlace.Text.Trim();
            }
            if (tbwPlaceAddress.Text.Trim() != "")
            {
                sInfo.WorkPlaceAdd = tbwPlaceAddress.Text.Trim();
            }
           sInfo.Password = tbPassword.Text.Trim();
           sInfo.PasswordAgn = tbPassword.Text.Trim();
           if (sMag.updateStudentBasicInfoByTran(sInfo) == true)
           {
               //注册成功
               Session["IdentifyNumber"] = null;
               btConfirm.Enabled = false;
               Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册成功，请重新登录')</script>");
               //Response.Redirect("../../Login/Login.aspx");
          
           }
           else
           { 
               //注册失败
               Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册失败，请重试！')</script>");
           }
        }
    }
    protected void bindBasicInfo()
    {
        StudentInfo stuInfo = new StudentInfo();
        StudentManage stuMag = new StudentManage();
        stuInfo = stuMag.GetStudentInfo(studentID);
        if (stuInfo == null)
        {
            //返回出错，等待处理
            return;
        }
        tbName.Text = stuInfo.StuName;
        tbStuNo.Text = stuInfo.StuID;
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }
    protected void AddDay()
    {
        int tmpMaxDays = 30;
        if (ddlMonth.SelectedIndex == 2)    // Feb.
        {
            int tmpYear = Convert.ToInt32(ddlYear.SelectedValue);
            if (((tmpYear % 4) == 0 && (tmpYear % 100) != 0) || (tmpYear % 400) == 0)
                tmpMaxDays = 29;
            else tmpMaxDays = 28;
        }
        else if (ddlMonth.SelectedIndex == 1 ||    // Jan.
            ddlMonth.SelectedIndex == 3 ||         // Mar.
            ddlMonth.SelectedIndex == 5 ||         // May
            ddlMonth.SelectedIndex == 7 ||         // Jul.
            ddlMonth.SelectedIndex == 8 ||         // Aug.
            ddlMonth.SelectedIndex == 10 ||         // Ost.
            ddlMonth.SelectedIndex == 12)          // Dec.
            tmpMaxDays = 31;
        else tmpMaxDays = 30;

        ddlDay.Items.Clear();
        for (int i = 1; i < tmpMaxDays + 1; ++i)
            ddlDay.Items.Add(i.ToString());
        ddlDay.Items.Insert(0, "");
        ddlDay.SelectedIndex = 0;
    }
    public string GetDateTime()
    {
        if (ddlYear.SelectedIndex != 0 && ddlMonth.SelectedIndex != 0 && ddlDay.SelectedIndex != 0)
        {
            lblCalendarError.Visible = false;
            return ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue;
        }
        else
        {
            lblCalendarError.Visible = true;
            return null;
        }
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
    protected void bindCalendar()
    {
        ddlYear.Items.Clear();
        for (int i = 0; i < 110; i++)
        {
            ddlYear.Items.Add((1900 + i).ToString());
        }
        ddlYear.Items.Insert(0, "");
        ddlYear.SelectedIndex = 0;

        ddlMonth.Items.Clear();
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(i.ToString());
        }
        ddlMonth.Items.Insert(0, "");
        ddlMonth.SelectedIndex = 0;

        AddDay();
    }
}
