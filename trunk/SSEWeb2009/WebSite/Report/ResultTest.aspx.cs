using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Report.Serializer;
using Report.Descriptor;
using System.Web.Hosting;

public partial class Report_ResultTest : System.Web.UI.Page
{
    const string ReportDescriptorSessionName = "Result_ReportDescriptorSessionName_ResultPage";
    const string ReportResultSessionName = "Result_ReportResultSessionName_ResultPage";

    protected void Page_Load(object sender, EventArgs e)
    {
        // StatisticsControl1.SetReportDescriptorFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\Test.xml");
        // StatisticsControl1.SetReportResultFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\TestResult.xml");
         StatisticsControl1.SetReportDescriptorFilePath(Session[ReportDescriptorSessionName] as string);
         StatisticsControl1.SetReportResultFilePath(Session[ReportResultSessionName] as string);
    }
}
