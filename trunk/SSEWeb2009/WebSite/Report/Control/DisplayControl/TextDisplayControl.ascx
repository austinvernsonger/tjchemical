<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextDisplayControl.ascx.cs" Inherits="Report_Control_DisplayControl_TextDisplayControl" %>
<asp:Panel ID="Panel_Holder" runat="server" CssClass="DisplayItemHolder">

    <div class="DisplayItemLabel"><asp:Label ID="Labe_lItemName" runat="server" Text="项目名称"></asp:Label></div>
    <div class="DisplayItemControl"><asp:TextBox ID="TB_Result" runat="server" 
            CssClass="DisplayTextBox"></asp:TextBox></div>
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
        EnableViewState="False" Font-Bold="True" Font-Size="Small" ForeColor="Red">
    </asp:BulletedList>
    
</asp:Panel>
