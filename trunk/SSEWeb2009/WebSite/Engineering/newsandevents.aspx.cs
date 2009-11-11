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

public partial class Engineering_newsandevents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["pid"] == null || Convert.ToInt32(Request["pid"]) == 40)
        {
                //硕士新闻
                lblTitle.Text = "<h1>硕士新闻<br />News</h1>";
                lblTitle2.Text = "<h1>同济大学软件学院工程硕士新闻</h1>";
                 MMTList1.Mode = SysCom.PSGMODE.News;
                MMTList1.EmptyString = "当前没有新闻信息";
         }
         else
         {
                //硕士通知
                lblTitle.Text = "<h1>硕士通知<br />Notice</h1>";
                lblTitle2.Text = "<h1>同济大学软件学院工程硕士通知</h1>";
                MMTList1.Mode = SysCom.PSGMODE.Notice;
                MMTList1.EmptyString = "当前没有通知信息";
         }
        MMTList1.Management = false;
        MMTList1.DepartmentId = 4;          
        MMTList1.PageSize = 20;
        MMTList1.InternalOnly = true;
        MMTList1.ShowURL = "../Engineering/Details.aspx";
        MMTList1.ShowTime = true;
        MMTList1.Target = "_blank";
    }
}
