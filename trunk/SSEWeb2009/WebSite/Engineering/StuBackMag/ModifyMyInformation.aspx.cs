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

public partial class Engineering_StuBackMag_ModifyMyInformation : System.Web.UI.Page
{
    private string studentID ;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            bindCalendar();//绑定日期
            bindData();//绑定个人信息
            bindPicture();
        }
    }
    protected void btSaveInfo_Click(object sender, EventArgs e)
    {
        StudentInfo sInfo = new StudentInfo();
        StudentManage sMag = new StudentManage();
        sInfo.StuName = tbName.Text.Trim();
        sInfo.StuID = tbStuNum.Text.Trim();
        if (rbMan.Checked == true)
        {
            sInfo.Gender = 0;
        }
        else
        {
            sInfo.Gender = 1;
        }
        if (GetDateTime() != null)
        {
            sInfo.Birthday = GetDateTime();
        }

        if (tbNation.Text.Trim() != "")
        {
            sInfo.Nation = tbNation.Text.Trim();
        }
        if (tbProvince.Text.Trim() != "")
        {
            sInfo.NativePro = tbProvince.Text.Trim();
        }
        if (ddlPolitic.SelectedIndex != 0)
        {
            sInfo.PolStatus = ddlPolitic.SelectedItem.Text;
        }
        if (tbNum.Text.Trim() != "")
        {
            sInfo.StuIDNumber = tbNum.Text.Trim();
        }
        if (ddlMarStatus.SelectedIndex != 0)
        {
            if (ddlMarStatus.SelectedIndex == 1)
            {
                sInfo.MarStatus = 1;
            }
            else
            {
                sInfo.MarStatus = 0;
            }
        }
        if (true == sMag.UpdateStudentInfoByStu(sInfo))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败！')</script>");
        }
    }
    protected void bindCalendar()
    {
        ddlYear.Items.Clear();
        for (int i = 0; i < 110; i++)
        {
            ddlYear.Items.Add((1900 + i).ToString());
        }
        //ddlYear.Items.Insert(0, "");
        ddlYear.SelectedIndex = 0;

        ddlMonth.Items.Clear();
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(i.ToString());
        }
      //  ddlMonth.Items.Insert(0, "");
        ddlMonth.SelectedIndex = 0;

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
       // ddlDay.Items.Insert(0, "");
        ddlDay.SelectedIndex = 0;
    }
    public void SetDateTime(DateTime theDate)
    {
        ddlYear.SelectedIndex = (theDate.Year - 1900 );
        ddlMonth.SelectedIndex = theDate.Month -1;
        ddlDay.SelectedIndex = (theDate.Day - 1);
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
    protected void bindData()
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
        tbStuNum.Text = stuInfo.StuID;
        if (stuInfo.Gender != -1)
        {
            if (stuInfo.Gender == 0)
            {
                rbMan.Checked = true;
            }
            else
            {
                rbWoman.Checked = true;
            }
        }
        if (stuInfo.Birthday != null )
        {  
           SetDateTime(Convert.ToDateTime(stuInfo.Birthday));
        }
        if (stuInfo.NativePro != null )
        {
            tbProvince.Text = stuInfo.NativePro;
        }
        if(stuInfo.Nation != null )
        {
            tbNation.Text = stuInfo.Nation;
        }
        if (stuInfo.PolStatus != null)
        {
            for (int i = 0; i < ddlPolitic.Items.Count; i++)
            {
                if (string.Compare(ddlPolitic.Items[i].Text.Trim(), stuInfo.PolStatus.Trim()) == 0)
                {
                    ddlPolitic.Items[i].Selected = true;
                    break;
                }
            }
        }
        if (stuInfo.StuIDNumber != null )
        {
            tbNum.Text = stuInfo.StuIDNumber;
        }
        if (stuInfo.MarStatus != -1)
        {
            if(stuInfo.MarStatus == 1 )
            {
                ddlMarStatus.SelectedIndex = 1;
            }
            else
            {
                ddlMarStatus.SelectedIndex = 2;
            }
        }
        if (stuInfo.MobPhone != null )
        {
            tbMobile.Text = stuInfo.MobPhone;
        }
        if (stuInfo.FixedPhone != null )
        {
            tbFixPhone.Text = stuInfo.FixedPhone;
        }
        if (stuInfo.EmailAddress != null )
        {
            tbEmail.Text = stuInfo.EmailAddress;
        }
        if (stuInfo.Address != null )
        {
            tbAddress.Text = stuInfo.Address;
        }
        if (stuInfo.PostalCode != null )
        {
            tbPostalcode.Text = stuInfo.PostalCode;
        }
        if (stuInfo.HomeAddress != null)
        {
            tbHomeAddress.Text = stuInfo.HomeAddress;
        }
        if (stuInfo.WorkPlace != null)
        {
            tbCompany.Text = stuInfo.WorkPlace;
        }
        if (stuInfo.WorkPlaceAdd != null)
        {
            tbCompanyAddress.Text = stuInfo.WorkPlaceAdd;
        }
        if (stuInfo.TeacherName != null)
        {
            tbTutorName.Text = stuInfo.TeacherName;
        }
        if (stuInfo.Schooling != null)
        {
            tbSchooling.Text = stuInfo.Schooling;
        }
        if (stuInfo.Degree != null)
        {
            tbDegree.Text = stuInfo.Degree;
        }
        if (stuInfo.Grade != null)
        {
            tbGrade.Text = stuInfo.Grade;
        }
        if (stuInfo.GraduateTime != null)
        {
            tbLeaveTime.Text = stuInfo.GraduateTime;
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
            imgStudent.ImageUrl = imagePath;
        }
    }
    protected void btSavePassword_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            StudentManage stuMage = new StudentManage();
            bool updateRes = stuMage.RevisePassword(studentID, tbOldPassword.Text.Trim(), tbNewPassword.Text.Trim());
            if (updateRes == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('"+stuMage.errorMsg+"')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码修改成功！')</script>");
                tbOldPassword.Text = "";
                tbNewPassword.Text = "";
                tbPasswordAgain.Text = "";
            }
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }
    protected void ddlYear_PreRender(object sender, EventArgs e)
    {
        
    }
    protected void btSaveContact_Click(object sender, EventArgs e)
    {
        StudentInfo sInfo = new StudentInfo();
        StudentManage sMag = new StudentManage();
        sInfo.StuName = tbName.Text.Trim();
        sInfo.StuID = tbStuNum.Text.Trim();
        if (tbMobile.Text.Trim() != "")
        {
            sInfo.MobPhone = tbMobile.Text.Trim();
        }
        if (tbFixPhone.Text.Trim() != "")
        {
            sInfo.FixedPhone = tbFixPhone.Text.Trim();
        }
        if (tbEmail.Text.Trim() != "")
        {
            sInfo.EmailAddress = tbEmail.Text.Trim();
        }
        if (tbAddress.Text.Trim() != "")
        {
            sInfo.Address = tbAddress.Text.Trim();
        }
        if (tbPostalcode.Text.Trim() != "")
        {
            sInfo.PostalCode = tbPostalcode.Text.Trim();
        }
        if (tbHomeAddress.Text.Trim() != "")
        {
            sInfo.HomeAddress = tbHomeAddress.Text.Trim();
        }
        if (tbCompany.Text.Trim() != "")
        {
            sInfo.WorkPlace = tbCompany.Text.Trim();
        }
        if (tbCompanyAddress.Text.Trim() != "")
        {
            sInfo.WorkPlaceAdd = tbCompanyAddress.Text.Trim();
        }
        if (true == sMag.UpdateStudentInfobyTransaction(sInfo))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败，请重试！')</script>");
        }
    }
    protected void btUploadImage_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            //判断上传文件是不是图片
            if (FileUpload1.PostedFile.ContentType.Contains("image") == false)
            { 
                //不是图片
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你上传的不是图片，请确认后重新上传！')</script>");
                return;
            }
            int MaxLength = 1024 * 1024 * 2;//最大为2M
            //判断上传文件的大小是否大于2M
            if (FileUpload1.PostedFile.ContentLength > MaxLength)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上传照片过大，请换张小的上传！')</script>");
                return;
            }
            DocumentManage dMag = new DocumentManage();
            StudentManage sMag = new StudentManage();
            DataSet ds = null;
            ds = sMag.GetStudentPicture(studentID);
            //当前账号在数据库中是否已有照片信息
            if (ds.Tables[0].Rows.Count > 0)
            {
                //更新照片
                int attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
                string imgPath = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
                string oldPath = Server.MapPath(imgPath);
                File.Delete(oldPath);
                string imageName = FileUpload1.FileName;
                string grade = sMag.GetGradebyStuID(studentID);
                string newPath = @"../Resources/StudentPhotos/" + grade + "/" + imageName;
                string filePath = Server.MapPath(newPath);
                FileUpload1.SaveAs(filePath);
                if (sMag.UpdateStudentPicture(studentID, newPath) == true)
                {
                    //更新成功
                    imgStudent.ImageUrl = newPath;
                }
                else
                {
                    //更新失败
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('照片更新失败！')</script>");
                }
            }
            else
            { 
                //上传照片
                string imageName = FileUpload1.FileName;
                string grade = sMag.GetGradebyStuID(studentID);
                string imagePath = @"../Resources/StudentPhotos/" + grade + "/" + imageName;
                string filePath = Server.MapPath(imagePath);
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))  //判断文件目录是否存在
                {
                    //不存在对现有目录的引用
                    Directory.CreateDirectory(directory);
                }
                else
                {
                    //存在对现有目录的引用,则删除已有文件
                    File.Delete(filePath);
                }
                //将照片保存到服务器上
                FileUpload1.SaveAs(filePath);
                //保存照片的地址到数据库中并返回ID
                if (sMag.AddStudentPicture(studentID, imagePath, studentID.ToString()) == true)
                {
                    //保存成功
                    imgStudent.ImageUrl = imagePath;
                }
                else
                { 
                    //保存失败
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上传照片失败，请重试！')</script>");
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择需要上传的照片！')</script>");
        }
    }
}
