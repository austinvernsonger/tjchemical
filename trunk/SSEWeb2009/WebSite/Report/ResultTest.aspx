<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultTest.aspx.cs" Inherits="Report_ResultTest" %>

<%@ Register src="Control/ResultControl/StatisticsControl.ascx" tagname="StatisticsControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Resource/Css/DisplayControlStyleSheet.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Label ID="Hidden_ResultFilePAth" runat="server" Visible="False"></asp:Label>
    
        <asp:Label ID="Hidden_DescriptorFilePAth" runat="server" Visible="False"></asp:Label>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:StatisticsControl ID="StatisticsControl1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
