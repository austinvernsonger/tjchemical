<%@ Page Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="NoticeDetail.aspx.cs" Inherits="NoticeDetail" Title="通知详情" %>

<%@ Register src="UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="ctnt_head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ctnt_body" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <div class="news_detail_div">
        <uc1:ViewMMT ID="notice_mmt" runat="server" ShowClickCount="False" ShowLabel="False" TitleCssClass="news_detail_title"/>
    </div>
</asp:Content>

