<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginAccess.ascx.cs" Inherits="UserControl_LoginAccess" %>
<asp:Panel ID="plForLogin" runat="server">
    <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/Login/Login.aspx">登陆</asp:HyperLink>
</asp:Panel>
<asp:Panel ID="plForLogout" runat="server">
    <asp:HyperLink ID="hlAccount" runat="server" NavigateUrl="~/sse_sys.aspx">个人账户</asp:HyperLink>
    <asp:HyperLink ID="hlLogout" runat="server" NavigateUrl="~/Login/Logout.aspx">登出</asp:HyperLink>
</asp:Panel>

