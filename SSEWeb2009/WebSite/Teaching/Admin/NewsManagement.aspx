<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsManagement.aspx.cs" Inherits="Teaching_Admin_NewsManagement" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <p>
        新闻管理</p>
    <div>
        <uc1:MMTList ID="MMTList2" runat="server" AllowPaging="True" DepartmentId="2" 
            Management="True" Mode="news" PageSize="20" ShowClickCount="True" 
            ShowTime="True" 
            ShowURL="../Teaching/Admin/NewsEditContent.aspx" />
    </div>
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Resources/Images/newrecord.PNG" 
        PostBackUrl="~/Teaching/Admin/NewsEdit.aspx" />
    </form>
    </form>
    
    </form>
</body>
</html>
