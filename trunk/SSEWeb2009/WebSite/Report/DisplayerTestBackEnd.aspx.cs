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
using System.Web.Hosting;

public partial class Report_DisplayerTestBackEnd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Displayer1.SetReportDescriptorFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\Test.xml");
        Displayer1.SetReportResultFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\TestResult.xml");
        Displayer1.SetDisplayMode(Report.Descriptor.DisplayMode.DisplayBack);
    }
}
