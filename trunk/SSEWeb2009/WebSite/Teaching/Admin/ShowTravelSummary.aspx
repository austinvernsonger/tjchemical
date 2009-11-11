<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowTravelSummary.aspx.cs" Inherits="Teaching_Admin_ShowTravelSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%=ShowSummary() %>
    </div>
    <hr />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Right" 
        ImageUrl="~/Resources/Images/TurnBack.PNG" 
        PostBackUrl="~/Teaching/Admin/AdminManagement.aspx?Type=1" />
    </form>
</body>
</html>
