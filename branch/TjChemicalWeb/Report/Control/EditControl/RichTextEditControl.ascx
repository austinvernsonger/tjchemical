<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RichTextEditControl.ascx.cs" Inherits="Report_Control_EditControl_RichTextEditControl" %>
<%@ Register src="GeneralEditor/PropertyEditor.ascx" tagname="propertyeditor" tagprefix="uc2" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="generaleditor" tagprefix="uc1" %>
<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportHolderPanel ReportHolderPanelForSelect">
    <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

    <div class="EditItemLabel">富文本</div>
    <div class=""EditItemControl">
        <asp:TextBox ID="TB_ItemName" runat="server" AutoPostBack="True" 
        EnableTheming="True" ontextchanged="TB_ItemName_TextChanged"></asp:TextBox>
    </div>     
      
    
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
        EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
    </asp:BulletedList>
    <uc2:PropertyEditor ID="PropertyEditor1" runat="server" />

    
</asp:Panel>
        <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
            EnableViewState="False" Interval="1">
        </asp:Timer>