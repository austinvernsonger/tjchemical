<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextEditDraggableControl.ascx.cs" Inherits="Report_Control_EditControl_TextEditDraggableControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="GeneralEditor" tagprefix="uc1" %>


<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportHolderPanel ReportHolderPanelForSelect">
        <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

    <asp:Label ID="Hidden_ItemTypeForAttr" runat="server" style="display:none"></asp:Label>
    <asp:Label ID="Hidden_ParentFullName" runat="server" style="display:none"></asp:Label>
    
 <div class="DisplayItemLabel">
 <asp:Label ID="Label_ItemName" runat="server" ></asp:Label>
 </div>
    
  <div class="DisplayItemControl">
  <asp:TextBox ID="TextBox_contest" runat="server" readonly="true"></asp:TextBox>
  </div>

 <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
                EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
            </asp:BulletedList>
 

    <asp:Panel ID="Panel_PropertyInCtrl" runat="server" style="display:none">
        <asp:Label ID="CB_IsKey" runat="server"></asp:Label>
        <br />
        <asp:Label ID="CB_MustNotEmpty" runat="server"></asp:Label>
        <br />
        <asp:Label ID="TB_MaxSize" runat="server"></asp:Label>
        <br />
        <asp:Label ID="DropDownList_ResultEditMode" runat="server"></asp:Label>
        <br />
        <asp:Label ID="DropDownList_ResultViewMode" runat="server"></asp:Label>
    </asp:Panel>

</asp:Panel>


        <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
            EnableViewState="False" Interval="1">
        </asp:Timer>
