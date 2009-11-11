using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using SysCom;
using System.Drawing;

/// <summary>
/// 存于ArrayList的类，用于标示单个Button  
/// </summary>
public class TagButtonInfo
{
    public Boolean IsBtnChecked;
    public String ButtonString;
}

/// <summary>
/// 用户控件：UserControl_TagListControl
/// 作者：Constantine
/// 最近一次修改时间：2009-6-3
/// </summary>
public partial class UserControl_TagListControl : System.Web.UI.UserControl
{
    private ArrayList btnStateList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitButtons();
            SaveToSession();
        }
        else
        {
            LoadFromSession();
            LoadButtons();
        }
    }
    /// <summary>
    /// 初始化控件，从XML中读取数据并动态创建按钮
    /// </summary>
    private void InitButtons()
    {
        TagXmlParse tagXml = new TagXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\Tag.xml");
        tagXml.Deserialize();
        
        for (int i = 0; i < tagXml.ItemList.Count; ++i)
        {
            Button btn = new Button();
            TagButtonInfo tagBtnInfo = new TagButtonInfo();
            TagItem tagItem = tagXml.ItemList[i] as TagItem;

            btn.Text = tagItem.TagName;
            btn.CssClass = "tagBtnNormal";
            btn.Click += new EventHandler(TagBtnClicked);

            tagBtnInfo.IsBtnChecked = false;
            tagBtnInfo.ButtonString = btn.Text;

            this.btnStateList.Add(tagBtnInfo);
            this.TagPanel.Controls.Add(btn);
        }
    }

    /// <summary>
    /// 从Session中读取数据并以此创建控件
    /// </summary>
    private void LoadButtons()
    {
        this.TagPanel.Controls.Clear();
        for (int i = 0; i < btnStateList.Count; ++i)
        {
            TagButtonInfo tagBtnInfo = btnStateList[i] as TagButtonInfo;
            Button btn = new Button();

            btn.Text = tagBtnInfo.ButtonString;
            btn.Click += new EventHandler(TagBtnClicked);
            if (tagBtnInfo.IsBtnChecked)
            {
                btn.CssClass = "tagBtnClicked";
            }
            else
            {
                btn.CssClass = "tagBtnNormal";
            }

            this.TagPanel.Controls.Add(btn);
        }
    }

    /// <summary>
    /// 保存控件数据至Session
    /// </summary>
    private void SaveToSession()
    {
        Session.Add("TagBtnList", btnStateList);
    }

    /// <summary>
    /// 从Session中读取控件数据
    /// </summary>
    private void LoadFromSession()
    {
        btnStateList = Session["TagBtnList"] as ArrayList;
    }

    /// <summary>
    /// 处理按钮单击事件的函数，单击后的Button轮流改变状态为
    /// 已选择或未选择，并将数据存入Session。
    /// </summary>
    /// <param name="sender">sender，即标签按钮</param>
    /// <param name="e">e</param>
    private void TagBtnClicked(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        for (int i = 0; i < btnStateList.Count;++i )
        {
            TagButtonInfo tagBtnInfo = btnStateList[i] as TagButtonInfo;
            if (tagBtnInfo.ButtonString.Equals(btn.Text))
            {
                tagBtnInfo.IsBtnChecked = !tagBtnInfo.IsBtnChecked; //改变状态
                btnStateList[i] = tagBtnInfo; //存回值
                if (tagBtnInfo.IsBtnChecked)
                {
                    btn.CssClass = "tagBtnClicked";
                }
                else
                {
                    btn.CssClass = "tagBtnNormal";
                }
                break;
            }
        }

        //保存Session，大功告成
        SaveToSession();

        SetNotifyStr();
    }

    /// <summary>
    /// 设置已选标签的信息
    /// </summary>
    private void SetNotifyStr()
    {
        this.lbInfo.Text = "  已选择标签:";
        for (int i = 0; i < btnStateList.Count; ++i)
        {
            TagButtonInfo tagBtnInfo = btnStateList[i] as TagButtonInfo;
            if (tagBtnInfo.IsBtnChecked)
            {
                this.lbInfo.Text += tagBtnInfo.ButtonString;
                this.lbInfo.Text += " ";
            }
        }

        if (this.lbInfo.Text.EndsWith("已选择标签:"))
        {
            this.lbInfo.Text = "  没有选择标签，默认为“全部”.";
        }
    }

    /// <summary>
    /// 公共对外接口，返回一个包含Tag的ArrayList
    /// </summary>
    /// <returns>若为部门新闻，返回null；若为全局新闻，没有选择标签则返回仅
    /// 包含“全部”标签的List-String，有选择标签则返回对应标签的List-String</returns>
    public List<String> GetSelectedTagList()
    {
        if (this.blockRadioButtonList.SelectedValue == "1") //全局新闻
        {
            List<String> tagList = new List<String>();
            for (int i = 0; i < btnStateList.Count; ++i)
            {
                TagButtonInfo tagBtnInfo = btnStateList[i] as TagButtonInfo;
                if (tagBtnInfo.IsBtnChecked)
                {
                    tagList.Add(tagBtnInfo.ButtonString);
                }
            }

            if (tagList.Count == 0) //没有选择表情则返回“全部”
            {
                tagList.Add("全部");
            }

            return tagList;
        }
        else //部门新闻
        {
            return null;
        }
    }

    /// <summary>
    /// 对于新闻的类型进行界面上的设置
    /// </summary>
    /// <param name="IsNewsInternal">是否为部门新闻，true - 是，false - 不是</param>
    private void SetNewsType(Boolean IsNewsInternal)
    {
        if (IsNewsInternal == true)
        {
            this.blockRadioButtonList.SelectedValue = "2";
            this.TagPanel.Visible = false;
            this.lbInfo.Text = "部门新闻不能选择标签";
            this.lbInfo.ForeColor = Color.Gray;
        }
        else
        {
            this.blockRadioButtonList.SelectedValue = "1";
            this.TagPanel.Visible = true;
            this.lbInfo.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
        }

        this.blockRadioButtonList.Enabled = false;
       
    }

    /// <summary>
    /// 设置已选的Tag按钮
    /// </summary>
    /// <param name="tagList">List-String包含一组Tag名字</param>
    public void SetSelectedTag(List<String> tagList)
    {
        if (tagList == null) //部门新闻
        {
            SetNewsType(true);
            return;
        }
        //全局新闻
        SetNewsType(false);
        //这个算法确实太差了……
        for (int i = 0; i < tagList.Count; ++i)
        {
            for (int j = 0; j < btnStateList.Count; ++j)
            {
                TagButtonInfo tagBtnInfo = btnStateList[j] as TagButtonInfo;
                if (tagBtnInfo.ButtonString.Equals(tagList[i]))
                {
                    tagBtnInfo.IsBtnChecked = true;
                    btnStateList[j] = tagBtnInfo;
                    for (int m = 0; m < TagPanel.Controls.Count;++m )
                    {
                        Button btn = TagPanel.Controls[m] as Button;
                        if (btn.Text.Equals(tagBtnInfo.ButtonString))
                        {
                            btn.CssClass = "tagBtnClicked";
                            break;
                        }
                    }
                    break;
                }
            }
        }
        //保存Session
        SaveToSession();
        //设置提示字符串
        SetNotifyStr();
    }
}

