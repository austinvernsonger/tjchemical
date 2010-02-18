<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminCheckEditControl.ascx.cs" Inherits="Report_Control_EditControl_AdminCheckEditControl" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="generaleditor" tagprefix="uc1" %>
<%@ Register src="GeneralEditor/PropertyEditor.ascx" tagname="propertyeditor" tagprefix="uc2" %>


<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportHolderPanel ReportHolderPanelForSelect">
    <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

    <div class="EditItemLabel">审核</div>
    <div class=""EditItemControl"> &nbsp;</div>
    
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
        EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
    </asp:BulletedList>
</asp:Panel>

        <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
            EnableViewState="False" Interval="1">
        </asp:Timer>  
