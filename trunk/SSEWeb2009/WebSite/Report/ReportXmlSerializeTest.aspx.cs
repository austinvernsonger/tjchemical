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

using System.Xml;
using Report;
using System.IO;
using Report.Descriptor;
using System.Xml.Serialization;

public partial class Report_ReportTest : System.Web.UI.Page
{
    ReportDescriptor rd;
    ItemDescriptor id;
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            rd = new ReportDescriptor();

            id = new ItemDescriptor();

            rd.Items.Add(id);
        }
        catch (System.Exception ex)
        {
            ex.ToString();
        }



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Report.Serializer.ReportSerializer s = new Report.Serializer.ReportSerializer("F://3.txt");
            s.Serialize(rd);
        }
        catch (System.Exception ex)
        {
            this.Label1.Text = ex.Message;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Report.Serializer.ReportSerializer s = new Report.Serializer.ReportSerializer("F://3.txt");
            rd = s.Deserialize();
        }
        catch (System.Exception ex)
        {
            this.Label1.Text = ex.Message;
        }
    }
}
