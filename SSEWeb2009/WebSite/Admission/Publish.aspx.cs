using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class RecruitmentNew_Publish : System.Web.UI.Page
{

    private static string preKind;
    private static string preGroup;
    private static string myMMTID;

    protected void Page_Load(object sender, EventArgs e)
    {
      /*  string xmlFile = Server.MapPath("~/Admission/Admin/AdmissionAdminList.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFile);
        XmlNode nodeTeacher = doc.ChildNodes[1].ChildNodes[0].FirstChild;
        string userName = nodeTeacher.Value;

        if (Session["IdentifyNumber"] == null || (string)Session["IdentifyNumber"] != userName)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (!Page.IsPostBack)
        {
            preKind = "Booklet";
            preGroup = "HghStu_";
            myMMTID = "HghStu_Booklet";
            EditMmtContent.BeforePost = new SysCom.MMTDelegate.PostEvent(this.rcrBeforePost);
            EditMmtContent.MMTID = myMMTID;
        }
    */
    }

    public void rcrBeforePost(String MMTID)
    {

        //Response.Write(EditMmtContent.MMTID);
    }
    protected void DDGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        myMMTID = myMMTID.Replace(preGroup, DDGroup.SelectedItem.Value);
        preGroup = DDGroup.SelectedItem.Value;
        EditMmtContent.MMTID = myMMTID;
    }
    protected void DDKind_SelectedIndexChanged(object sender, EventArgs e)
    {
        myMMTID = myMMTID.Replace(preKind, DDKind.SelectedItem.Value);
        preKind = DDKind.SelectedItem.Value;
        EditMmtContent.MMTID = myMMTID;
    }
}
