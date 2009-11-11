<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextEditControl.ascx.cs" Inherits="Report_Control_EditControl_TextEditControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="GeneralEditor" tagprefix="uc1" %>
<%@ Register src="GeneralEditor/PropertyEditor.ascx" tagname="PropertyEditor" tagprefix="uc2" %>

<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportHolderPanel ReportHolderPanelForSelect">
        <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

        <div class="EditItemLabel">单文本</div>
        <div class="EditItemControl">
            <asp:TextBox ID="TB_ItemName" runat="server" AutoPostBack="True" 
            EnableTheming="True" ontextchanged="TB_ItemName_TextChanged" ></asp:TextBox>
        </div>

        
        <uc2:PropertyEditor ID="PropertyEditor1" runat="server" />
        <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
            EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
        </asp:BulletedList>
</asp:Panel>
        <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
            EnableViewState="False" Interval="1">
        </asp:Timer>

