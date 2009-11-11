using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SysCom;


/// <summary>
/// 页面：SysMgr_QuickLinkMgr - 快速连接管理
/// 作者：Constantine
/// 最近一次修改时间：2009-5-??
/// </summary>
public partial class SysMgr_QuickLinkMgr : System.Web.UI.Page
{

    private Boolean isTextEmpty = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadControls();
        QuickLinkXmlParse qlXml = new QuickLinkXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\QuickLink.xml");
        qlXml.Deserialize();

        ShowItemData(qlXml);
    }

    /// <summary>
    /// 将数据类的数据导入页面
    /// </summary>
    /// <param name="qlXml">数据类</param>
    private void ShowItemData(QuickLinkXmlParse qlXml)
    {
        UserControl_LinkInfoControl tmp = null;
        LinkItem tmpItem = null;
        for (int i = 0; i < 10; ++i)
        {
            tmp = (UserControl_LinkInfoControl)placeHolder.Controls[i];
            tmpItem = (LinkItem)qlXml.ItemList[i];
            tmp.SetLinkName(tmpItem.LinkName);
            tmp.SetLinkAddr(tmpItem.LinkAddr);
        }
    }

    /// <summary>
    /// 将页面中的数据项导入类并序列化
    /// </summary>
    private void SaveItemData()
    {
        QuickLinkXmlParse qlXml = new QuickLinkXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\QuickLink.xml");
        UserControl_LinkInfoControl tmp = null;
        for (int i = 0; i < 10; ++i)
        {
            LinkItem tmpItem = new LinkItem();
            tmp = (UserControl_LinkInfoControl)placeHolder.Controls[i];
            tmpItem.LinkName = tmp.GetLinkName();
            tmpItem.LinkAddr = tmp.GetLinkAddr();
            qlXml.ItemList.Add(tmpItem);
        }

        qlXml.Serialize();
    }

    /// <summary>
    /// 生成10个用户控件并加入PlaceHolder
    /// </summary>
    private void LoadControls()
    {
        for (int i = 0; i < 10; ++i)
        {
            UserControl_LinkInfoControl temp = null;
            try
            {
                temp = (UserControl_LinkInfoControl)LoadControl("~/UserControl/LinkInfoControl.ascx");
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                Response.Write("<br />");
            }
            if (temp == null) Response.Write("Null Control<br />");
            else
            {
                try
                {
                    placeHolder.Controls.Add(temp);
                }
                catch
                {
                    Response.Write(i.ToString() + " Error!<br />");
                }
            }
        }
    }

    protected void BtnOK_Click(object sender, EventArgs e)
    {
        isTextEmpty = false;
        UserControl_LinkInfoControl tmp = null;
        //检查是否有留空的输入框，有的话提示错误
        for (int i = 0; i < 10; ++i)
        {
            tmp = (UserControl_LinkInfoControl)placeHolder.Controls[i];
            if (tmp.CheckEmpty())
            {
                tmp.ShowNotify(true);
                isTextEmpty = true;
            }
            else
            {
                //显示提示的就隐藏
                if (tmp.IsNotifyShowed())
                {
                    tmp.ShowNotify(false);
                }
            }
        }
        //有空的就返回
        if (isTextEmpty)
        {
            this.lbNotify.Visible = false;
            return;
        }
        //序列化为XML文件
        SaveItemData();
        //把所有提示信息都隐藏
        for (int i = 0; i < 10; ++i)
        {
            tmp = (UserControl_LinkInfoControl)placeHolder.Controls[i];
            if (tmp.IsNotifyShowed())
            {
                tmp.ShowNotify(false);
            }
        }
        //显示成功信息
        this.lbNotify.Visible = true;
    }
}
