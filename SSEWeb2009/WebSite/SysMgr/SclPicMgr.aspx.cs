using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SysCom;


/// <summary>
/// 页面：SysMgr_SclPicMgr - 图片管理页面
/// 作者：Constantine
/// 最近一次修改时间：2009-6-5
/// </summary>
public partial class SysMgr_SclPicMgr : System.Web.UI.Page
{
    //XML序列化控制类
    private SclPicXmlParse spXml;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  //第一次加载Page，从文件中反序列化，并存入Session
        {
            //将Session中的Url清空
            Session["SelectedPicUrl"] = null;
            spXml = new SclPicXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\SchoolPictures.xml");
            spXml.Deserialize();
            SaveSession();
        }
        else   //不是第一次，都从Session中读值
        {
            this.lbOpInfo.Visible = false;
            LoadSession();
        }

        LoadControls();
    }

    /// <summary>
    /// 从Session中加载XML的序列化控制类
    /// </summary>
    private void LoadSession()
    {
        spXml = Session["SclPicXmlParse"] as SclPicXmlParse;
    }

    /// <summary>
    /// 将XML序列化控制类存入Session中
    /// </summary>
    private void SaveSession()
    {
        Session["SclPicXmlParse"] = spXml;
    }

    /// <summary>
    /// 根据XML序列化控制类来加载用户控件
    /// </summary>
    private void LoadControls()
    {
        this.placeHolder.Controls.Clear();
        try
        {
            for (int i = 0; i < spXml.itemList.Count; ++i)
            {
                UserControl_SclPicInfoControl spInfo = (UserControl_SclPicInfoControl)LoadControl("~/UserControl/SclPicInfoControl.ascx");
                SclPicItem spItem = spXml.itemList[i] as SclPicItem;
                spInfo.ID = "PicInfo_" + i.ToString();
                spInfo.SetPicLinkList(spItem.PicUrl, spItem.PicThumUrl);
                this.placeHolder.Controls.Add(spInfo);
            }
        }
        catch (System.Exception e)
        {
            e.ToString();
            throw e;
        }

    }

    /// <summary>
    /// 保存数据，并序列化为XML文件
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void lbSave_Click(object sender, EventArgs e)
    {
        SclPicXmlParse sp = new SclPicXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\SchoolPictures.xml");

        for (int i = 0; i < this.placeHolder.Controls.Count; ++i)
        {
            UserControl_SclPicInfoControl spInfo = this.placeHolder.Controls[i] as UserControl_SclPicInfoControl;
            //若标记为删除就不用管它了
            if (spInfo.IsMarkDeleted())
            {
                continue;
            }

            SclPicItem spItem = new SclPicItem();
            List<String> strList = spInfo.GetPicLinkList();

            spItem.PicThumUrl = strList[0];
            spItem.PicUrl = strList[1];

            sp.itemList.Add(spItem);
        }

        spXml = sp;

        SaveSession();

        spXml.Serialize();

        this.lbOpInfo.Text = "数据已保存！";
        this.lbOpInfo.Visible = true;

        LoadControls();
    }

    /// <summary>
    /// 增加一个图片
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        // 保存原值
        for (int i = 0; i < this.placeHolder.Controls.Count;++i )
        {
            UserControl_SclPicInfoControl spInfo = this.placeHolder.Controls[i] as UserControl_SclPicInfoControl;
            SclPicItem spItemOld = spXml.itemList[i] as SclPicItem;
            List<String> urlLst = spInfo.GetPicLinkList();
            spItemOld.PicThumUrl = urlLst[0];
            spItemOld.PicUrl = urlLst[1];
        }
        // 保存至Session
        SaveSession();

        SclPicItem spItem = new SclPicItem();
        spItem.PicUrl = "~/Resources/Images/default.png";
        spItem.PicThumUrl = "~/Resources/Images/default.png";

        spXml.itemList.Add(spItem);

        SaveSession();

        LoadControls();
        //还是那个，自动PostBack
        this.timerPostBack.Enabled = true;
    }
}
