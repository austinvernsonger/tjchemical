﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="WorkingPlaceManage.aspx.cs" Inherits="StudentInfo_admin_WorkingPlaceManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    <asp:GridView ID="GridviewWorkingPlace" runat="server" 
        AutoGenerateDeleteButton="true" DataKeyNames="WorkUnitID" 
        onrowdeleting="OnRowDeleting" AutoGenerateColumns = "false">
        <Columns>
            <asp:TemplateField HeaderText = "单位编号">
                <ItemTemplate>
                    <asp:Label ID="lbWorkUnitID" runat="server" Text='<%# Eval("WorkUnitID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText = "单位名称">
                <ItemTemplate>
                    <asp:Label ID="lbWorkUnitName" runat="server" Text='<%# Eval("WorkUnitName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
</p>
<p>
    工作单位名称：
    <asp:TextBox ID="txtWorkingPlaceName" runat="server"></asp:TextBox>
    <asp:Button ID="bt_AddWorkingPlace" runat="server" Text="添加" 
        onclick="bt_AddWorkingPlace_Click" />
</p>
<p>
     <asp:Label ID="ERRORMessage" runat="server" Text=""></asp:Label>
</p>
</asp:Content>

