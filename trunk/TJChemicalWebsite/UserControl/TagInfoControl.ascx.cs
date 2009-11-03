using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// 用户控件：UserControl_TagInfoControl
/// 作者：Constantine
/// 最近一次修改时间：2009-6-3
/// </summary>
public partial class UserControl_TagInfoControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //增加属性，为了美观 ;)
        this.tbTagNum.Attributes.Add("onFocus", "this.style.backgroundColor='#D0F0FF';");
        this.tbTagNum.Attributes.Add("onBlur", "this.style.backgroundColor='#FFFFFF';");

        this.tbTagName.Attributes.Add("onFocus", "this.style.backgroundColor='#D0F0FF';");
        this.tbTagName.Attributes.Add("onBlur", "this.style.backgroundColor='#FFFFFF';");
    }

    /// <summary>
    /// 得到Tag名字
    /// </summary>
    /// <returns>String - Tag名字</returns>
    public String GetTagName()
    {
        return this.tbTagName.Text.Trim();
    }

    /// <summary>
    /// 得到Tag序号
    /// </summary>
    /// <returns>int - Tag序号</returns>
    public int GetTagNum()
    {
        int tmp;

        try
        {
            tmp = Int32.Parse(this.tbTagNum.Text.Trim()); //返回的是整数
        }
        catch (System.Exception e)
        {
            e.ToString();
            tmp = 0xFFFD; //不是整数则设为错误码0xFFFD
        }
        return tmp;
    }

    public void SetTagName(String tagName)
    {
        this.tbTagName.Text = tagName;
    }

    public void SetTagNum(int tagNum)
    {
        this.tbTagNum.Text = tagNum.ToString();
    }

    /// <summary>
    /// 控件是否被选中
    /// </summary>
    /// <returns>true - 选中，false - 未选中</returns>
    public Boolean IsChecked()
    {
        return this.cbCheckItem.Checked;
    }

    /// <summary>
    /// 检查控件是否有输入框为空
    /// </summary>
    /// <returns>true - 为空，false - 不为空</returns>
    public Boolean IsEmpty()
    {
        if (this.tbTagName.Text.Equals(String.Empty) || this.tbTagNum.Text.Equals(String.Empty))
        {
            return true;
        }

        return false;
    }
}
