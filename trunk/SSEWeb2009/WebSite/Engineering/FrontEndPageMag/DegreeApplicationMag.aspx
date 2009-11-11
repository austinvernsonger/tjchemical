<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DegreeApplicationMag.aspx.cs" Inherits="Engineering_FrontEndPageMag_DegreeApplicationMag" %>

<%@ Register src="../../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理申请答辩流程--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        申请答辩流程
    </div>
    <hr />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:ViewMMT ID="ViewMMT1" runat="server" MMTID="DEGREE_APPLICATION" ShowClickCount="False" ShowLabel="False" ShowTitle="False" />    
    </div>
    </form>
</body>
</html>
