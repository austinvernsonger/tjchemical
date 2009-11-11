using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching.Ops;
using System.Data;

public partial class Teaching_LinkListEx : System.Web.UI.UserControl
{

    protected String strQuerySQL = null;

    public String QuerySQL
    {
        set
        {
            strQuerySQL = value;
        }
        get { return strQuerySQL; }
    }

    public Boolean IfSort
    {
        set
        {
            LinkListView.AllowSorting = value;
        }
        get { return LinkListView.AllowSorting; }
    }

    protected String strTargetPage = "/Teaching/Content.aspx";
    public String TargetPage
    {
        set
        {
            strTargetPage = value;
        }
        get { return strTargetPage; }
    }

    protected String strTargetPageSE = "";
    public String TargetPageSE
    {
        set
        {
            strTargetPageSE = value;
            strTargetPageSE += strTargetPageSE.IndexOf("?") == -1 ? "?ID=" : "&ID=";
        }
        get { return strTargetPageSE; }
    }

    protected String strTargetPageSEToolTip = "编辑出差总结";
    public String TargetPageSEToolTip
    {
        set
        {
            strTargetPageSEToolTip = value;
        }
        get { return strTargetPageSEToolTip; }
    }

    protected String strDeleteString="";

    public String DeleteString
    {
        set
        {
            strDeleteString = value;
        }
        get { return strDeleteString; }
    }

    public void ReBindData()
    {
        SQLstr.Text = strQuerySQL;
        LinkListView.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["DeleteID"] != null)
        {
            if (DeleteString.Length != 0)
            {
               opsTeachingExec opsExec = new opsTeachingExec(DeleteString + Request.QueryString["DeleteID"]);
               opsExec.Do();
               String url = HttpContext.Current.Request.CurrentExecutionFilePath;
               if (PostParam.Text.Length != 0) url += (url.IndexOf("?") == -1 ? "?" : "&") + PostParam.Text;
               HttpContext.Current.Response.Redirect(url);
            
            }
        }
        else if (Request.QueryString["DocumentID"] == null)
        {
            int i = Request.RawUrl.IndexOf("?");
            if( i!=-1 ){
                PostParam.Text = Request.RawUrl.Substring(i+1);
            }
            ReBindData();
        }
        else
        {
            opsTeachingQuery opsSelect = new opsTeachingQuery(strQuerySQL);
            opsSelect.Do();
            if (opsSelect.mResult.Tables.Count != 1) return;
            if (opsSelect.mResult.Tables[0].Columns["ID"] == null) return;
            if (opsSelect.mResult.Tables[0].Columns["Title"] == null) return;
            if (opsSelect.mResult.Tables[0].Columns["Content"] == null) return;
            if (opsSelect.mResult.Tables[0].Columns["ContentType"] == null) return;
            

            DataColumn[] keys = new DataColumn[1];
            keys[0] = opsSelect.mResult.Tables[0].Columns["ID"];
            opsSelect.mResult.Tables[0].PrimaryKey = keys;
            DataRow result = opsSelect.mResult.Tables[0].Rows.Find(Request.QueryString["DocumentID"]);
            if (result == null) return;
            switch(result["ContentType"].ToString())
            {
            case "0":
                String ContentID = Request.FilePath + Request.QueryString["DocumentID"];
                Session.Add(ContentID, result["Content"]);
                strTargetPage += strTargetPage.IndexOf("?") == -1 ?"?ID=":"&ID=";
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.ApplicationPath + strTargetPage + ContentID);
                break;

            case "1":
                FileDown(result["Content"].ToString());
                break;

            case "2":
                strTargetPage += strTargetPage.IndexOf("?") == -1 ? "?ID=" : "&ID=";
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.ApplicationPath + strTargetPage + Request.QueryString["DocumentID"]);
                break;
            }

        }

    }
    public String GetDownLoadString(String URL)
    {
        return URL;
    }

    private void FileDown(string strPathName)
    {

        System.IO.FileInfo fileInfo = new System.IO.FileInfo(strPathName);
        if (fileInfo.Exists)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }
        else
        {
           // ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'>alert('文件不存在!');</script>");
        }
    }

}
