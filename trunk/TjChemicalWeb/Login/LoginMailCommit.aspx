<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginMailCommit.aspx.cs" Inherits="Login_LoginMailCommit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        请输入您的邮箱认证地址：<asp:TextBox ID="tbMailAddress" runat="server"></asp:TextBox>
        <asp:Button ID="btnCommit" runat="server" Text="确认" onclick="btnCommit_Click" />
    </div>
    </form>
</body>
</html>
