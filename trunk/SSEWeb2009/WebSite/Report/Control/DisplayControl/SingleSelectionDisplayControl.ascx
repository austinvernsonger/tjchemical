<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SingleSelectionDisplayControl.ascx.cs" Inherits="Report_Control_DisplayControl_SingleSelectionDesplayControl" %>
<asp:Panel ID="Panel_Holder" runat="server" CssClass="DisplayItemHolder">

    <div class="DisplayItemLabel"><asp:Label ID="Label_Name" runat="server"></asp:Label></div>
    <div class = "DisplayItemControl"><asp:RadioButtonList ID="RadioButtonList_Selections" runat="server" 
        RepeatColumns="4">
    </asp:RadioButtonList>
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
        EnableViewState="False" Font-Bold="True" Font-Size="Small" ForeColor="Red">
    </asp:BulletedList>
    </div>
</asp:Panel>
