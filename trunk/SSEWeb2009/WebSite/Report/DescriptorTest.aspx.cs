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

using Report.Descriptor;

public partial class Report_DescriptorTest : System.Web.UI.Page
{
    ReportDescriptor report;

    protected void Page_Load(object sender, EventArgs e)
    {
        Report.Serializer.ReportSerializer s = new Report.Serializer.ReportSerializer("F://3.txt");
        report = s.Deserialize();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
}
