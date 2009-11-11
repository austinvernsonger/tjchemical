<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentIdEditDraggableControl.ascx.cs" Inherits="Report_Control_EditControl_StudentIdEditDraggableControl" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="generaleditor" tagprefix="uc1" %>

<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportHolderPanel ReportHolderPanelForSelect">
    <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

    <div class="DisplayItemLabel">
    <asp:Label ID="Label_lItemName" runat="server" > </asp:Label>
    </div>
    
    <div class="DisplayItemControl">
     <asp:TextBox ID="TextBoxName_ID" runat="server" readonly="true"></asp:TextBox>
    </div>
               
    <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
     EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
    </asp:BulletedList>
    

</asp:Panel>
        <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
            EnableViewState="False" Interval="1">
        </asp:Timer>

