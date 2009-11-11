using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teaching_Admin_ApplicationContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.mainFrame.set = "";
    }
    public String SetFrame()
    {
        if (Request.QueryString["Type"] == null) return "";
        if (Request.QueryString["ID"] == null) return "";

        String ContentTarget = "";
        switch(Request.QueryString["Type"])
        {
            case "1":
                ContentTarget = "../BackEnd/TravelApplicationLabel.aspx?ID=" + Request.QueryString["ID"];
                break;
            case "2":
                ContentTarget = "../BackEnd/LectureApplicationLabel.aspx?ID=" + Request.QueryString["ID"];
                break;
            case "3":
                ContentTarget = "../BackEnd/NewCourseApplicationLabel.aspx?ID=" + Request.QueryString["ID"];
                break;
        }
        
        String strFrame="";
        strFrame += "<frameset rows=\"80%,*\"  frameborder=1 border=1>";
        strFrame += "<frame src=\"" + ContentTarget + "\" scrolling=\"auto\" />";
        strFrame += "<frame src=\"Approve.aspx?Type=" + Request.QueryString["Type"]+"&ID="+ Request.QueryString["ID"] + "\" scrolling=\"auto\" />";
        strFrame += "</frameset>";
        return strFrame;
        //update NewCourseApplication set ExamApproval = 0 where RequestID=2
    }
}
