<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="Teaching_Admin_NewsEdit" %>

<%@ Register src="../../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="2" Mode="news" 
        NewPost="True" onsuccessgoto="NewsManagement.aspx" />
    </form>
</body>
</html>
