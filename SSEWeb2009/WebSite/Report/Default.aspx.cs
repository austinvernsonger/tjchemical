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

public partial class Report_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String prefix = Request.ApplicationPath;
            if (!prefix.EndsWith("/")) prefix += "/";
            string DescriptorID = Request["ReportFormID"];
            string ResultID = Request["ReportDataId"];
            if (DescriptorID == "")
            {
                Editor1.SetReportDescriptorFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\Test.xml");
                Editor1.SetReportResultFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\TestResult.xml");
                return;
            }
            Editor1.SetReportDescriptorFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\Form\\" + DescriptorID + "Descriptor.xml");
            Editor1.SetReportResultFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\Data\\" + ResultID + "Result.xml");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Editor1.SaveDescriptor();
    }
}
