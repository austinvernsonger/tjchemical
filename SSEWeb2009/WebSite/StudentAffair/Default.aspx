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
                <h2 style="background-color: #99FF66">��Щ���Ŵ�ҿ��Կ���(Բ��)</h2>
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
                <h2 style="background-color: #99FF66;">��Щ֪ͨ��ҿ��Կ���(Բ��)</h2>
                    
                
                </div>
                <div>
                    <asp:GridView ID="GridView2" runat="server" Width="100%">
                    </asp:GridView>
                </div>
                <div>
                    <ul style="list-style-type: none; width: 100%; margin-left: 0px; margin-top: 5px;">
                        <li>ȫ��</li>
                        <li>��ҵ</li>
                        <li>��������</li>
                        <li>����</li>
                        <li>��ѧ</li>
                        <li>����</li>
                    </ul>
                </div>
                
                &nbsp;</div>
            <br />
            <div id="stdpic">
            
                <h2 style="background-color: #99FF66">��Щѧ����ɴ�ҿ��Կ���(Բ��)</h2>
                <div style="width: 445px; float: left; text-indent: 2em; margin-right: 5px;">
                &nbsp;��ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ�;��ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ���ͼƬ��ص��ı���Ͷ��ժҪ��ͼƬ˵���ȵ�[��ϸ...]</div>
                <div style="width: 250px; float: left;">
                    <asp:Image ID="Image1" runat="server" Height="190px" Width="250px" />
                    </div>
                <br />
                <br />
            
            </div>
        </div>
        <div id="sideBar" style="width: 230px; float:right;">
            <div id="links">
                <asp:Label ID="Label1" runat="server" Text="��������"></asp:Label>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server">ͬ�ô�ѧ</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server">ͬ�ô�ѧ��ҵ����</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server">ͬ�ô�ѧѧ����</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server">ͬ�ô�ѧ�о���Ժ</asp:HyperLink>
                <br />
                <br />
                <hr />
                <br />
                <asp:HyperLink ID="HyperLink13" runat="server">���ѧԺ��ҳ</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink14" runat="server">����</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink5" runat="server">ʵϰ�칫��</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink6" runat="server">Ժ��֮��</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink7" runat="server">���ֲ�</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink12" runat="server">ѧ��ϵͳ</asp:HyperLink>
                <br />
            </div>
        </div>
        <div style="clear:both;"></div>
    </div>
</asp:Content>

