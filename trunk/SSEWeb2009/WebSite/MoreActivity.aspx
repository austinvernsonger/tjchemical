<%@ Page Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="MoreActivity.aspx.cs" Inherits="MoreActivity" Title="活动列表" %>

<%@ Register src="UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
<link href="CssClass/MoreNews.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="phctnt_body" Runat="Server">
<div class="div_content">
<span style="left:45%; position:relative">活动列表</span>
<uc1:MMTList ID="MMTList1" runat="server"  ShowClickCount="False" Mode="activity"  EmptyString="Empty." AllowPaging="true" PageSize="20"
ShowURL="~/NewsDetail.aspx" ItemCssClass="notice_content_stl1" />
</div>
</asp:Content>

