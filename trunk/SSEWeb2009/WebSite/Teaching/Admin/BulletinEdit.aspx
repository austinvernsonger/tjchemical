﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BulletinEdit.aspx.cs" Inherits="Teaching_Admin_BulletinEdit" %>

<%@ Register src="../../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    
  
    
        <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="2" Mode="notice" 
            NewPost="True" onsuccessgoto="BulletinManage.aspx" />
    
  
    
    </div>
    </form>
</body>
</html>