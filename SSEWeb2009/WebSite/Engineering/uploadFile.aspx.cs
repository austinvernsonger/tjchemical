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
using System.IO;
using Department.Engineering;

public partial class Engineering_uploadFile : System.Web.UI.Page
{
    private string studentID;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["id"]);
        studentID = Request["stuid"].ToString();
        string strFileName;
        string strFileExtension;
        int intLastIndex;
        if (Request.Files.Count == 1)
        {
            try
            {
                strFileName = myFile.PostedFile.FileName;
                strFileExtension = Path.GetExtension(strFileName).ToLower();
                intLastIndex = strFileName.LastIndexOf("\\");
                if (intLastIndex > 0)
                {
                    if (strFileExtension != ".doc" && strFileExtension != ".docx")
                    {
                        Response.Write("<script>parent.CallBackMsg('只能上传Word文件(doc或docx)')</script>");
                        return;
                    }
                    //文件存在
                    if (id == 1)
                    { 
                        //上传开题报告
                        uploadOpeningSpeech(strFileName);
                    }
                    if (id == 2)
                    {
                        //上传校导信息
                        uploadOutTeacherInfo(strFileName);
                    }
                    if (id == 3)
                    {
                        //上传中期考核表
                        uploadMiddleForm(strFileName);
                    }
                    if (id == 4)
                    { 
                        //上传论文初稿
                        uploadPaper(strFileName);
                    }
                    if (id == 5)
                    {
                        //上传待评审论文
                        uploadFinalPaper(strFileName);
                    }
                }
                else
                {
                    Response.Write("<script>parent.CallBackMsg('nil')</script>");
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>parent.CallBackMsg('" + exc.Message + "')</script>");
            }
        }
    }
    protected void uploadMiddleForm(string strFileName)
    {
        //上传中期考核表
        int attachID;
        DocumentManage dMag = new DocumentManage();
        DataSet ds = null;
        ds = dMag.GetAttachment(studentID, 2);
        //返回该生所提交的中期考核表信息
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>parent.CallBackMsg('中期考核表已丢失，请重新上传')</script>");
            return;
        }
        attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
        string oldAttachUrl = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
        StudentManage sMag = new StudentManage();
        DiscussionInfo dInfo = new DiscussionInfo();
        string name = Path.GetFileName(strFileName);
        if (Path.GetExtension(strFileName) == ".doc")
        {
            name = name.Substring(0, name.Length - 4);
        }
        if (Path.GetExtension(strFileName) == ".docx")
        {
            name = name.Substring(0, name.Length - 5);
        }
        string grade = sMag.GetGradebyStuID(studentID);
        string extension = Path.GetExtension(strFileName);
        string newName = studentID + extension;
        //当前到服务器中的路径
        string newPath = @"../Engineering/MsUpload/zq/" + grade + "/" + newName;
        //保存进数据库中的路径
        string virtualPath = @"../MsUpload/zq/" + grade + "/" + newName;
        string directory = Path.GetDirectoryName(Server.MapPath(newPath));
        //判断中期表的路径是否存在
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if(File.Exists(Server.MapPath(oldAttachUrl)))
        {
            File.Delete(Server.MapPath(oldAttachUrl));
        }
        //将中期考核表保存到服务器上
        myFile.PostedFile.SaveAs(Server.MapPath(newPath));
        if (dMag.updateMidFormByStu(attachID, virtualPath, name) == true)
        {
            //更新成功
            //添加评论信息
            ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 3);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
                dInfo.Title = name;
                dInfo.Body = "更新了中期考核表";
                dInfo.Category = 3;
                dInfo.Status = "10";
                dInfo.Communicators = dr["Communicators"].ToString();
                dInfo.AttachID = Convert.ToInt32(dr["AttachID"]);
                if (dInfo.AddDiscussionInfo() == true)
                {
                    Response.Write("<script>parent.CallBackMsg('上传成功')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>parent.CallBackMsg('上传失败')</script>");
        }
    }
    protected void uploadPaper(string strFileName)
    {
        //上传论文初稿
        int attachID;
        DocumentManage dMag = new DocumentManage();
        DataSet ds = null;
        ds = dMag.GetAttachment(studentID, 3);
        //返回该生所提交的论文初稿
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>parent.CallBackMsg('论文初稿已丢失，请重新上传')</script>");
            return;
        }
        attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
        string oldAttachUrl = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
        StudentManage sMag = new StudentManage();
        DiscussionInfo dInfo = new DiscussionInfo();
        string name = Path.GetFileName(strFileName);
        if (Path.GetExtension(strFileName) == ".doc")
        {
            name = name.Substring(0, name.Length - 4);
        }
        if (Path.GetExtension(strFileName) == ".docx")
        {
            name = name.Substring(0, name.Length - 5);
        }
        string grade = sMag.GetGradebyStuID(studentID);
        string extension = Path.GetExtension(strFileName);
        string newName = studentID + extension;
        //当前到服务器中的路径
        string newPath = @"../Engineering/MsUpload/paper/" + grade + "/" + newName;
        //保存进数据库中的路径
        string virtualPath = @"../MsUpload/paper/" + grade + "/" + newName;
        string directory = Path.GetDirectoryName(Server.MapPath(newPath));
        //判断论文初稿路径是否存在
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(Server.MapPath(oldAttachUrl)))
        {
            File.Delete(Server.MapPath(oldAttachUrl));
        }
        //将论文初稿保存到服务器上
        myFile.PostedFile.SaveAs(Server.MapPath(newPath));
        if (dMag.updatePaper(attachID, virtualPath, name) == true)
        {
            //更新成功
            //添加评论信息
            ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 4);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
                dInfo.Title = name;
                dInfo.Body = "更新了论文初稿";
                dInfo.Category = 4;
                dInfo.Status = "10";
                dInfo.Communicators = dr["Communicators"].ToString();
                dInfo.AttachID = Convert.ToInt32(dr["AttachID"]);
                if (dInfo.AddDiscussionInfo() == true)
                {
                    Response.Write("<script>parent.CallBackMsg('更新成功')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>parent.CallBackMsg('更新失败，请重试')</script>");
        }
    }
    protected void uploadFinalPaper(string strFileName)
    {
        //上传论文初稿
        int attachID;
        StudentManage sMag = new StudentManage();
        DocumentManage dMag = new DocumentManage();
        DataSet ds = null;
        ds = dMag.GetAttachment(studentID, 5);
        //返回该生所提交的论文初稿
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>parent.CallBackMsg('论文初稿已丢失，请重新上传')</script>");
            return;
        }
        attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
        string oldAttachUrl = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
        string name = Path.GetFileName(strFileName);
        if (Path.GetExtension(strFileName) == ".doc")
        {
            name = name.Substring(0, name.Length - 4);
        }
        if (Path.GetExtension(strFileName) == ".docx")
        {
            name = name.Substring(0, name.Length - 5);
        }
        string grade = sMag.GetGradebyStuID(studentID);
        string extension = Path.GetExtension(strFileName);
        string newName = studentID + extension;
        //当前到服务器中的路径
        string newPath = @"../Engineering/MsUpload/final/" + grade + "/" + newName;
        //保存进数据库中的路径
        string virtualPath = @"../MsUpload/final/" + grade + "/" + newName;
        string directory = Path.GetDirectoryName(Server.MapPath(newPath));
        //判断论文初稿路径是否存在
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(Server.MapPath(oldAttachUrl)))
        {
            File.Delete(Server.MapPath(oldAttachUrl));
        }
        //将论文初稿保存到服务器上
        myFile.PostedFile.SaveAs(Server.MapPath(newPath));
        if (dMag.updatePaper(attachID, virtualPath, name) == true)
        {
            //更新成功
            Response.Write("<script>parent.CallBackMsg('更新成功')</script>");
        }
        else
        {
            Response.Write("<script>parent.CallBackMsg('更新失败，请重试')</script>");
        }
    }
    protected void  uploadOutTeacherInfo(string strFileName)
    {
        //上传校外导师
        int attachID;
        DocumentManage dMag = new DocumentManage();
        DataSet ds = null;
        ds = dMag.GetAttachment(studentID, 4);
        //返回该生所提交的校外导师信息
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>parent.CallBackMsg('校外导师信息已丢失，请重新上传')</script>");
            return;
        }
        attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
        string oldAttachUrl = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
        StudentManage sMag = new StudentManage();
        DiscussionInfo dInfo = new DiscussionInfo();
        string name = Path.GetFileName(strFileName);
        if (Path.GetExtension(strFileName) == ".doc")
        {
            name = name.Substring(0, name.Length - 4);
        }
        if (Path.GetExtension(strFileName) == ".docx")
        {
            name = name.Substring(0, name.Length - 5);
        }
        string grade = sMag.GetGradebyStuID(studentID);
        string extension = Path.GetExtension(strFileName);
        string newName = studentID + extension;
        //当前到服务器中的路径
        string newPath = @"../Engineering/MsUpload/outteacher/" + grade + "/" + newName;
        //保存进数据库中的路径
        string virtualPath = @"../MsUpload/outteacher/" + grade + "/" + newName;
        string directory = Path.GetDirectoryName(Server.MapPath(newPath));
        //判断校外导师路径是否存在
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(Server.MapPath(oldAttachUrl)))
        {
            File.Delete(Server.MapPath(oldAttachUrl));
        }
        //将校外导师表保存到服务器上
        myFile.PostedFile.SaveAs(Server.MapPath(newPath));
        if (dMag.updateOutTeacher(attachID, virtualPath, name) == true)
        {
            //更新成功
            //添加评论信息
            ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 2);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
                dInfo.Title = name;
                dInfo.Body = "更新了校外导师信息表";
                dInfo.Category = 2;
                dInfo.Status = "10";
                dInfo.Communicators = dr["Communicators"].ToString();
                dInfo.AttachID = Convert.ToInt32(dr["AttachID"]);
                if (dInfo.AddDiscussionInfo() == true)
                {
                    Response.Write("<script>parent.CallBackMsg('更新成功')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>parent.CallBackMsg('更新失败，请重试')</script>");
        }
    }
    protected void uploadOpeningSpeech(string strFileName)
    {
        //上传开题报告
        int attachID;
        DocumentManage dMag = new DocumentManage();
        DataSet ds = null;
        ds = dMag.GetAttachment(studentID, 1);
        //返回该生所提交的校外导师信息
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>parent.CallBackMsg('开题报告信息已丢失，请重新上传')</script>");
            return;
        }
        attachID = Convert.ToInt32(ds.Tables[0].Rows[0]["AttachID"]);
        string oldAttachUrl = ds.Tables[0].Rows[0]["AttachNameUrl"].ToString();
        StudentManage sMag = new StudentManage();
        DiscussionInfo dInfo = new DiscussionInfo();
        string name = Path.GetFileName(strFileName);
        if (Path.GetExtension(strFileName) == ".doc")
        {
            name = name.Substring(0, name.Length - 4);
        }
        if (Path.GetExtension(strFileName) == ".docx")
        {
            name = name.Substring(0, name.Length - 5);
        }
        string grade = sMag.GetGradebyStuID(studentID);
        string extension = Path.GetExtension(strFileName);
        string newName = studentID + extension;
        //当前到服务器中的路径
        string newPath = @"../Engineering/MsUpload/kt/" + grade + "/" + newName;
        //保存进数据库中的路径
        string virtualPath = @"../MsUpload/kt/" + grade + "/" + newName;
        string directory = Path.GetDirectoryName(Server.MapPath(newPath));
        //判断开题报告路径是否存在
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(Server.MapPath(oldAttachUrl)))
        {
            File.Delete(Server.MapPath(oldAttachUrl));
        }
        //将校外导师表保存到服务器上
        myFile.PostedFile.SaveAs(Server.MapPath(newPath));
        if (dMag.updateOpenSpeechByAttachID(attachID, virtualPath, name) == true)
        {
            //更新成功
            //添加评论信息
            ds = dInfo.GetFirstDiscussionRelatedtoStudent(studentID, 1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dInfo.DisplayOrdery = dr["DisplayOrder"].ToString();
                dInfo.Title = name;
                dInfo.Body = "更新了开题报告信息表";
                dInfo.Category = 1;
                dInfo.Status = "10";
                dInfo.Communicators = dr["Communicators"].ToString();
                dInfo.AttachID = Convert.ToInt32(dr["AttachID"]);
                if (dInfo.AddDiscussionInfo() == true)
                {
                    Response.Write("<script>parent.CallBackMsg('更新成功')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>parent.CallBackMsg('更新失败，请重试')</script>");
        }
    }
}
