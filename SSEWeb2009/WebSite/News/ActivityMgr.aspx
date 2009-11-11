<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="ActivityMgr.aspx.cs" Inherits="News_ActivityMgr" Title="无标题页" %>

<%@ Register src="../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <h3  class="title">活动管理</h3>
    <div class="divstyle">
    <uc1:MMTList ID="MMTList1" runat="server" Management="true" Mode="activity" ShowURL="~/News/ActivityEdit.aspx"/>
    </div>
</asp:Content>

