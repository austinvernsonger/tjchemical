using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_DownloadingPageMng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        opsTeachingQuery QueryName = new opsTeachingQuery("select Name, Gender, Birthday, Address, Telephone, Fax, Email, Title, Post, Memo from Teacher where TeacherID = '" + Session["IdentifyNumber"].ToString()+ "'");
        QueryName.Do();
        if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile)
        {
            int MaxLength = 1024 * 1024 * 30;//最大为30M
            string name = this.FileUpload1.FileName;
            if (this.FileUpload1.PostedFile.ContentLength > MaxLength)//限定上传大小为30MB
            {
                Response.Write("<script>alert('上传文件的大小超过了30MB的最大容量！请压缩后再上传！')</script>");
                return;
            }
            string filepath = MapPath("../../Files/Teaching/" + name);


            if (!File.Exists(filepath))
            {
                String sql = "insert into TemplateFile(Title, Content) values(\'" + name + "\', \'" + filepath + "\')";
                opsTeachingExec opsInsert = new opsTeachingExec(sql);
                opsInsert.Do();
                this.FileUpload1.SaveAs(filepath);//这个是主要的完成上传的代码
            }
            else
            {
                Response.Write("<script>alert('文件已存在，请重命名后再上传！')</script>");
                return;
            }
            Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=8");
        }
        else
        {
            Response.Write("<script>alert('你选择的文件格式不符合要求！')</script>");
            return;
        }
    }
}
