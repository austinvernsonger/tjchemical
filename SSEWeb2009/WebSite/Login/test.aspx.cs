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
using System.Text;
using System.IO;
public partial class Login_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //         GridView1.DataSource = SysCom.MMTInformation.GetActivityInfo();
        //         GridView1.DataBind();
        //         Response.Clear();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/xml";
        WriteXML();
    }

    public void WriteXML()
    {
        //SysCom.MMTStatic a = new SysCom.MMTStatic();
        DataTable dt = SysCom.MMTInformation.GetActivityInfo();
        StringBuilder xmlData = new StringBuilder();
        xmlData.AppendLine(@"<?xml version='1.0' encoding='UTF-8' ?>");
        xmlData.AppendLine(@"<root>");

        foreach (DataRow dr in dt.Rows)
        {
            String Title = dr["Title"].ToString();
            String StartTime = dr["StartTime"].ToString();
            String EndTime = dr["EndTime"].ToString();
            String Location = dr["Location"].ToString();
            String ID = dr["ID"].ToString();
            xmlData.Append((@"<Activity>"));
            xmlData.Append((@"<Title>" + Title + "</Title>"));
            xmlData.Append((@"<StartTime>" + StartTime + "</StartTime>"));
            xmlData.Append((@"<EndTime>" + EndTime + "</EndTime>"));
            xmlData.Append((@"<Location>" + Location + "</Location>"));
            xmlData.Append((@"<ID>" + ID + "</ID>"));
            xmlData.Append((@"</Activity>"));
        }
        xmlData.AppendLine(@"</root>");
        FileStream MyFileStream;
        MyFileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\DefaultActivity.xml", FileMode.Open, FileAccess.Write, FileShare.Write);
        MyFileStream.SetLength(0);
        StreamWriter sw = new StreamWriter(MyFileStream, Response.ContentEncoding);
        sw.Write(xmlData);
        sw.Close();
    }
}
