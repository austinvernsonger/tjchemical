<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="NoticeView.aspx.cs" Inherits="Notice_Student_NoticeView" Title="Untitled Page" %>

<%@ Register src="../../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:ViewMMT ID="ViewMMT1" runat="server" ShowClickCount="False" ShowLabel="False" TitleCssClass="news_detail_title"/>
</asp:Content>

