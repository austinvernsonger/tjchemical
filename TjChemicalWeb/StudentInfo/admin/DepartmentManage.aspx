﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="DepartmentManage.aspx.cs" Inherits="StudentInfo_admin_DepartmentManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    <asp:GridView ID="GridViewDepartment" runat="server" AutoGenerateDeleteButton="True"
        onrowdeleting="OnRowDeleting">
    </asp:GridView>
</p>
<p>
    系所名称
    <asp:TextBox ID="txtDepartmentName" runat="server"></asp:TextBox>
    <asp:Button ID="bt_addDepartmentName" runat="server" Text="添加" 
        onclick="bt_addDepartmentName_Click" />
</p>
<p>
    <asp:Label ID="ERRORMessage" runat="server" Text=""></asp:Label>
</p>
</asp:Content>

