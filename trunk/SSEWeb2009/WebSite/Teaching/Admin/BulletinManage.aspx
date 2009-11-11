<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BulletinManage.aspx.cs" Inherits="Teaching_Admin_BulletinManage" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        公告管理<br/>
    
        <uc1:MMTList ID="MMTList1" runat="server" AllowPaging="True" DepartmentId="2" 
            Management="True" Mode="notice" PageSize="20" ShowClickCount="True" 
            ShowTime="True" 
            ShowURL="../Teaching/Admin/BulletinEditContent.aspx" />
    
    </div>
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Resources/Images/newrecord.PNG" 
        PostBackUrl="~/Teaching/Admin/BulletinEdit.aspx" />
    </form>
</body>
</html>
