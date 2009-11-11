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
using SysCom;
public partial class Login_test1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SclPicXmlParse spXml = new SclPicXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\SchoolPictures.xml");
        spXml.Deserialize();

        String contentStr = "<ul>";

        for (int i = 0; i < spXml.itemList.Count; ++i)
        {
            SclPicItem spItem = spXml.itemList[i] as SclPicItem;
            contentStr += "<li><a href=\"../" + spItem.PicUrl.Remove(0, 2).Replace("\\", "/")
                + "\" rel=\"clearbox\" title=\"同济大学软件学院\"><img src=\""
                + ConstValue.PureURL + spItem.PicThumUrl.Remove(0, 2).Replace("\\", "/") + "\" width=\"85\" height=\"71\" border=\"0\" class=\"pic\" /></a></li>";
        }
        contentStr += "</ul>";
        sclDiv.InnerHtml = contentStr;
    }
}
