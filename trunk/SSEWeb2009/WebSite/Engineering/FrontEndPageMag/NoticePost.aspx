<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticePost.aspx.cs" Inherits="Engineering_FrontEndPageMag_NoticePost" %>

<%@ Register src="../../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布通知--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        发布通知
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <uc1:EditMMT ID="EditMMT1" runat="server"  DepartmentId="4" Mode="Notice" AllowAttachment="true" EditHeight="800" onsuccessgoto="NoticeMag.aspx" ToolbarStartExpanded="true"/>
    </div>
    </form>
</body>
</html>
