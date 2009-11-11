<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnrollRegulationMag.aspx.cs" Inherits="Engineering_FrontEndPageMag_EnrollRegulationMag" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理招生简章--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        管理招生简章
    </div>
    <hr />
    <br />
    <div>
        <uc1:MMTList ID="MMTList1" runat="server" Management="true"
          AllowPaging="True" DepartmentId="42" Mode="Passage" PageSize="25" ShowClickCount="false" 
          ShowTime="True" InternalOnly="True" ShowURL="~/Engineering/FrontEndPageMag/EnrollRegulationPost.aspx" TitleMaxLength="15"/>
    </div>
     <div>
        <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Resources/Images/newrecord.PNG" 
        PostBackUrl="~/Engineering/FrontEndPageMag/EnrollRegulationPost.aspx"/>
    </div>
    </form>
</body>
</html>
