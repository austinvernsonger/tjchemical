using System;
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
using SysCom;

public partial class _Default : System.Web.UI.Page 
{
    private int noticeLeft = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        /*WriteXML();*/
        if (!IsPostBack)
        {
            InitSclPic();
        }

        GetTagsData();
        GetQuickLinkData();
        InitNoticeList();
    }

    private void InitNoticeList()
    {
//         DateTime date = DateTime.Now;
//         String dateNow = date.ToShortDateString().Replace("/","-");
//         String dateYes = date.AddDays(-1).ToShortDateString().Replace("/", "-");
//         String dateEarlier = date.AddDays(-2).ToShortDateString().Replace("/", "-");
// 
//         this.mmtNoticeList.DateTime = dateNow;
//         this.mmtNoticeListY.DateTime = dateYes;
//         this.mmtNoticeListE.DateTime = dateEarlier;
    }

    private void HandleTodayNoticeList(int rows)
    {
//         if (rows >= 10)
//         {
//             this.mmtNoticeList.PageSize = 10;
//             //this.mmtNoticeList.AllowPaging = true;
//             notice_yest.Visible = false;
//             notice_old.Visible = false;
//             noticeLeft = 0;
//         }
//         else
//         {
//             this.mmtNoticeList.PageSize = rows;
//             noticeLeft = 10 - rows;
//             mmtNoticeListY.PageSize = noticeLeft;
//         }
    }

    private void HandleYesterdayNoticeList(int rows)
    {
//         if (rows >= noticeLeft)
//         {
//             // this.mmtNoticeListY.PageSize = noticeLeft;
//             notice_old.Visible = false;
//             // noticeLeft = 0;
//         }
//         else
//         {
//             noticeLeft -= rows;
//             mmtNoticeListE.PageSize = noticeLeft;
//         }
    }

    private void GetQuickLinkData()
    {
        QuickLinkXmlParse qlXml = new QuickLinkXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\QuickLink.xml");
        qlXml.Deserialize();
        String LinkStr = "<ul id='lihover'>";
        for (int i = 0; i < 8;++i )
        {
            LinkItem lkItem = qlXml.ItemList[i] as LinkItem;
            LinkStr += "<li><a href=\"" + lkItem.LinkAddr + "\">" + lkItem.LinkName + "</a></li>";

           // tableQuickLink.Rows.Add(tr);
        }
        LinkStr+="</ul>";
        LinkDiv.InnerHtml=LinkStr;
    }


    private void GetTagsData()
    {
//         TagXmlParse tagXml = new TagXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\Tag.xml");
//         tagXml.Deserialize();
// 
//         tagXml.ItemList.Sort(new TagItemComparer());
// 
//         LinkButton lnkBtnAll = new LinkButton();
//         lnkBtnAll.ID = "lbTagsAll";
//         lnkBtnAll.Text = "全部";
//         lnkBtnAll.CssClass = "tagLinkBtn";
//         lnkBtnAll.Click += new EventHandler(lnkBtn_Click);
// 
//         this.panelTags.Controls.Add(lnkBtnAll);
// 
//         for (int i = 0; i < tagXml.ItemList.Count;++i )
//         {
//             TagItem tagItem = tagXml.ItemList[i] as TagItem;
//             LinkButton lnkBtn = new LinkButton();
//             lnkBtn.ID = "lbTags" + tagItem.TagNum.ToString();
//             lnkBtn.Text = tagItem.TagName;
//             lnkBtn.CssClass = "tagLinkBtn";
// 
//             lnkBtn.Click += new EventHandler(lnkBtn_Click);
// 
//             this.panelTags.Controls.Add(lnkBtn);
//         }
    }


    private void InitSclPic()
    {
        SclPicXmlParse spXml = new SclPicXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\SchoolPictures.xml");
        spXml.Deserialize();

        String contentStr = "<ul>";

        for (int i = 0; i < spXml.itemList.Count; ++i)
        {
            SclPicItem spItem = spXml.itemList[i] as SclPicItem;
            contentStr += "<li><a href=\"" + spItem.PicUrl.Remove(0, 2).Replace("\\", "/")
                + "\" rel=\"clearbox\" title=\"同济大学软件学院\"><img src=\""
                + spItem.PicThumUrl.Remove(0, 2).Replace("\\", "/") + "\" width=\"145\" height=\"94\" border=\"0\" class=\"pic\" /></a></li>";
        }
        contentStr += "</ul>";
        sclDiv.InnerHtml = contentStr;
    }

    private void lnkBtn_Click(object sender, EventArgs e)
    {
//         LinkButton btn = sender as LinkButton;
//         //设置对应标签
//         String strLabel = btn.Text.Equals("全部") ? "" : btn.Text;
//         mmtNoticeList.Label = strLabel;
//         mmtNoticeListY.Label = strLabel;
//         mmtNoticeListE.Label = strLabel;
    }

    protected void SwitchRoundCorner_Day(Boolean Statue)
    {
/*
        rndcnrex_notice_day.Enabled = Statue;
        rndcnrex_nwesb_day.Enabled = Statue;
        rndcnrex_qaceess_day.Enabled = Statue;*/


    }

    protected void SwitchRoundCorner_Night(Boolean Statue)
    {
/*
        rndcnrex_notice_night.Enabled = Statue;
        rndcnrex_newsb_night.Enabled = Statue;
        rndcnrex_qaceess_night.Enabled = Statue;*/


    }
/*修改活动的XML,推未开放mmtlist的接口,权宜之计*/
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
            xmlData.Append((@"<Title>" + Title.Trim() + "</Title>"));
            xmlData.Append((@"<StartTime>" + StartTime.Trim() + "</StartTime>"));
            xmlData.Append((@"<EndTime>" + EndTime.Trim() + "</EndTime>"));
            xmlData.Append((@"<Location>" + Location.Trim() + "</Location>"));
            xmlData.Append((@"<ID>" + ID.Trim() + "</ID>"));
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
