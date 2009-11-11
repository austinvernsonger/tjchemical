<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true"
    CodeFile="ShowNews.aspx.cs" Inherits="Teaching_FrontEnd_ShowNews" %>
<%@ Register Src="../../UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CssClass/TeachingFront.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" runat="Server">
    <div id="mid_body_up" style="width: 902px; margin-left: auto; margin-right: auto;
        background-image: url(../../Resources/Images/mid_body_up.jpg); border: 0; padding: 0;">
    </div>
    <div id="mid_body_mid" style="width: 902px; margin-left: auto; margin-right: auto;
        background-image: url(../../Resources/Images/mid_body_mid.jpg); border: 0; padding: 0;">
        <div id="mid_body_mid_body" style="width: 422px; margin-left: auto; margin-right: auto;
            border: 0; padding: 0;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <uc1:ViewMMT ID="ViewMMT1" runat="server" />
        </div>
    </div>
    <div id="mid_body_down" style="width: 902px; margin-left: auto; margin-right: auto;
        background-image: url(../../Resources/Images/mid_body_down.jpg); border: 0; padding: 0;">
    </div>
</asp:Content>
