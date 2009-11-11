<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MailHtmlContent.ascx.cs" Inherits="LabCenter_Repair_UserControl_MailHtmlContent" %>
<asp:Label ID="lblNavinfo" runat="server" Text="发送信息到："></asp:Label>
<asp:TextBox ID="tbEmail" runat="server" Width="150px" ></asp:TextBox>
<asp:Button ID="btnEmail" runat="server" Text="发送" OnClick="btnEmail_Click" />