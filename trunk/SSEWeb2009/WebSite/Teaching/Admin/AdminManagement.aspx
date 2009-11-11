<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminManagement.aspx.cs" Inherits="Teaching_Admin_AdminManagement" %>

<%@ Register src="../LinkListEx.ascx" tagname="LinkListEx" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbTitle" runat="server"></asp:Label>
        <br />
        <uc1:LinkListEx ID="LinkListEx" runat="server" />
        <asp:ImageButton ID="ibAdd" runat="server" 
            ImageUrl="~/Resources/Images/newrecord.PNG" />
        <br />
    
    </div>
    </form>
</body>
</html>
