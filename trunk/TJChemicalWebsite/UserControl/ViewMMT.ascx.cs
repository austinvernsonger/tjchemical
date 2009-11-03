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

public partial class UserControl_ViewMMT : System.Web.UI.UserControl
{
    protected String myId = null;
    protected SysCom.MMT myMMT = null;

    /// <summary>
    /// The MMTID
    /// </summary>
    public String MMTID { set { myId = value; } }

    /// <summary>
    /// Title Division's Css Class
    /// </summary>
    public String TitleCssClass { set { div_title.Attributes["class"] = value; } }

    /// <summary>
    /// Time Division's Css Class
    /// </summary>
    public String TimeCssClass { set { div_time.Attributes["class"] = value; } }

    private Boolean myTitleChange = true;
    public Boolean TitleChange { set { myTitleChange = value; } }
    /// <summary>
    /// Location Division's Css Class
    /// </summary>
    public String LocationCssClass { set { div_location.Attributes["class"] = value; } }

    private Boolean myShowClickCount = true;
    /// <summary>
    /// Whether show click count. Default is True.
    /// </summary>
    public Boolean ShowClickCount { set { myShowClickCount = value; } }

    private Boolean myShowTitle = true;
    /// <summary>
    /// Whether show the post time. Default is True
    /// </summary>
    public Boolean ShowTitle { set { myShowTitle = value; } }

    private Boolean myShowLabel = false;
    /// <summary>
    /// Whether show the Labels. Default is false;
    /// </summary>
    public Boolean ShowLabel { set { myShowLabel = value; } }

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (myId == null) myId = Request.Params["MMTID"];
        myMMT = new SysCom.MMT(myId);
        if (myMMT.IsValidated)
        {
            lb_title.Text = myMMT.Title;
            if(myTitleChange)this.Page.Title = myMMT.Title;
            lb_clickCount.Text = myMMT.ViewTimes.ToString();

            // Whether show title, click count, labels
            div_title.Visible = myShowTitle;
            div_clickCount.Visible = myShowClickCount;

            // Tags
            if (myMMT.Labels.Count != 0)
            {
                for (int i = 0; i < myMMT.Labels.Count; ++i)
                {
                    HyperLink lnk_tag = new HyperLink();
                    lnk_tag.Text = myMMT.Labels[i];
                    //lnk_tag.NavigateUrl = "#";
                    phd_tags.Controls.Add(lnk_tag);
                }
                div_tag.Visible = true;
            }
            div_tag.Visible = myShowLabel;

            // Time
            if (myMMT.HasExInfo)
            {
                lb_startTime.Text = myMMT.StartTime.ToString();
                lb_endTime.Text = myMMT.EndTime.ToString();
                div_time.Visible = true;
            }

            // Location
            if (myMMT.HasExInfo && (myMMT.Location != null || myMMT.Location != ""))
            {
                lb_location.Text = myMMT.Location;
                div_location.Visible = true;
            }

            div_content.Visible = true;

            // Registration
            if (myMMT.HasExInfo && myMMT.ReportFormId != null)
            {
                // Load the Registration Part
                div_registration.Visible = true;
                /////////////////////////////////////////////////////////////////////////////////////////
           //     ReportDisplayer.SetDisplayMode(Report.Descriptor.DisplayMode.DisplayFront);
            //    ReportDisplayer.SetReportDescriptorFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\Form\\" + myMMT.ReportFormId + "Descriptor.xml");
             //   ReportDisplayer.SetReportResultFilePath(HostingEnvironment.ApplicationPhysicalPath + "Report\\Data\\" + myMMT.ReportDataSet + "Result.xml");
            }

            if (myMMT.HasAttachment)
            {
                foreach ( SysCom.Attachment attach in myMMT.Attechments )
                {
                    HyperLink lnk_attach = new HyperLink( );
                    lnk_attach.Text = string.Format( "{0} ({1})",
                        attach.FileName, attach.DownLoadTimes );
                    lnk_attach.NavigateUrl = string.Format(
                        "~/Download.aspx?MMTID={0}&FileName={1}",
                        myMMT.ID, HttpUtility.UrlEncode(attach.FileName) );
                    HtmlGenericControl _div = new HtmlGenericControl( "div" );
                    div_attachment.Controls.Add( lnk_attach );
                    phd_attachment.Controls.Add( _div );
                }
                div_attachment.Visible = true;
            }
        }
        else
        {
            div_clickCount.Visible = false;
            lb_title.Text = "Empty Passage.";
        }
    }
}
