<%@ Page Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="NewsDetail.aspx.cs" Inherits="NewsDetail" Title="新闻详情" %>

<%@ Register src="UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <div class="news_detail_div">
        <uc1:ViewMMT ID="news_mmt" runat="server" ShowClickCount="False" ShowLabel="False" TitleCssClass="news_detail_title" />
    </div>
</asp:Content>

