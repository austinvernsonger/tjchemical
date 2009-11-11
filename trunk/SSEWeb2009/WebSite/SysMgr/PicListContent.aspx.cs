using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


/// <summary>
/// 页面：SysMgr_PicListContent - 图片列表页面
/// 作者：Constantine
/// 最近一次修改时间：2009-6-24
/// </summary>
public partial class SysMgr_PicListContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }

        if (!IsPostBack)
        {
            try
            {
                //从request中读取服务端路径
                String dir = Request["dir"] as String;
                if (dir != null)
                {
                    this.lbHidden.Text = dir;
                    //得到对应路径的目录信息
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~" + dir));

                    List<FileInfo> fiList = new List<FileInfo>();
                    //获取的文件格式仅限于BMP,JPG,JPEG,PNG和GIF
                    fiList.AddRange(di.GetFiles("*.bmp"));
                    fiList.AddRange(di.GetFiles("*.jpg"));
                    fiList.AddRange(di.GetFiles("*.jpeg"));
                    fiList.AddRange(di.GetFiles("*.png"));
                    fiList.AddRange(di.GetFiles("*.gif"));
                    //绑定数据,OK
                    dg.DataSource = fiList.ToArray();
                    dg.DataBind();
                }
            }
            catch (System.Exception ex)
            {
                //服务端路径不对就抓到异常至此
                this.lbHidden.Visible = true;
                this.lbHidden.Text = ex.Message;
            }
        }
    }
    /// <summary>
    /// 绑定数据时用，增加效果~
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Attributes.Add("onMouseOver", "this.style.color='black'");
            e.Item.Attributes.Add("onMouseOut", "this.style.color='#666666'");
        }
    }
    /// <summary>
    /// 选择对应图片，得到图片url
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void dg_SelectedIndexChanged(object sender, EventArgs e)
    {
        String preUrl = this.lbHidden.Text;
        imgPreview.ImageUrl = "~" + preUrl + "\\" + dg.Items[dg.SelectedIndex].Cells[0].Text;
        this.lbSelPic.Visible = true;
        this.lbInfo.Visible = false;
    }
    /// <summary>
    /// 确定选择图片，将图片路径存入Session，值为原图路径 + 分隔符“|” + 缩略图路径
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void lbSelPic_Click(object sender, EventArgs e)
    {
        String imgName = dg.Items[dg.SelectedIndex].Cells[0].Text;
        String resultStr = null;
        if (imgName.StartsWith("t_"))
        {
            resultStr = "~" + this.lbHidden.Text + "\\" + imgName +
                "|~" + this.lbHidden.Text + "\\" + imgName.Remove(0,2);
        }
        else
        {
            resultStr = "~" + this.lbHidden.Text + "\\t_" + imgName +
                "|~" + this.lbHidden.Text + "\\" + imgName;
        }
        this.lbInfo.Visible = true;
        this.lbInfo.Text = "你已选择了了图片:" + imgName;
        //存入Session，OK~
        Session.Add("SelectedPicUrl", resultStr);
    }
}
