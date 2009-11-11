<%@ Page Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="ActivityDetail.aspx.cs" Inherits="ActivityDetail" Title="活动详情" %>

<%@ Register src="UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CssClass/MoreNews.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
<div class="news_detail_div">
    <uc1:ViewMMT ID="ViewMMT1" runat="server" TitleCssClass="title" TimeCssClass="time" LocationCssClass="location" />
</div>
</asp:Content>

