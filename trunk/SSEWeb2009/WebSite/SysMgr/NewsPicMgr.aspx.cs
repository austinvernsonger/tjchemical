using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SysCom;

/// <summary>
/// 页面：SysMgr_NewsPicMgr - 新闻图片管理页面
/// 作者：Constantine
/// 最近一次修改时间：2009-6-8
/// </summary>
public partial class SysMgr_NewsPicMgr : System.Web.UI.Page
{
    private NewsPicXmlParse npXml;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            npXml = new NewsPicXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\NewsPictures.xml");
            npXml.Deserialize();
            SaveSession();
        }
        else
        {
            LoadSession();
        }
        LoadControls();
    }

    private void SaveSession()
    {
        Session["NewsPicXmlParse"] = npXml;
    }

    private void LoadSession()
    {
        npXml = Session["NewsPicXmlParse"] as NewsPicXmlParse;
    }

    private void LoadControls()
    {
        this.placeHolder.Controls.Clear();
        try
        {
            for (int i = 0; i < npXml.itemList.Count;++i )
            {
                UserControl_NewsPicInfoControl npInfo = (UserControl_NewsPicInfoControl)LoadControl("~/UserControl/NewsPicInfoControl.ascx");
                NewsPicItem npItem = npXml.itemList[i] as NewsPicItem;
                // Do something here
                // Set properties.... 
                // npItem.NewsDescription;
                // npItem.NewsID;
                // npItem.PicLink
                this.placeHolder.Controls.Add(npInfo);
            }
        }
        catch (System.Exception e)
        {
            e.ToString();
            throw e;
        }
    }
}
