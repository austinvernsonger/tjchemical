<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editlist.aspx.cs" Inherits="LabCenter_Notice_Back_Editlist" %>

<%@ Register src="~/UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

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
    
        <uc1:MMTList ID="MMTList1" runat="server" AllowPaging="True" DepartmentId="3" 
            Management="True" Mode="Notice" PageSize="20" ShowClickCount="True" 
            ShowTime="True" InternalOnly="True" 
            ShowURL="~/LabCenter/Notice/Back/Edit.aspx" />
    </div>
    </form>
</body>
</html>
