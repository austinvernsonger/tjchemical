<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostTest.aspx.cs" Inherits="PostTest" %>

<%@ Register src="UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Report/Resource/Css/ReportStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>   
        <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="0" Mode="Registration" NewPost="true" />
    </div>
    </form>
</body>
</html>
