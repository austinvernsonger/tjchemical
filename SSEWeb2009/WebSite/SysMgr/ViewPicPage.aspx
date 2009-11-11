<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPicPage.aspx.cs" Inherits="SysMgr_ViewPicPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../CssClass/sysmgr_contentstyle.css" />
</head>
<body>
    <form id="formMain" runat="server">
    <ajaxToolKit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolKit:ToolkitScriptManager>
    <asp:Label ID="lbDebug" runat="server" Text="Label" Visible="False"></asp:Label>
     <asp:Panel ID="PanelMain" runat="server"  CssClass="dragPanel" style="display:block;" ScrollBars="None" Width="150">
        <asp:Panel ID="PanelTitle" runat="server" style="cursor: move;" BackColor="#666666" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1">
            <div style="padding: 2px; color: #FFFFFF; font-size: small;">
                  服务器文件夹列表
            </div>
         </asp:Panel>
          <div style="margin: 1px">
         <asp:TreeView ID="treeViewDir" runat="server" ShowLines="True" Target="contentFrm" 
                  Font-Names="Tahoma" Font-Size="Small" ForeColor="#333333">
             <HoverNodeStyle BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
        </asp:TreeView>
        </div>
    </asp:Panel>
    
        <ajaxToolKit:DragPanelExtender ID="dragPanelExtender" runat="server" TargetControlID="PanelMain" DragHandleID="PanelTitle">
        </ajaxToolKit:DragPanelExtender>

        <iframe name="contentFrm" 
        style="border: 1px solid #808080; width: 470px; height: 380px;" align="right" frameborder="0"></iframe>
    
    </form>
</body>
</html>
