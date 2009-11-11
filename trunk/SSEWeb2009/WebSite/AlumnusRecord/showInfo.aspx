<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/MasterPage.master" AutoEventWireup="true" CodeFile="showInfo.aspx.cs" Inherits="AlumnusRecord_showInfo" %>
<%@ Register Src="../UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="ucl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ucl:ViewMMT ID="view" runat="server" />
    <li><asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">返回</asp:LinkButton>
        </li>		
</asp:Content>



