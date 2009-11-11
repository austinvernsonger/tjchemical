using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// 页面：SysMgr_MmtMgr - 富文本管理页面
/// 作者：Constantine
/// 最近一次修改时间：2009-6-3
/// </summary>
public partial class SysMgr_MmtMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        mmtList.OnDelete = SysCom.MMTInformation.getevent();
        mmtList.OnMarkDelete = SysCom.MMTInformation.getevent();
        mmtList.OnRecover = SysCom.MMTInformation.getevent();
        if (!IsPostBack)
        {
            mmtList.Mode = SysCom.PSGMODE.News;
        }
    }

    public void Test(int count)
    {
        Response.Write(count.ToString());
    }

    protected void lbNotice_Click(object sender, EventArgs e)
    {
        mmtList.ShowURL = "~/News/NoticeEdit.aspx";
        titleh3.InnerText = "通知管理";
        mmtList.Mode = SysCom.PSGMODE.Notice;
    }
    protected void lbNews_Click(object sender, EventArgs e)
    {
        mmtList.ShowURL = "~/News/NewsEdit.aspx";
        titleh3.InnerText = "新闻管理";
        mmtList.Mode = SysCom.PSGMODE.News;
    }
    protected void lbActivity_Click(object sender, EventArgs e)
    {
        mmtList.ShowURL = "~/News/ActivityEdit.aspx";
        titleh3.InnerText = "活动管理";
        mmtList.Mode = SysCom.PSGMODE.Activity;
    }
}
