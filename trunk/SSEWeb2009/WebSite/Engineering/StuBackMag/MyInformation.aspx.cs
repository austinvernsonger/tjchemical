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

public partial class Engineering_StuBackMag_MyInformation : System.Web.UI.Page
{
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();

        if(!IsPostBack)
        {
            //绑定我的基本信息
            bindMyInformation();
            //绑定我的照片
            bindMyPicture();
        }
    }
    protected void bindMyInformation()
    {
        StudentInfo sInfo = new StudentInfo();
        StudentManage sMag = new StudentManage();
        sInfo = sMag.GetStudentInfo(studentID);
        if (sInfo == null)
        {
            //返回出错，等待处理
            return;
        }
        lblName.Text = sInfo.StuName;
        lblStuNum.Text = sInfo.StuID;
        if (sInfo.Gender != -1)
        {
            lblGender.Text = (sInfo.Gender == 0) ? "男" : "女";
        }
        if (sInfo.Birthday != null)
        {
            lblBirthday.Text = Convert.ToDateTime(sInfo.Birthday).ToString("yyyy年MM月dd日");
        }
        if (sInfo.StuIDNumber != null)
        {
            lblIDNum.Text = sInfo.StuIDNumber;
        }
        if (sInfo.Nation != null)
        {
            lblNation.Text = sInfo.Nation;
        }
        if (sInfo.NativePro != null)
        {
            lblNativePro.Text = sInfo.NativePro;
        }
        if (sInfo.PolStatus != null)
        {
            lblPolitics.Text = sInfo.PolStatus;
        }
        if (sInfo.MarStatus != -1)
        {
            lblMarStatus.Text = (sInfo.MarStatus == 0) ? "未婚" : "已婚";
        }
        if (sInfo.Major != null)
        {
            lblMajor.Text = sInfo.Major;
        }
        if (sInfo.GraduateTime != null)
        {
            lblGraduate.Text = sInfo.GraduateTime;
        }
        if (sInfo.Schooling != null)
        {
            lblSchooling.Text = sInfo.Schooling;
        }
        if (sInfo.Degree != null)
        {
            lblDegree.Text = sInfo.Degree;
        }
        if (sInfo.Grade != null)
        {
            lblGrade.Text = sInfo.Grade;
        }
        if (sInfo.MobPhone != null)
        {
            lblMobile.Text = sInfo.MobPhone;
        }
        if (sInfo.FixedPhone != null)
        {
            lblFixedPhone.Text = sInfo.FixedPhone;
        }
        if (sInfo.Address != null)
        {
            lblAddress.Text = sInfo.Address;
        }
        if (sInfo.PostalCode != null)
        {
            lblPostalCode.Text = sInfo.PostalCode;
        }
        if (sInfo.HomeAddress != null)
        {
            lblHomeAddress.Text = sInfo.HomeAddress;
        }
        if (sInfo.WorkPlace != null)
        {
            lblCompany.Text = sInfo.WorkPlace;
        }
        if (sInfo.WorkPlaceAdd != null)
        {
            lblCompanyAdd.Text = sInfo.WorkPlaceAdd;
        }
    }
    protected void bindMyPicture()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStudentPicture(studentID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //照片存在
            string imagePath = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
            Image1.ImageUrl = imagePath;
        }
    }
}
