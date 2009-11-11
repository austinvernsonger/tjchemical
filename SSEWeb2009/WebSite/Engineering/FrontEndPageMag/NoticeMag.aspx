<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeMag.aspx.cs" Inherits="Engineering_FrontEndPageMag_NoticeMag" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>通知管理--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        通知管理
    </div>
    <hr />
    <br />
    <div>
        <uc1:MMTList ID="MMTList1" runat="server" Management="true"
          AllowPaging="True" DepartmentId="4" Mode="Notice" PageSize="30" ShowClickCount="false" 
          ShowTime="True" InternalOnly="True" ShowURL="~/Engineering/FrontEndPageMag/NoticePost.aspx" />  
    </div>
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Resources/Images/newrecord.PNG" 
        PostBackUrl="~/Engineering/FrontEndPageMag/NoticePost.aspx"/>
    </div>
    </form>
</body>
</html>
