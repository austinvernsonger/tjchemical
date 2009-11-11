<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentIdDisplayControl.ascx.cs" Inherits="Report_Control_DisplayControl_StudentIdDisplayControlControl" %>
<asp:Panel ID="Panel1" runat="server" CssClass="DisplayItemHolder">
    <div class="DisplayItemLabel"><asp:Label ID="Label_lItemName" runat="server" Text="项目名称"></asp:Label></div>
    <div class="DisplayItemControl"><asp:TextBox ID="TB_Result" CssClass="DisplayTextBox" runat="server"></asp:TextBox></div>
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
        EnableViewState="False" Font-Bold="True" Font-Size="Small" ForeColor="Red">
    </asp:BulletedList>
</asp:Panel>
