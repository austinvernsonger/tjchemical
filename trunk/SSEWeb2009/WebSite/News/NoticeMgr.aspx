<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="NoticeMgr.aspx.cs" Inherits="News_NoticeMgr" Title="无标题页" %>

<%@ Register src="../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <h3  class="title">通知管理</h3>
    <div class="divstyle">
    <uc1:MMTList ID="MMTList1" runat="server" Management="true" Mode="notice" ShowURL="~/News/NoticeEdit.aspx"/>
    </div>
</asp:Content>
