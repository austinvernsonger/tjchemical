<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAffair/MasterPage.master" AutoEventWireup="true" CodeFile="Show.aspx.cs" Inherits="StudentAffair_Show" %>
<%@ Register Src="../UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="ucl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ucl:ViewMMT ID="view" runat="server"></ucl:ViewMMT>
</asp:Content>

