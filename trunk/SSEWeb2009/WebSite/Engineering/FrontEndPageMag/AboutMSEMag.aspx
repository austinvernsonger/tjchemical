<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutMSEMag.aspx.cs" Inherits="Engineering_FrontEndPageMag_AboutMSEMag" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<%@ Register src="../../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>关于中心--工程硕士</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        中心简介
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <uc2:ViewMMT ID="ViewMMT1" runat="server"  MMTID="ABOUT_MSE" ShowClickCount="False" ShowLabel="False" ShowTitle="False" />
    </div>
    </form>
</body>
</html>
