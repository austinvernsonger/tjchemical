<%@ Page Language="C#" MasterPageFile="~/Engineering/MseSubNewsPage.master" AutoEventWireup="true" CodeFile="newsandevents.aspx.cs" Inherits="Engineering_newsandevents" Title="无标题页" %>

<%@ Register src="../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <img src="Resources/images/banner_news.jpg" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Label ID="lblTitle2" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:MMTList ID="MMTList1" runat="server" />
</asp:Content>

