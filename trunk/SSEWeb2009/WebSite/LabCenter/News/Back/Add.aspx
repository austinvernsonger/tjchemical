﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="LabCenter_News_Add" %>
<%@ Register src="~/UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="3" Mode="news" 
        NewPost="True" onsuccessgoto="~/LabCenter/News/Back/Editlist.aspx" 
        AllowAttachment="false" />
    </div>
    </form>
</body>
</html>