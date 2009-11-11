<%@ Page Title="软件学院网站管理系统 - [快速链接管理]" Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="QuickLinkMgr.aspx.cs" Inherits="SysMgr_QuickLinkMgr" %>

<%@ Register src="../UserControl/LinkInfoControl.ascx" tagname="LinkInfoControl" tagprefix="uc" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <h3 class="h3style">
        快速链接管理</h3>
    <hr size="0" noshade="noshade" color="#999999" />
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="divstyle">
                <asp:PlaceHolder ID="placeHolder" runat="server"></asp:PlaceHolder>
            </div>
            <div style="position: relative; top: 0px; left: 354px; width: 42px;">
                <asp:Button ID="BtnOK" runat="server" Text="保存" BackColor="WhiteSmoke" BorderColor="Gray"
                    BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" Height="22px" OnClick="BtnOK_Click"
                    Width="65px" />
            </div>
            <div style="position: relative; top: -21px; left: 12px; width: 252px;">
                <asp:Label ID="lbNotify" runat="server" Text="设置选项已保存" Font-Names="Verdana" Font-Size="Small"
                    ForeColor="Red" Visible="False"></asp:Label>
            </div>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

