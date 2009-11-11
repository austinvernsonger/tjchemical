<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimeSpanDisplay.ascx.cs" Inherits="LabCenter_UserControl_TimeSpanDisplay" %>

<div >
<asp:TextBox ID="tbFromTime" runat="server"></asp:TextBox>到
<asp:DropDownList ID="ddlCurDayofWeek" runat="server">
    <asp:ListItem Selected="True" Value="1">周一</asp:ListItem>
    <asp:ListItem Value="2">周二</asp:ListItem>
    <asp:ListItem Value="3">周三</asp:ListItem>
    <asp:ListItem Value="4">周四</asp:ListItem>
    <asp:ListItem Value="5">周五</asp:ListItem>
    <asp:ListItem Value="6">周六</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="tbToTime" runat="server"></asp:TextBox>
</div>