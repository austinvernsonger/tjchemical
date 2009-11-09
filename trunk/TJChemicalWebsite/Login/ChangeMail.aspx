<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeMail.aspx.cs" Inherits="Login_ChangeMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        请输入新邮箱地址<asp:TextBox ID="tbMailAddress" runat="server"></asp:TextBox>
    
    </div>
    <asp:Button ID="btnCommit" runat="server" onclick="btnCommit_Click" Text="确定" />
    </form>
</body>
</html>
