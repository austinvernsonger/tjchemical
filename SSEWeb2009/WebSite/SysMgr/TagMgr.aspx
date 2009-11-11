<%@ Page Title="软件学院网站管理系统 - [标签管理]" Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="TagMgr.aspx.cs" Inherits="SysMgr_TagMgr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="../UserControl/TagInfoControl.ascx" tagname="TagInfoControl" tagprefix="uc" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
<h3 class="h3style">
        标签管理</h3>
    <hr size="0" noshade="noshade" color="#999999"/>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="divstyle">
                <asp:LinkButton ID="lbNew" runat="server" OnClick="lbNew_Click" ForeColor="#333333">添加标签</asp:LinkButton>
                |
                <asp:LinkButton ID="lbDelete" runat="server" ForeColor="#333333" OnClick="lbDelete_Click">删除标签</asp:LinkButton>
                |
                <asp:LinkButton ID="lbSave" runat="server" ForeColor="#333333" OnClick="lbSave_Click">保存设置</asp:LinkButton>&nbsp;
                <asp:Label ID="lbNotify" runat="server" Text="通知" ForeColor="Red" 
                    Visible="False"></asp:Label>
                <br /><br />
                <asp:Label ID="lbNote" runat="server" Text="[注意：使用过程中可能遇到不能保存原值的情况，再试一次即可]" 
                    Font-Bold="True"></asp:Label>
                <br />
                <asp:PlaceHolder ID="placeHolder" runat="server"></asp:PlaceHolder>
            </div>
            <br />
            <asp:Timer ID="timerPostBack" runat="server" Enabled="False" EnableViewState="False" 
                Interval="1"> </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

