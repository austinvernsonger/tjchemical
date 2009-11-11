<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimeSpanEdit.ascx.cs" Inherits="LabCenter_UserControl_TimeSpanEdit" %>

<div >
<asp:TextBox ID="tbFromTime" runat="server" OnTextChanged="tbFromTime_TextChanged"></asp:TextBox>到
<asp:DropDownList ID="ddlCurDayofWeek" runat="server" OnSelectedIndexChanged="ddlCurDayofWeek_SelectedIndexChanged">
    <asp:ListItem Selected="True" Value="1">周一</asp:ListItem>
    <asp:ListItem Value="2">周二</asp:ListItem>
    <asp:ListItem Value="3">周三</asp:ListItem>
    <asp:ListItem Value="4">周四</asp:ListItem>
    <asp:ListItem Value="5">周五</asp:ListItem>
    <asp:ListItem Value="6">周六</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="tbToTime" runat="server" OnTextChanged="tbToTime_TextChanged"></asp:TextBox>
</div>