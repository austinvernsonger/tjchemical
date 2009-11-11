using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using AjaxControlToolkit;

public partial class AlumnusRecord_Admin_manageMien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn1 = sender as Button;
            TextBox tb1 = (TextBox)btn1.Parent.FindControl("TextBox1");
            FileUpload fu1 = (FileUpload)btn1.Parent.FindControl("FileUpload1");
            string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string fileName = @"~/AlumnusRecord/Resources/images/temp/" + str + Path.GetExtension(fu1.FileName);
            string Src = "Resources/images/temp/" + str + Path.GetExtension(fu1.FileName);
            if (File.Exists(Server.MapPath(fileName)))
            {
                File.Delete(Server.MapPath(fileName));
            }
            fu1.SaveAs(Server.MapPath(fileName));
            tb1.Text = Src;
        }
        catch
        {

        }
    }
    
}
