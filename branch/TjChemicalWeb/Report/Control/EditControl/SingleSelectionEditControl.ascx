<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SingleSelectionEditControl.ascx.cs" Inherits="Report_Control_EditControl_SingleSelectionEditControl" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="GeneralEditor" tagprefix="uc1" %>
<%@ Register src="GeneralEditor/PropertyEditor.ascx" tagname="PropertyEditor" tagprefix="uc2" %>
<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportHolderPanel ReportHolderPanelForSelect">
    <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

    <div class="EditItemLabel">单选</div>
    <div class="EditItemControl">
        <asp:TextBox ID="TB_Name" runat="server" AutoPostBack="True" 
        ontextchanged="TB_Name_TextChanged" Width="150px"></asp:TextBox>
    </div>
    <div class="EditItemLabel">选项<br /><br /></div>
    <div class="EditItemControl">
        <asp:TextBox ID="TB_Selection" runat="server" Width="150px"></asp:TextBox>
        <asp:Button ID="BN_AddSelection" runat="server" onclick="BN_AddSelection_Click" 
            Text="添加" />
        <br/>
        <asp:DropDownList ID="DropDownList_Selection" runat="server" Width="150px">
        </asp:DropDownList>
        <asp:Button ID="BN_DeleteSelection" runat="server" 
            onclick="BN_DeleteSelection_Click" Text="删除" />
    </div>

            
            <uc2:PropertyEditor ID="PropertyEditor1" runat="server" />
            <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
                EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
            </asp:BulletedList>
            
</asp:Panel>
            <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
                EnableViewState="False" Interval="1">
            </asp:Timer>