using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
public partial class ContentMgr : System.Web.UI.Page
{


    private static string preKind;
    private static string preGroup;
    private static string myMMTID;

    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlFile = Server.MapPath("rcrAuthorityList.xml");
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
            RcrEdit.BeforePost = new SysCom.MMTDelegate.PostEvent(this.rcrBeforePost);
            RcrEdit.MMTID = myMMTID;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        myMMTID = myMMTID.Replace(preGroup, DDGroup.SelectedItem.Value);
        preGroup = DDGroup.SelectedItem.Value;
        RcrEdit.MMTID = myMMTID;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        myMMTID = myMMTID.Replace(preKind, DDKind.SelectedItem.Value);
        preKind = DDKind.SelectedItem.Value;
        RcrEdit.MMTID = myMMTID;
    }

    public void rcrBeforePost(String MMTID)
    {

        //Response.Write(RcrEdit.MMTID);
    }

}
