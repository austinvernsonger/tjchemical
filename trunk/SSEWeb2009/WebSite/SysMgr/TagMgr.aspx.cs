using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using SysCom;

/// <summary>
/// 页面：SysMgr_TagMgr - 标签管理
/// 作者：Constantine
/// 最近一次修改时间：2009-6-5
/// </summary>
public partial class SysMgr_TagMgr : System.Web.UI.Page
{
    //XML序列化的控制类
    TagXmlParse tagXml;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) //不是第一次，都从Session中读值
        {
            this.lbNotify.Visible = false;
            LoadSession();
        }
        else //第一次加载Page，从文件中反序列化，并存入Session
        {
            tagXml = new TagXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\Tag.xml");
            tagXml.Deserialize();
            SaveSession();
        }

        LoadControls();
    }

    /// <summary>
    /// 从Session中加载XML的序列化控制类
    /// </summary>
    private void LoadSession()
    {
        tagXml = Session["TagXmlParse"] as TagXmlParse;
    }

    /// <summary>
    /// 将XML序列化控制类存入Session中
    /// </summary>
    private void SaveSession()
    {
        Session.Add("TagXmlParse", tagXml);
    }

    /// <summary>
    /// 检查Tag的序号是否唯一
    /// </summary>
    /// <param name="tagNum">代检查的Tag序号</param>
    /// <returns>是否唯一，唯一- true，不唯一 - false</returns>
    private Boolean IsTagNumUnique(int tagNum)
    {
        int counter = 0;
        for (int i = 0; i < placeHolder.Controls.Count; ++i)
        {
            UserControl_TagInfoControl temp = placeHolder.Controls[i] as UserControl_TagInfoControl;
            if (temp.GetTagNum() == tagNum)
            {
                counter++;
            }
            if (counter >= 2)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 检查用户控件的合法性
    /// </summary>
    /// <param name="ucTag">代检查的用户控件</param>
    /// <returns>是否合法，合法 - true，不合法 - false</returns>
    private Boolean CheckValidation(UserControl_TagInfoControl ucTag)
    {
        //不能为空
        if (ucTag.IsEmpty())
        {
            this.lbNotify.Text = "输入不能为空";
            this.lbNotify.Visible = true;
            return false;
        }
        //Tag号必须是数字
        if (ucTag.GetTagNum() == 0xFFFD)
        {
            this.lbNotify.Text = "标签序号只能是数字";
            this.lbNotify.Visible = true;
            return false;
        }
        //Tag号必须是1-50之间的整数
        if (ucTag.GetTagNum() <= 0 || ucTag.GetTagNum() > 50)
        {
            this.lbNotify.Text = "标签序号只能为的正整数 [1~50]";
            this.lbNotify.Visible = true;
            return false;
        }
        //标签号不能重复
        if (!IsTagNumUnique(ucTag.GetTagNum()))
        {
            this.lbNotify.Text = "标签序号不能重复";
            this.lbNotify.Visible = true;
            return false;
        }

        return true;
    }

    /// <summary>
    /// 保存输入数据，并序列化为XML文件
    /// </summary>
    private void SaveItems()
    {
        Writejs();
        TagXmlParse tag = new TagXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\Tag.xml");

        for (int i = 0; i < placeHolder.Controls.Count; ++i)
        {
            UserControl_TagInfoControl temp = placeHolder.Controls[i] as UserControl_TagInfoControl;
            TagItem item = new TagItem();

            if (!CheckValidation(temp))
            {
                return;
            }

            item.TagName = temp.GetTagName();
            item.TagNum = temp.GetTagNum();

            tag.ItemList.Add(item);
        }

        tagXml = tag;

        this.lbNotify.Text = "保存数据成功！";
        this.lbNotify.Visible = true;

        SaveSession();

        tagXml.Serialize();
    }

    /// <summary>
    /// 根据XML序列化控制类来加载用户控件
    /// </summary>
    private void LoadControls()
    {
        placeHolder.Controls.Clear();

        for (int i = 0; i < tagXml.ItemList.Count; ++i)
        {
            UserControl_TagInfoControl temp = (UserControl_TagInfoControl)LoadControl("~/UserControl/TagInfoControl.ascx");
            TagItem item = (TagItem)tagXml.ItemList[i];
            temp.SetTagNum(item.TagNum);
            temp.SetTagName(item.TagName);
            placeHolder.Controls.Add(temp);
        }
    }

    /// <summary>
    /// 新建一个标签
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void lbNew_Click(object sender, EventArgs e)
    {
        //保存原值
        for (int i = 0; i < this.placeHolder.Controls.Count;++i )
        {
            UserControl_TagInfoControl temp = placeHolder.Controls[i] as UserControl_TagInfoControl;
            TagItem itemOld = tagXml.ItemList[i] as TagItem;
            itemOld.TagName = temp.GetTagName();
            itemOld.TagNum = temp.GetTagNum();
        }
        //保存至Session
        SaveSession();

        if (tagXml.ItemList.Count > 50)
        {
            this.lbNotify.Text = "标签数量不能大于50个";
            this.lbNotify.Visible = true;
            return;
        }

        TagItem item = new TagItem();
        item.TagName = "新建标签";
        item.TagNum = tagXml.GetMaxNum() + 1; //得到最大值，并加1

        tagXml.ItemList.Add(item);

        SaveSession();

        // 注意，这里是重点
        // 要调用两次
        // 否则，结果是错误的！！
        // 就是这样解决的，没有什么道理！！
        LoadControls();
        LoadControls();
        // 这个就更WS了……自动PostBack的绝招！Idea by Wolfhead
        // 有个Timer，它的Enabled是false，这里让它设为true
        // 于是，页面就自动PostBack了，PostBack回来后Timer还是false，搞定！
        // 这个方法是为了解决新建的控件不能使用的问题
        this.timerPostBack.Enabled = true;
    }

    /// <summary>
    /// 删除一个或多个标签
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        UserControl_TagInfoControl temp = null;
        Boolean isSomeToDel = false;
        for (int i = 0; i < placeHolder.Controls.Count; i++)
        {
            temp = (UserControl_TagInfoControl)placeHolder.Controls[i];
            //如果检查到标记了，删除之
            if (temp.IsChecked() == true)
            {
                isSomeToDel = true;
                //控制类中找到对应的项并删除
                for (int j = 0; j < tagXml.ItemList.Count; ++j)
                {
                    if (((TagItem)tagXml.ItemList[j]).TagNum == temp.GetTagNum())
                    {
                        tagXml.ItemList.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        //没有找到删除项就不删
        if (!isSomeToDel)
        {
            this.lbNotify.Text = "没有需要删除的标签！";
            this.lbNotify.Visible = true;
            return;
        }

        SaveSession();

        LoadControls();
    }

    /// <summary>
    /// 保存值，没什么好说的
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void lbSave_Click(object sender, EventArgs e)
    {
        SaveItems();
    }


    public void Writejs()
    {
         TagXmlParse tagXml = new TagXmlParse(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\Tag.xml");
         tagXml.Deserialize();
 
         tagXml.ItemList.Sort(new TagItemComparer());
 

        //SysCom.MMTStatic a = new SysCom.MMTStatic();
        StringBuilder jsData = new StringBuilder();
        jsData.AppendLine(@"function showName(){");
        jsData.AppendLine(@"var tabView = new YAHOO.widget.TabView();");
        jsData.AppendLine(@"tabView.addTab( new YAHOO.widget.Tab({");
        jsData.AppendLine(@"label: '全部',");
        jsData.AppendLine(@"dataSrc: '../NoticeGet.aspx',");
        jsData.AppendLine(@"cacheData: false,");
        jsData.AppendLine(@"active: true}));");
        for (int i = 0; i < tagXml.ItemList.Count; ++i)
        {
            TagItem tagItem = tagXml.ItemList[i] as TagItem;
            jsData.AppendLine(@"tabView.addTab( new YAHOO.widget.Tab({");
            jsData.AppendLine(@"label: '"+tagItem.TagName+"',");
            jsData.AppendLine(@"dataSrc: '../NoticeGet.aspx?Label=" + HttpUtility.UrlEncode(tagItem.TagName)+"',");
            jsData.AppendLine(@"cacheData: true,");
            jsData.AppendLine(@"active: false}));");
        }
        jsData.AppendLine(@"tabView.appendTo('container');}");
        FileStream MyFileStream;
        MyFileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "JavaScript\\TagControl.js", FileMode.Open, FileAccess.Write, FileShare.Write);
        MyFileStream.SetLength(0);
        StreamWriter sw = new StreamWriter(MyFileStream, Response.ContentEncoding);
        sw.Write(jsData);
        sw.Close();
    }
}
