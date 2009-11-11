using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// 用户控件：UserControl_SclPicInfoControl
/// 作者：Constantine
/// 最近一次修改时间：2009-6-3
/// </summary>
public partial class UserControl_SclPicInfoControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    /// <summary>
    /// 从Session中获取图片地址，包括原图和缩略图，并显示缩略图以供预览
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void lbOK_Click(object sender, EventArgs e)
    {
        if (this.lbHiddenInfo1.Text.Equals("-"))
        {
            this.mainDiv.Style.Remove("filter");
            this.mainDiv.Style.Remove("opacity");
            this.lbHiddenInfo1.Text = "+";
            this.lbOK.Text = "获取图片";
        }

        String result = Session["SelectedPicUrl"] as String;
        if (result != null)
        {
            this.lbLink.Text = result;
        }
        List<String> lst = GetPicLinkList();
        this.imgPrew.ImageUrl = lst[0];
        String urls = lst[1].Replace("~", "..");
        //InnerHTML是好东西啊，哈哈。这里动态添加预览地址。
        divFullView.InnerHtml = "<a  style=\"font-size: x-small; font-family: Verdana;color: #333333\" href=\""
          + urls.Replace("\\", "/") + "\" rel=\"clearbox\" target=\"_blank\" title=\"预览\">Full View</a>";
    }

    /// <summary>
    /// 设置图片的原图地址和缩略图地址
    /// </summary>
    /// <param name="picUrl">原图地址，相对路径url</param>
    /// <param name="picThumUrl">缩略图地址，相对路径url</param>
    public void SetPicLinkList(String picUrl,String picThumUrl)
    {
        this.imgPrew.ImageUrl = picThumUrl;
        //隐藏的信息标签，值为：缩略图地址 + 分隔符“|” + 原图地址
        this.lbLink.Text = picThumUrl + "|" +picUrl;
        String urls = picUrl.Replace("~", "..");
        divFullView.InnerHtml = "<a  style=\"font-size: x-small; font-family: Verdana;color: #333333\" href=\""
            + urls.Replace("\\", "/") + "\" rel=\"clearbox\" target=\"_blank\" title=\"预览\">Full View</a>";
    }

    /// <summary>
    /// 得到图片链接List
    /// </summary>
    /// <returns>包含图片链接的List，有两个值，第一个为缩略图地址，第二个为原图地址</returns>
    public List<String> GetPicLinkList()
    {
        String lnkStr = this.lbLink.Text;

        List<String> picLinkList = new List<String>();
        char[] sep = {'|'};
        String[] strArr = lnkStr.Split(sep);

        for (int i = 0; i < strArr.Length;++i )
        {
            picLinkList.Add(strArr[i]);
        }

        return picLinkList;
    }

    /// <summary>
    /// 检查是否被标记为删除
    /// </summary>
    /// <returns>true - 是，false - 否</returns>
    public Boolean IsMarkDeleted()
    {
        if (this.lbHiddenInfo1.Text.Equals("-"))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 删除控件，其实是标记为删除
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void ibRemove_Click(object sender, ImageClickEventArgs e)
    {
        this.lbHiddenInfo1.Text = "-";
        this.mainDiv.Style.Add("filter", "alpha(opacity=40)");
        this.mainDiv.Style.Add("opacity", "0.4");
        this.lbOK.Text = "撤销删除";
    }
}
