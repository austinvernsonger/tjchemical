<%@ Page Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="MoreNotice.aspx.cs" Inherits="MoreNotice" Title="通知列表" %>

<%@ Register src="UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="CssClass/MoreNews.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
<div class="div_content">
<span style="left:45%; position:relative">通知列表</span>
<uc1:MMTList ID="MMTList1" runat="server"  ShowClickCount="False" Mode="notice"  EmptyString="Empty." AllowPaging="true" PageSize="20"
ShowURL="~/NoticeDetail.aspx" ItemCssClass="notice_content_stl1" />
</div>
</asp:Content>

