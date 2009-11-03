using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

/// <summary>
/// 用户控件：UserControl_LinkInfoControl
/// 作者：Constantine
/// 最近一次修改时间：2009-6-3
/// </summary>
public partial class UserControl_LinkInfoControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //增加属性，为了美观 ;)
        this.tbLnkName.Attributes.Add("onFocus", "this.style.backgroundColor='#D0F0FF';");
        this.tbLnkName.Attributes.Add("onBlur", "this.style.backgroundColor='#FFFFFF';");

        this.tbLnkAddr.Attributes.Add("onFocus", "this.style.backgroundColor='#D0F0FF';");
        this.tbLnkAddr.Attributes.Add("onBlur", "this.style.backgroundColor='#FFFFFF';");
    }

    /// <summary>
    /// 得到链接地址
    /// </summary>
    /// <returns></returns>
    public String GetLinkAddr()
    {
        return this.tbLnkAddr.Text.Trim();
    }

    /// <summary>
    /// 得到链接名字
    /// </summary>
    /// <returns></returns>
    public String GetLinkName()
    {
        return this.tbLnkName.Text.Trim();
    }

    /// <summary>
    /// 设置链接地址
    /// </summary>
    /// <param name="text"></param>
    public void SetLinkAddr(String text)
    {
        this.tbLnkAddr.Text = text;
    }

    /// <summary>
    /// 设置链接名称
    /// </summary>
    /// <param name="text"></param>
    public void SetLinkName(String text)
    {
        this.tbLnkName.Text = text;
    }

    /// <summary>
    /// 检查是否有空
    /// </summary>
    /// <returns>true - 是，false - 无</returns>
    public Boolean CheckEmpty()
    {
        if (GetLinkName().Equals(String.Empty) || GetLinkAddr().Equals(String.Empty))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 显示/隐藏报错信息
    /// </summary>
    /// <param name="IsShow">是否显示</param>
    public void ShowNotify(Boolean IsShow)
    {
        if (IsShow == true)
        {
            this.lbNotify.Visible = true;
        }
        else
        {
            this.lbNotify.Visible = false;
        }
    }

    /// <summary>
    /// 检查报错信息是否显示
    /// </summary>
    /// <returns>true - 显示，false - 未显示</returns>
    public Boolean IsNotifyShowed()
    {
        return this.lbNotify.Visible;
    }
}

