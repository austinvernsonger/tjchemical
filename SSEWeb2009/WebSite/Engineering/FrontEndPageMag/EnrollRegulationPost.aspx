﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnrollRegulationPost.aspx.cs" Inherits="Engineering_FrontEndPageMag_EnrollRegulationPost" %>

<%@ Register src="../../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布招生简章--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        发布招生简章
    </div>
    <hr />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="42" Mode="Passage" OnSuccessGoTo="EnrollRegulationMag.aspx"  EditHeight="800"  AllowAttachment="true" ToolbarStartExpanded="true"/>
    </div>
    </form>
</body>
</html>