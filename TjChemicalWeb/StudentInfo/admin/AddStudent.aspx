<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="StudentInfo_admin_AddStudent" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    <asp:Label ID="lbErrorMessage" Visible = "false" runat="server"></asp:Label>
    <asp:GridView ID="GridViewStudentInfo" runat="server" AutoGenerateColumns="false" DataKeyNames="AccountID">
        <Columns>
            <asp:TemplateField HeaderText="学号">
                <ItemTemplate>
                    <asp:Label ID="lbStudentID" runat="server" Text='<%# Eval("AccountID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名">
                <ItemTemplate>
                    <asp:Label ID="lbName" runat="server" Text='<%# Eval("Name")%>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</p>
<table>
    <tr>
        <td>
            学号：
        </td>
        <td>
            <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
        </td>
        <td>
            姓名：
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="AddInfo" runat="server" Text="添加" onclick="AddInfo_Click" />
        </td>
    </tr>
</table>
</asp:Content>

