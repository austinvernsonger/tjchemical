<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="DownloadingPage.aspx.cs" Inherits="Teaching_Download" %>






<%@ Register src="../LinkListEx.ascx" tagname="LinkListEx" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../CssClass/TeachingFront.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <div id="mid_body_up" style="width:902px; margin-left:auto; margin-right:auto; background-image:url(../../Resources/Images/mid_body_up.jpg); border:0; padding:0;"></div>
    <div id="mid_body_mid" style="width:902px; margin-left:auto; margin-right:auto; background-image:url(../../Resources/Images/mid_body_mid.jpg); border:0; padding:0;">
        <div id="mid_body_mid_body" style="width:422px; margin-left:auto; margin-right:auto; border:0; padding:0;">
            <asp:Label ID="Label1" runat="server" Text="文档模板下载"></asp:Label>
            <uc2:LinkListEx ID="DownLoadList" runat="server" QuerySQL="select *,-1 as FS from [TemplateFile]" />
        </div>
    </div>
    <div id="mid_body_down" style="width:902px; margin-left:auto; margin-right:auto; background-image:url(../../Resources/Images/mid_body_down.jpg); border:0; padding:0;"></div>
</asp:Content>

