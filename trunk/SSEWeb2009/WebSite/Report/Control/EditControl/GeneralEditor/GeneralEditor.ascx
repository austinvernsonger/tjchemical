<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GeneralEditor.ascx.cs" Inherits="Report_Control_EditControl_GeneralEditor_GeneralEditor" %>



<asp:Panel ID="Panel_GeneralEditorHolder" runat="server" CssClass="GeneralEditorHolder">
    <asp:ImageButton ID="BN_Delete" runat="server"  
    Text="删除" BorderStyle="Solid" Height="20px" onclick="BN_Delete_Click"
    ImageUrl="~/Report/Resource/Image/delete.png" Width="20px" 
    CssClass="ImageButton" ToolTip="删除" />
    <asp:ImageButton ID="BN_MoveUP" runat="server" CssClass="ImageButton" 
        Height="20px" ImageUrl="~/Report/Resource/Image/up.png" 
         Text="向上" Width="20px" ToolTip="向上" onclick="BN_MoveUP_Click" />
    <asp:ImageButton ID="BN_MoveDown" runat="server" CssClass="ImageButton" 
        Height="20px" ImageUrl="~/Report/Resource/Image/down.png" onclick="BN_MoveDown_Click"
         Text="向下" Width="20px" ToolTip="向下" />
</asp:Panel>


