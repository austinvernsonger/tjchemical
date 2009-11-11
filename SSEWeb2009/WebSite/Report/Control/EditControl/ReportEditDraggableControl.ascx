<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportEditDraggableControl.ascx.cs" Inherits="Report_Control_EditControl_ReportEditDraggableControl" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="GeneralEditor" tagprefix="uc1" %>

<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportDropPanel ReportHolderPanelForSelect">
    <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

    <asp:Label ID="Hidden_ReportFullName" runat="server" style="display:none"></asp:Label>

    <asp:Label ID="Hidden_ItemTypeForAttr" runat="server" style="display:none"></asp:Label>
    <asp:Label ID="Hidden_ParentFullName" runat="server" style="display:none"></asp:Label>
    
    <div class = "ReportLabel">
        <asp:Label ID="Label_ReportNameInReportCtrl" runat="server"></asp:Label>
    </div>
    <asp:Panel ID="Panel_SubItem" runat="server" CssClass="ReportSubItemPanel">
        <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
            EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
        </asp:BulletedList>
        <asp:PlaceHolder ID="PlaceHolder_SubItem" runat="server"></asp:PlaceHolder>
    </asp:Panel>
</asp:Panel>

<asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
    EnableViewState="False" Interval="1">
</asp:Timer>
