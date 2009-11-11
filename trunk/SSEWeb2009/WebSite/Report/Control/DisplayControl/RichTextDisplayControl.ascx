<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RichTextDisplayControl.ascx.cs" Inherits="Report_Control_DisplayControl_RichEditDisplayControl" %>
<asp:Panel ID="Panel_Holder" runat="server" EnableViewState="True" CssClass="DisplayItemHolder">
    <div class="DisplayItemLabel"><asp:Label ID="Label_Name" runat="server" Text="Label"></asp:Label></div>
    <div class="DisplayItemControl">
        <asp:TextBox ID="TB_Result"
            runat="server" TextMode="MultiLine" 
             CssClass="DisplayTextBox" Wrap=true></asp:TextBox>
    </div>
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
        EnableViewState="False" Font-Bold="True" Font-Size="Small" ForeColor="Red">
    </asp:BulletedList>
</asp:Panel>


    