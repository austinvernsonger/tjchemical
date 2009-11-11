<%@ Page Title="管理信息" Language="C#" MasterPageFile="~/AlumnusRecord/Admin/MasterPageBack.master" AutoEventWireup="true" CodeFile="manageInfo.aspx.cs" Inherits="AlumnusRecord_Admin_manageInfo" %>

<%@ Register Src="../../UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="ucl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="varContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label2" runat="server" Text="请选择管理信息类型：" Height="20px"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="1">院友动态</asp:ListItem>
        <asp:ListItem Value="6">院友访谈</asp:ListItem>
    </asp:DropDownList>
    <ucl:MMTList ID="MMTList1" runat="server" AllowPaging="True" DepartmentId="1" 
            Management="True" Mode="news" PageSize="20" ShowClickCount="True" 
            ShowTime="True" InternalOnly="True" 
            ShowURL="../AlumnusRecord/showInfo.aspx" />
</asp:Content>

