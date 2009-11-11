<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="NewNewsAuthority.aspx.cs" Inherits="SysMgr_NewNewsAuthority" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phctnt_head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
<div style="font-size:12px; font-family:宋体; color:Black;">
    <table class="style1">
        <tr>
            <td>
                <span>新闻账号:</span></td>
            <td>
                <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span>名字:</span></td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />
</div>
</asp:Content>