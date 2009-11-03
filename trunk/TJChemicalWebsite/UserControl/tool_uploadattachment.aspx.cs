using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class UserControl_tool_uploadattachment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Show the Attachment List
        msg_lb.Text = Request.QueryString ["msg_lb"];
        result_pnl.Controls.Clear();
        // Initialize the check list.
        if ( Session ["CheckList"] == null || ( Session ["CheckList"] as List<SysCom.Attachment> ).Count == 0 )
            result_pnl.Style.Add( "display", "none" );
        else
        {
            foreach ( SysCom.Attachment attach in Session ["CheckList"] as List<SysCom.Attachment> )
            {
                HtmlGenericControl _div = new HtmlGenericControl( "div" );
                CheckBox tmp = new CheckBox( );
                tmp.ID = attach.FileName;
                tmp.Text = string.Format( "{0}.{1}", attach.FileName, attach.FileExtension );
                tmp.Checked = true;
                tmp.CheckedChanged += new EventHandler( AttachCheckedChanged );
                tmp.CssClass = "ChkBox";
                tmp.AutoPostBack = true;
                _div.Controls.Add( tmp );
                result_pnl.Controls.Add( _div );
            }
        }
    }

    void AttachCheckedChanged(object sender, EventArgs e)
    {
        String msg = "";
        CheckBox tmp = (CheckBox)sender;
        List<SysCom.Attachment> tmpList = Session ["CheckList"] as List<SysCom.Attachment>;
        if (!tmp.Checked)
        {
            tmpList.Remove(new SysCom.Attachment(tmp.ID, tmp.Text.Substring(tmp.ID.Length + 1)));
            System.IO.FileInfo tmpAttach = new System.IO.FileInfo(
                string.Format(@"{0}\Files\Attachments\{1}\{2}", SMBL.Global.WebSite.AppPath, 
                    Session["__post__mmt__id"] as string, tmp.Text));
            try { tmpAttach.Delete(); }
            catch (Exception exp)
            {
                SMBL.Core.ErrorSystem.CatchError(exp);
                msg = "Error! " + exp.Message;
            }
        }
        else
            tmpList.Add(new SysCom.Attachment(tmp.ID, tmp.Text.Substring(tmp.ID.Length + 1)));
        Session["CheckList"] = tmpList;
        Response.Redirect("~/UserControl/tool_uploadattachment.aspx?msg_lb=" + msg);
        //msg_lb.Text = msg;
        //udpnl_attachs.Update( );
    }

    /// <summary>
    /// Upload the Attachment.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void upload_btn_Click(object sender, EventArgs e)
    {
        msg_lb.Text = "";
        // Upload the attachment
        if (attachment_upload.HasFile)
        {
            // Get File Extension
            Int32 tmpIndex = attachment_upload.FileName.LastIndexOf('.');
            String fileExtension = attachment_upload.FileName.Substring(tmpIndex + 1,
                attachment_upload.FileName.Length - tmpIndex - 1);
            fileExtension = fileExtension.ToLower();
            String fileName = attachment_upload.FileName.Substring( 0, tmpIndex );
            // Generate File Path
            try
            {
                string destFolder = string.Format( @"{0}\Files\Attachments\{1}",
                    SMBL.Global.WebSite.AppPath,
                    Session ["__post__mmt__id"] as string );
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo( destFolder );
                dir.Create( );
                string destFilePath = string.Format( @"{0}\{1}",
                    destFolder,
                    attachment_upload.FileName );
                attachment_upload.SaveAs(destFilePath);
            }
            catch (Exception exp)
            {
                SMBL.Core.ErrorSystem.CatchError(exp);
                msg_lb.Text = "上传失败!" + exp.Message;
                return;
            }

            // Set the Session
            List<SysCom.Attachment> CheckList = (Session["CheckList"] == null) ?
                new List<SysCom.Attachment>() : (List<SysCom.Attachment>)Session["CheckList"];
            CheckList.Add(new SysCom.Attachment(fileName, fileExtension));
            Session["CheckList"] = CheckList;

            // Update the Message
            msg_lb.Text = fileName + "." + fileExtension + "上传成功！";
        }
        else msg_lb.Text = "请选择文件。";
        Response.Redirect(
            "~/UserControl/tool_uploadattachment.aspx?msg_lb=" 
            + msg_lb.Text);
        //udpnl_attachs.Update( );
    }
}
