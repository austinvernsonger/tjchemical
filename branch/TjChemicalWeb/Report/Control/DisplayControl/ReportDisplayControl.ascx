<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportDisplayControl.ascx.cs" Inherits="Report_Control_DisplayControl_ReportDisplayControl" %>
<asp:Panel ID="Panel_Holder" runat="server">
    <div class = "ReportLabel">
    <asp:Label ID="Label_ReportName" runat="server"></asp:Label>
    </div>
    <asp:Panel ID="Panel_SubItem" runat="server" CssClass="ReportSubItemPanel">
        <asp:PlaceHolder ID="PlaceHolder_SubItem" runat="server"></asp:PlaceHolder>
        <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
            EnableViewState="False" Font-Bold="True" Font-Size="Small" ForeColor="Red">
        </asp:BulletedList>
    </asp:Panel>
</asp:Panel>


