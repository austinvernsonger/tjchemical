<%@ Page Title="" Language="C#" MasterPageFile="~/Teaching/MainFrame.master" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="Teaching_Content" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlace" Runat="Server">

<%=GetContent() %>

</asp:Content>

