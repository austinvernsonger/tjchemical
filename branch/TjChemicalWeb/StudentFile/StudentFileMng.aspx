﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="StudentFileMng.aspx.cs" Inherits="StudentFile_StudentFileMng" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    <asp:Label ID="lbErrorMessage" runat="server"></asp:Label>
</p>
<table>
    <tr>
        <td>
            学号：
        </td>
        <td>
            <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            姓名：
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td>
            班级：
        </td>
        <td>
            <asp:TextBox ID="txtClass" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btQuery" runat="server" Text="查询" onclick="btQuery_Click" />
        </td>
        <td>
            <asp:Button ID="btAdd" runat="server" Text="添加" onclick="btAdd_Click" />
        </td>
    </tr>
</table>
<p>
    <asp:GridView ID="GridviewFile" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="true" 
    AutoGenerateEditButton="true" DataKeyNames="StudentID" 
        onrowdeleting="OnRowDeleting" onrowediting="OnRowEditing" AllowPaging="true" PageSize="10">
        <Columns>
            <asp:TemplateField HeaderText="学号">
                <ItemTemplate>
                    <asp:Label ID="lbStudentID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名">
                <ItemTemplate>
                    <asp:Label ID="lbName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="班级">
                <ItemTemplate>
                    <asp:Label ID="lbClass" runat="server" Text='<%# Eval("Class")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</p>
</asp:Content>

