<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditDefaultTime.aspx.cs" Inherits="LabCenter_Reservation_Back_EditDefaulTime" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../UserControl/TimeTableEdit.ascx" TagName="TimeTableEdit" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="~/LabCenter/Reservation/UserControl/TabContainer.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
    <asp:Label ID="lbledit" Text="修改默认时间段设置:" runat="server"></asp:Label>
    <asp:Button ID="btnsave" Text="保存修改" runat="server" OnClick="btnsave_Click" />
    <hr /><br />
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />    
        <uc1:TimeTableEdit id="TimeTableEdit1" runat="server">
        </uc1:TimeTableEdit>
        <asp:Label ID="lblsave" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
