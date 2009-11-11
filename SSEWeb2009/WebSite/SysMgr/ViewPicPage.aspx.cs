using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;



/// <summary>
/// 页面：SysMgr_ViewPicPage - 浏览服务器端图片的框架页面
/// 作者：Constantine
/// 最近一次修改时间：2009-6-24
/// </summary>
public partial class SysMgr_ViewPicPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }

        if (!IsPostBack)
        {
            //初始化文件夹树
            InitTreeView();
        }
    }

    /// <summary>
    /// 初始化文件夹树，并生成TreeView
    /// </summary>
    private void InitTreeView()
    {
        try
        {
            DirectoryViewer dirView = new DirectoryViewer();
            String dir = Server.MapPath("~/Files/Upload/");
            //得到文件夹信息
            Hashtable hashList = dirView.GetDictionayInfo(dir);

            this.treeViewDir.Nodes.Clear();
            //创建根结点
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "图片文件夹";
            rootNode.NavigateUrl = "PicListContent.aspx#";
            rootNode.Expanded = true;
            //创建子结点
            foreach(DictionaryEntry de in hashList)
            {
                TreeNode node = new TreeNode();
                node.Text = de.Key.ToString();
                node.NavigateUrl = "PicListContent.aspx#";
                node.Expanded = false;

                String subDir = Server.MapPath("~" + de.Value.ToString());
                //得到子结点的文件夹信息
                Hashtable subHashList = dirView.GetDictionayInfo(subDir);
                //创建二级子结点
                foreach (DictionaryEntry deSub in subHashList)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Text = deSub.Key.ToString();
                    subNode.NavigateUrl = "PicListContent.aspx?dir=" + deSub.Value.ToString();
                    node.ChildNodes.Add(subNode);
                }

                rootNode.ChildNodes.Add(node);
            }

            this.treeViewDir.Nodes.Add(rootNode);
        }
        catch (System.Exception e)
        {
            this.lbDebug.Text = e.Message;
            this.lbDebug.Visible = true;
        }
    }
}
