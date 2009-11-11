<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAffair/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="StudentAffair_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
#noticeDiv ul li
{
    display: inline;
    white-space: normal;
    margin: 0 5px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <div id="leftContainer" style="width: 710px; float: left; margin-right: 10px;">
            <div id="newsDiv">
                
                <div>
                <h2 style="background-color: #99FF66">有些新闻大家可以看看(圆角)</h2>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" Width="100%">
                    </asp:GridView>
                    <br />
                </div>
                
            </div>
            <br />
            <div id="noticeDiv">
                <div>
                <h2 style="background-color: #99FF66;">有些通知大家可以看看(圆角)</h2>
                    
                
                </div>
                <div>
                    <asp:GridView ID="GridView2" runat="server" Width="100%">
                    </asp:GridView>
                </div>
                <div>
                    <ul style="list-style-type: none; width: 100%; margin-left: 0px; margin-top: 5px;">
                        <li>全部</li>
                        <li>就业</li>
                        <li>形势任务</li>
                        <li>评优</li>
                        <li>助学</li>
                        <li>其他</li>
                    </ul>
                </div>
                
                &nbsp;</div>
            <br />
            <div id="stdpic">
            
                <h2 style="background-color: #99FF66">有些学生风采大家可以看看(圆角)</h2>
                <div style="width: 445px; float: left; text-indent: 2em; margin-right: 5px;">
                &nbsp;与图片相关的文本：投稿摘要，图片说明等等;与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等与图片相关的文本：投稿摘要，图片说明等等[详细...]</div>
                <div style="width: 250px; float: left;">
                    <asp:Image ID="Image1" runat="server" Height="190px" Width="250px" />
                    </div>
                <br />
                <br />
            
            </div>
        </div>
        <div id="sideBar" style="width: 230px; float:right;">
            <div id="links">
                <asp:Label ID="Label1" runat="server" Text="快速链接"></asp:Label>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server">同济大学</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server">同济大学就业中心</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server">同济大学学生处</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server">同济大学研究生院</asp:HyperLink>
                <br />
                <br />
                <hr />
                <br />
                <asp:HyperLink ID="HyperLink13" runat="server">软件学院首页</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink14" runat="server">教务处</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink5" runat="server">实习办公室</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink6" runat="server">院友之家</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink7" runat="server">俱乐部</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink12" runat="server">学生系统</asp:HyperLink>
                <br />
            </div>
        </div>
        <div style="clear:both;"></div>
    </div>
</asp:Content>

