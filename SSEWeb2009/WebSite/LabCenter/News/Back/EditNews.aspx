<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditNews.aspx.cs" Inherits="LabCenter_News_Back_EditNews" %>
<%@ Register Src="~/UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="ucl" %>
<%@ Register Src="~/UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="ucl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SSE WEB</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        SSE Web 2009
        <asp:HyperLink ID="lnk_sysmgr" runat="server" NavigateUrl="~/SysMgr/">SysMgr</asp:HyperLink>
        <asp:HyperLink ID="lnk_report" runat="server" NavigateUrl="~/Report/">Report Test</asp:HyperLink>
        
        <br />
        <br />
        <br />
        <div style="width: 75%"><ucl:EditMMT ID="editMMT" runat="server" Mode="news" /></div>
        <div style="width: 75%"><ucl:ViewMMT ID="viewMMT" runat="server" MMTID="a86edaea8ce04580bb658889e5e9692b" /></div>
        
    </div>
    </form>
</body>
</html>
