<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approve.aspx.cs" Inherits="Teaching_Admin_Approve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server" target="_top">
    <div>
    
        <asp:Button ID="bnAgree" runat="server" Text=" 同意 " onclick="bnAgree_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bnDisAgree" runat="server" Text="不同意" 
            onclick="bnDisAgree_Click" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bnCancel" runat="server" Text=" 取消 " onclick="bnCancel_Click" />
    
    </div>
    </form>
</body>
</html>
