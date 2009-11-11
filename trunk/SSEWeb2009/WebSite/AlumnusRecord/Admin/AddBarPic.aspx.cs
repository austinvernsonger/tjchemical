using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class AlumnusRecord_Admin_AddBarPic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    private bool AddBarPic(FileUpload up,String name)
    {
        if (!up.HasFile)
        {
            return false;
        }
        string imageExtensions = ".jpg|.gif|.png|.bmp";
        string fileExtension = System.IO.Path.GetExtension(up.FileName);
        
        if (imageExtensions.IndexOf(fileExtension) == -1)
        {

            return false;
        }
      


        string fileName = @"~/AlumnusRecord/Resources/BarPic/" + name;

        if (File.Exists(Server.MapPath(fileName)))
        {
            File.Delete(Server.MapPath(fileName));
        }

        up.SaveAs(Server.MapPath(fileName));
        return true;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


       

        if(AddBarPic(this.FileUpload1, "BarLeft1.bmp"))
        {
            this.Label5.Text = "修改成功";
        }
        else
        {
            this.Label5.Text = "修改失败";
        }
        if (AddBarPic(this.FileUpload2, "BarLeft2.bmp"))
        {
            this.Label6.Text = "修改成功";
        }
        else
        {
            this.Label6.Text = "修改失败";
        }






        if (AddBarPic(this.FileUpload3, "BarRight1.bmp"))
        {
            this.Label7.Text = "修改成功";
        }
        else
        {
            this.Label7.Text = "修改失败";
        }

        if (AddBarPic(this.FileUpload4, "BarRight2.bmp"))
        {
            this.Label8.Text = "修改成功";
        }
        else
        {
            this.Label8.Text = "修改失败";
        }


      
          

            
       
    }
}
