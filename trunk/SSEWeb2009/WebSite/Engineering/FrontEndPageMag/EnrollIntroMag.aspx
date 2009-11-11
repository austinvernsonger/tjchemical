<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnrollIntroMag.aspx.cs" Inherits="Engineering_FrontEndPageMag_EnrollIntroMag" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>招生简章管理--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        招生简章管理
    </div>
    <hr />
    <br />
    <div>
        <uc1:MMTList ID="MMTList1" runat="server" Management="true"
          AllowPaging="True" DepartmentId="4" Mode="Passage" PageSize="25" ShowClickCount="false" 
          ShowTime="True" InternalOnly="True" ShowURL="~/Engineering/FrontEndPageMag/EnrollIntroPost.aspx" />
    </div>
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Resources/Images/newrecord.PNG" 
        PostBackUrl="~/Engineering/FrontEndPageMag/EnrollIntroPost.aspx"/>
    </div>
    </form>
</body>
</html>
