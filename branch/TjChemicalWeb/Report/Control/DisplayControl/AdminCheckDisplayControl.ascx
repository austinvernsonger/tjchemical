<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminCheckDisplayControl.ascx.cs" Inherits="Report_Control_DisplayControl_AdminCheckDisplayControl" %>
<asp:Panel ID="Panel_Holder" runat="server" CssClass="DisplayItemHolder">
    <div class="DisplayItemLabel"><asp:Label ID="Label_Name" runat="server"></asp:Label></div>
    <div class="DisplayItemControl">
    <asp:DropDownList ID="DropDownList_Result" runat="server">
        <asp:ListItem>未审核</asp:ListItem>
        <asp:ListItem>未通过</asp:ListItem>
        <asp:ListItem>已通过</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
        EnableViewState="False" Font-Bold="True" Font-Size="Small" ForeColor="Red">
    </asp:BulletedList>
    </div>
 
</asp:Panel>
