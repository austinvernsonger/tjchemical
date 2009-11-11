using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlumnusRecord;
using System.Drawing;


public partial class addGrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Add_Click(object sender, EventArgs e)
    {
        GradeManager gm = new GradeManager();

        gm.GradeInfoPath = System.Web.HttpContext.Current.Server.MapPath(@"~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml");
        gm.ImageLocation = @"~/AlumnusRecord/Resources/GraduatingPhotographs";

        string gradYear = this.DropDownListGradYear.SelectedValue;
        int degree = Convert.ToInt32(this.DropdownlistDegree.SelectedValue);

        if (gm.Exists(degree, gradYear))
        {
            this.LabelResult.Text = "已存在" + gradYear + "级" + this.DropdownlistDegree.SelectedItem.Text + "毕业班";
            this.LabelResult.ForeColor = Color.Red;
            return;
        }

        string imageExtensions = ".jpg|.gif|.png|.bmp";
        string fileExtension = System.IO.Path.GetExtension(this.FileUploadImage.FileName);

        if (imageExtensions.IndexOf(fileExtension) == -1)
        {
            this.LabelResult.Text = "请上传图片";
            this.LabelResult.ForeColor = Color.Red;
            return;
        }

        string imageRelativeLoc = "";

        bool isSuccess = gm.UploadGradeImage(this.FileUploadImage, this.DropdownlistDegree.SelectedItem.Text, gradYear, null, ref imageRelativeLoc);

        if (isSuccess)
        {
            Grade grade = new Grade();
            grade.Degree = degree;
            grade.GradYear = gradYear;
            grade.GradImageLocation = imageRelativeLoc;
            if (gm.AddGrade(grade))
            {
                this.LabelResult.Text = gradYear + "级" + this.DropdownlistDegree.SelectedItem.Text + "毕业班信息添加成功";
                this.LabelResult.ForeColor = Color.Blue;
            }
            else
            {
                this.LabelResult.Text = gradYear + "级" + this.DropdownlistDegree.SelectedItem.Text + "毕业班信息添加失败";
                this.LabelResult.ForeColor = Color.Red;
            }
        }
        else
        {
            this.LabelResult.Text = "上传图片失败";
            this.LabelResult.ForeColor = Color.Red; 
        }
    }
}
